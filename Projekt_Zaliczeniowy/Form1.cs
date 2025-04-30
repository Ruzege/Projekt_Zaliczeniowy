using Microsoft.EntityFrameworkCore;
using Projekt_Zaliczeniowy.Data;
using Projekt_Zaliczeniowy.Models;

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
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            db?.Dispose();
        }
    }
}
