using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.EntityFrameworkCore;
using Projekt_Zaliczeniowy.Data;
using Projekt_Zaliczeniowy.Models;
using System.Text;

namespace Projekt_Zaliczeniowy
{
    public partial class Form1 : Form
    {
        private FirmaContext? db;
        private Oprogramowanie? przeciaganyProgram = null;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            db = new FirmaContext();
            db.Database.EnsureCreated();
            db.Komputery.Load();

            cmbExportType.Items.AddRange(new object[] { "Komputery", "Programy", "Wszystko" });
            cmbExportType.SelectedIndex = 0;

            dataGridViewKomputery.AllowDrop = true;
            dataGridViewKomputery.DataSource = db.Komputery.Local.ToBindingList();
            dataGridViewProgramy.AutoGenerateColumns = true;

        }

        private void dataGridViewKomputery_SelectionChanged(object sender, EventArgs e)
        {
            if (db == null || dataGridViewKomputery.CurrentRow == null) return;

            var komputer = dataGridViewKomputery.CurrentRow.DataBoundItem as Komputer;
            if (komputer != null)
            {
                db.Entry(komputer).Collection(k => k.Programy).Load();
                dataGridViewProgramy.DataSource = null;
                dataGridViewProgramy.DataSource = komputer.Programy;
            }
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            db?.SaveChanges();
            dataGridViewKomputery.Refresh();
            dataGridViewProgramy.Refresh();
            Log("Zapisano zmiany.");
        }

        private void dataGridViewProgramy_MouseDown(object sender, MouseEventArgs e)
        {
            if (dataGridViewProgramy.CurrentRow?.DataBoundItem is Oprogramowanie program)
            {
                przeciaganyProgram = program;
                dataGridViewProgramy.DoDragDrop(program, DragDropEffects.Move);
            }
        }

        private void dataGridViewKomputery_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(typeof(Oprogramowanie)) == true)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dataGridViewKomputery_DragDrop(object sender, DragEventArgs e)
        {
            if (db == null || przeciaganyProgram == null) return;

            if (dataGridViewKomputery.CurrentRow?.DataBoundItem is Komputer nowyKomputer)
            {
                przeciaganyProgram.KomputerId = nowyKomputer.KomputerId;
                db.Entry(przeciaganyProgram).State = EntityState.Modified;
                db.SaveChanges();

                db.Entry(nowyKomputer).Collection(k => k.Programy).Load();
                dataGridViewProgramy.DataSource = null;
                dataGridViewProgramy.DataSource = nowyKomputer.Programy;
            }

            przeciaganyProgram = null;
        }

        private void buttonDodajProgram_Click(object sender, EventArgs e)
        {
            if (db == null || dataGridViewKomputery.CurrentRow == null) return;

            var komputer = dataGridViewKomputery.CurrentRow.DataBoundItem as Komputer;
            if (komputer == null) return;

            var nowyProgram = new Oprogramowanie
            {
                Nazwa = "Nowy program",
                Wersja = "1.0",
                TypLicencji = "Trial",
                DataInstalacji = DateTime.Now,
                KomputerId = komputer.KomputerId
            };

            db.Programy.Add(nowyProgram);
            db.SaveChanges();

            db.Entry(komputer).Collection(k => k.Programy).Load();
            dataGridViewProgramy.DataSource = null;
            dataGridViewProgramy.DataSource = komputer.Programy;
            Log("Dodano nowy program.");
        }

        private void buttonUsunProgram_Click(object sender, EventArgs e)
        {
            if (db == null || dataGridViewProgramy.CurrentRow == null) return;

            var program = dataGridViewProgramy.CurrentRow.DataBoundItem as Oprogramowanie;
            if (program == null) return;

            db.Programy.Remove(program);
            db.SaveChanges();

            if (dataGridViewKomputery.CurrentRow?.DataBoundItem is Komputer komputer)
            {
                db.Entry(komputer).Collection(k => k.Programy).Load();
                dataGridViewProgramy.DataSource = null;
                dataGridViewProgramy.DataSource = komputer.Programy;
            }
            Log("Usuniêto program.");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            db?.Dispose();
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (db == null) return;

            string exportType = cmbExportType.SelectedItem?.ToString() ?? "Komputery";

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.Title = $"Eksportuj {exportType} do CSV";
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.FileName = $"{exportType}_{DateTime.Now:yyyyMMdd}.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        if (exportType == "Komputery")
                        {
                            ExportKomputeryToCSV(filePath);
                        }
                        else
                        {
                            ExportProgramyToCSV(filePath);
                        }

                        MessageBox.Show($"Pomyœlnie wyeksportowano dane do pliku: {filePath}", "Eksport zakoñczony", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Wyst¹pi³ b³¹d podczas eksportu: {ex.Message}", "B³¹d eksportu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            if (db == null) return;

            string importType = cmbExportType.SelectedItem?.ToString() ?? "Komputery";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.Title = $"Importuj {importType} z CSV";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        if (importType == "Komputery")
                        {
                            ImportKomputeryFromCSV(filePath);
                        }
                        else
                        {
                            ImportProgramyFromCSV(filePath);
                        }

                        db.Komputery.Load();
                        dataGridViewKomputery.DataSource = db.Komputery.Local.ToBindingList();

                        if (dataGridViewKomputery.CurrentRow?.DataBoundItem is Komputer komputer)
                        {
                            db.Entry(komputer).Collection(k => k.Programy).Load();
                            dataGridViewProgramy.DataSource = null;
                            dataGridViewProgramy.DataSource = komputer.Programy;
                        }

                        MessageBox.Show($"Pomyœlnie zaimportowano dane z pliku: {filePath}", "Import zakoñczony", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Wyst¹pi³ b³¹d podczas importu: {ex.Message}", "B³¹d importu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportKomputeryToCSV(string filePath)
        {
            if (db == null) return;

            var komputery = db.Komputery.ToList();

            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.WriteLine("KomputerId;Nazwa;Dzial;Uzytkownik");

                foreach (var komputer in komputery)
                {
                    sw.WriteLine($"{komputer.KomputerId};{komputer.Nazwa};{komputer.Dzial};{komputer.Uzytkownik}");
                }
            }
        }

        private void ExportProgramyToCSV(string filePath)
        {
            if (db == null) return;

            var programy = db.Programy
                .Include(p => p.Komputer)
                .ToList();

            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.WriteLine("OprogramowanieId;Nazwa;Wersja;TypLicencji;DataInstalacji;KomputerId;NazwaKomputera");

                foreach (var program in programy)
                {
                    sw.WriteLine($"{program.OprogramowanieId};{program.Nazwa};{program.Wersja};{program.TypLicencji};{program.DataInstalacji:yyyy-MM-dd};{program.KomputerId};{program.Komputer?.Nazwa}");
                }
            }
        }

        private void ImportKomputeryFromCSV(string filePath)
        {
            if (db == null) return;

            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                string? line = sr.ReadLine();

                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] values = line.Split(';');
                    if (values.Length < 4) continue;

                    if (int.TryParse(values[0], out int komputerId))
                    {
                        var istniejacyKomputer = db.Komputery.Find(komputerId);

                        if (istniejacyKomputer != null)
                        {
                            istniejacyKomputer.Nazwa = values[1];
                            istniejacyKomputer.Dzial = values[2];
                            istniejacyKomputer.Uzytkownik = values[3];
                        }
                        else
                        {
                            var nowyKomputer = new Komputer
                            {
                                KomputerId = komputerId,
                                Nazwa = values[1],
                                Dzial = values[2],
                                Uzytkownik = values[3]
                            };
                            db.Komputery.Add(nowyKomputer);
                        }
                    }
                }

                db.SaveChanges();
            }
        }

        private void ImportProgramyFromCSV(string filePath)
        {
            if (db == null) return;

            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                string? line = sr.ReadLine();

                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] values = line.Split(';');
                    if (values.Length < 6) continue;

                    if (int.TryParse(values[0], out int programId) && int.TryParse(values[5], out int komputerId))
                    {
                        var komputer = db.Komputery.Find(komputerId);
                        if (komputer == null) continue;

                        var istniejacyProgram = db.Programy.Find(programId);

                        if (istniejacyProgram != null)
                        {
                            istniejacyProgram.Nazwa = values[1];
                            istniejacyProgram.Wersja = values[2];
                            istniejacyProgram.TypLicencji = values[3];
                            if (DateTime.TryParse(values[4], out DateTime dataInstalacji))
                            {
                                istniejacyProgram.DataInstalacji = dataInstalacji;
                            }
                            istniejacyProgram.KomputerId = komputerId;
                        }
                        else
                        {
                            var nowyProgram = new Oprogramowanie
                            {
                                OprogramowanieId = programId,
                                Nazwa = values[1],
                                Wersja = values[2],
                                TypLicencji = values[3],
                                DataInstalacji = DateTime.TryParse(values[4], out DateTime dataInstalacji) ? dataInstalacji : DateTime.Now,
                                KomputerId = komputerId
                            };
                            db.Programy.Add(nowyProgram);
                        }
                    }
                }

                db.SaveChanges();
            }
        }

        private void cmbExportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbExportType.SelectedItem?.ToString() ?? "";
            Console.WriteLine($"Wybrano typ danych: {selected}");
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Zapisz dane jako PDF",
                FileName = "EksportDanych.pdf"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (Document doc = new Document())
                {
                    PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    doc.Open();

                    string selectedType = cmbExportType.SelectedItem?.ToString();

                    if (selectedType == "Komputery" || selectedType == "Wszystko")
                    {
                        doc.Add(new Paragraph("Dane Komputery"));
                        doc.Add(CreatePdfTableFromGrid(dataGridViewKomputery));
                        doc.Add(new Paragraph("\n"));
                        Log("Dodano dane komputerów do PDF.");
                    }

                    if (selectedType == "Programy" || selectedType == "Wszystko")
                    {
                        doc.Add(new Paragraph("Dane Programy"));
                        doc.Add(CreatePdfTableFromGrid(dataGridViewProgramy));
                        Log("Dodano dane programów do PDF.");
                    }

                    doc.Close();
                }

                MessageBox.Show("Dane zosta³y wyeksportowane do PDF!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log("Eksport do PDF zakoñczony.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d eksportu PDF: " + ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log("B³¹d eksportu PDF.");
            }
        }

        private PdfPTable CreatePdfTableFromGrid(DataGridView dgv)
        {
            PdfPTable table = new PdfPTable(dgv.Columns.Count);
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                table.AddCell(new Phrase(col.HeaderText));
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    table.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
                }
            }

            return table;
        }

        private void Log(string message)
        {
            lstLog.Items.Insert(0, $"{DateTime.Now:HH:mm:ss} - {message}");
        }

        private void btnExportLog_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files|*.txt",
                Title = "Zapisz historiê zmian",
                FileName = "HistoriaZmian.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var item in lstLog.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }

                    MessageBox.Show("Logi zapisane pomyœlnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Log("Eksportowano logi do pliku.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B³¹d zapisu logów: " + ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log("B³¹d eksportu logów.");
                }
            }
        }
    }
}