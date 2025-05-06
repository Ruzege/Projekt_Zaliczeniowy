namespace Projekt_Zaliczeniowy
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            dataGridViewKomputery = new DataGridView();
            dataGridViewProgramy = new DataGridView();
            buttonZapisz = new Button();
            buttonDodajProgram = new Button();
            buttonUsunProgram = new Button();
            btnImportCSV = new Button();
            btnExportCSV = new Button();
            cmbExportType = new ComboBox();
            btnExportPDF = new Button();
            lstLog = new ListBox();
            btnExportLog = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKomputery).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProgramy).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Top;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridViewKomputery);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewProgramy);
            splitContainer1.Size = new Size(822, 300);
            splitContainer1.SplitterDistance = 411;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridViewKomputery
            // 
            dataGridViewKomputery.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKomputery.Dock = DockStyle.Fill;
            dataGridViewKomputery.Location = new Point(0, 0);
            dataGridViewKomputery.Margin = new Padding(3, 2, 3, 2);
            dataGridViewKomputery.Name = "dataGridViewKomputery";
            dataGridViewKomputery.Size = new Size(411, 300);
            dataGridViewKomputery.TabIndex = 0;
            dataGridViewKomputery.SelectionChanged += dataGridViewKomputery_SelectionChanged;
            dataGridViewKomputery.DragDrop += dataGridViewKomputery_DragDrop;
            dataGridViewKomputery.DragOver += dataGridViewKomputery_DragOver;
            // 
            // dataGridViewProgramy
            // 
            dataGridViewProgramy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProgramy.Dock = DockStyle.Fill;
            dataGridViewProgramy.Location = new Point(0, 0);
            dataGridViewProgramy.Margin = new Padding(3, 2, 3, 2);
            dataGridViewProgramy.Name = "dataGridViewProgramy";
            dataGridViewProgramy.Size = new Size(407, 300);
            dataGridViewProgramy.TabIndex = 0;
            dataGridViewProgramy.MouseDown += dataGridViewProgramy_MouseDown;
            // 
            // buttonZapisz
            // 
            buttonZapisz.Location = new Point(696, 308);
            buttonZapisz.Margin = new Padding(3, 2, 3, 2);
            buttonZapisz.Name = "buttonZapisz";
            buttonZapisz.Size = new Size(114, 22);
            buttonZapisz.TabIndex = 1;
            buttonZapisz.Text = "Zapisz zmiany";
            buttonZapisz.UseVisualStyleBackColor = true;
            buttonZapisz.Click += buttonZapisz_Click;
            // 
            // buttonDodajProgram
            // 
            buttonDodajProgram.Location = new Point(576, 308);
            buttonDodajProgram.Margin = new Padding(3, 2, 3, 2);
            buttonDodajProgram.Name = "buttonDodajProgram";
            buttonDodajProgram.Size = new Size(114, 22);
            buttonDodajProgram.TabIndex = 2;
            buttonDodajProgram.Text = "Dodaj program";
            buttonDodajProgram.UseVisualStyleBackColor = true;
            buttonDodajProgram.Click += buttonDodajProgram_Click;
            // 
            // buttonUsunProgram
            // 
            buttonUsunProgram.Location = new Point(456, 308);
            buttonUsunProgram.Margin = new Padding(3, 2, 3, 2);
            buttonUsunProgram.Name = "buttonUsunProgram";
            buttonUsunProgram.Size = new Size(114, 22);
            buttonUsunProgram.TabIndex = 3;
            buttonUsunProgram.Text = "Usuń program";
            buttonUsunProgram.UseVisualStyleBackColor = true;
            buttonUsunProgram.Click += buttonUsunProgram_Click;
            // 
            // btnImportCSV
            // 
            btnImportCSV.Location = new Point(126, 307);
            btnImportCSV.Name = "btnImportCSV";
            btnImportCSV.Size = new Size(104, 23);
            btnImportCSV.TabIndex = 5;
            btnImportCSV.Text = "Importuj z CSV";
            btnImportCSV.UseVisualStyleBackColor = true;
            btnImportCSV.Click += btnImportCSV_Click;
            // 
            // btnExportCSV
            // 
            btnExportCSV.Location = new Point(12, 307);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(108, 23);
            btnExportCSV.TabIndex = 7;
            btnExportCSV.Text = "Exportuj do CSV";
            btnExportCSV.UseVisualStyleBackColor = true;
            btnExportCSV.Click += btnExportCSV_Click;
            // 
            // cmbExportType
            // 
            cmbExportType.FormattingEnabled = true;
            cmbExportType.Location = new Point(12, 345);
            cmbExportType.Name = "cmbExportType";
            cmbExportType.Size = new Size(108, 23);
            cmbExportType.TabIndex = 8;
            cmbExportType.Text = "Typ danych:";
            cmbExportType.SelectedIndexChanged += cmbExportType_SelectedIndexChanged;
            // 
            // btnExportPDF
            // 
            btnExportPDF.Location = new Point(236, 307);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(108, 23);
            btnExportPDF.TabIndex = 9;
            btnExportPDF.Text = "Exportuj do PDF";
            btnExportPDF.UseVisualStyleBackColor = true;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(12, 385);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(330, 94);
            lstLog.TabIndex = 10;
            // 
            // btnExportLog
            // 
            btnExportLog.Location = new Point(126, 345);
            btnExportLog.Name = "btnExportLog";
            btnExportLog.Size = new Size(104, 23);
            btnExportLog.TabIndex = 11;
            btnExportLog.Text = "Exportuj logi";
            btnExportLog.UseVisualStyleBackColor = true;
            btnExportLog.Click += btnExportLog_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 488);
            Controls.Add(btnExportLog);
            Controls.Add(lstLog);
            Controls.Add(btnExportPDF);
            Controls.Add(cmbExportType);
            Controls.Add(btnExportCSV);
            Controls.Add(btnImportCSV);
            Controls.Add(buttonUsunProgram);
            Controls.Add(buttonDodajProgram);
            Controls.Add(buttonZapisz);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Zarządzanie oprogramowaniem w firmie";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewKomputery).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProgramy).EndInit();
            ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewKomputery;
        private System.Windows.Forms.DataGridView dataGridViewProgramy;
        private System.Windows.Forms.Button buttonZapisz;
        private System.Windows.Forms.Button buttonDodajProgram;
        private System.Windows.Forms.Button buttonUsunProgram;
        private Button button1;
        private Button btnImportCSV;
        private Button btnExportCSV;
        private ComboBox cmbExportType;
        private Button btnExportPDF;
        private ListBox lstLog;
        private Button btnExportLog;
    }
}