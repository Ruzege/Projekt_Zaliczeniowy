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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewKomputery = new System.Windows.Forms.DataGridView();
            this.dataGridViewProgramy = new System.Windows.Forms.DataGridView();
            this.buttonZapisz = new System.Windows.Forms.Button();
            this.buttonDodajProgram = new System.Windows.Forms.Button();
            this.buttonUsunProgram = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKomputery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProgramy)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(800, 400);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewKomputery);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewProgramy);
            // 
            // dataGridViewKomputery
            // 
            this.dataGridViewKomputery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewKomputery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKomputery.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewKomputery.Name = "dataGridViewKomputery";
            this.dataGridViewKomputery.Size = new System.Drawing.Size(400, 400);
            this.dataGridViewKomputery.TabIndex = 0;
            this.dataGridViewKomputery.SelectionChanged += new System.EventHandler(this.dataGridViewKomputery_SelectionChanged);
            this.dataGridViewKomputery.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridViewKomputery_DragOver);
            this.dataGridViewKomputery.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewKomputery_DragDrop);
            // 
            // dataGridViewProgramy
            // 
            this.dataGridViewProgramy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProgramy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProgramy.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewProgramy.Name = "dataGridViewProgramy";
            this.dataGridViewProgramy.Size = new System.Drawing.Size(396, 400);
            this.dataGridViewProgramy.TabIndex = 0;
            this.dataGridViewProgramy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewProgramy_MouseDown);
            // 
            // buttonZapisz
            // 
            this.buttonZapisz.Location = new System.Drawing.Point(650, 410);
            this.buttonZapisz.Name = "buttonZapisz";
            this.buttonZapisz.Size = new System.Drawing.Size(130, 30);
            this.buttonZapisz.TabIndex = 1;
            this.buttonZapisz.Text = "Zapisz zmiany";
            this.buttonZapisz.UseVisualStyleBackColor = true;
            this.buttonZapisz.Click += new System.EventHandler(this.buttonZapisz_Click);
            // 
            // buttonDodajProgram
            // 
            this.buttonDodajProgram.Location = new System.Drawing.Point(500, 410);
            this.buttonDodajProgram.Name = "buttonDodajProgram";
            this.buttonDodajProgram.Size = new System.Drawing.Size(130, 30);
            this.buttonDodajProgram.TabIndex = 2;
            this.buttonDodajProgram.Text = "Dodaj program";
            this.buttonDodajProgram.UseVisualStyleBackColor = true;
            this.buttonDodajProgram.Click += new System.EventHandler(this.buttonDodajProgram_Click);
            // 
            // buttonUsunProgram
            // 
            this.buttonUsunProgram.Location = new System.Drawing.Point(360, 410);
            this.buttonUsunProgram.Name = "buttonUsunProgram";
            this.buttonUsunProgram.Size = new System.Drawing.Size(130, 30);
            this.buttonUsunProgram.TabIndex = 3;
            this.buttonUsunProgram.Text = "Usuń program";
            this.buttonUsunProgram.UseVisualStyleBackColor = true;
            this.buttonUsunProgram.Click += new System.EventHandler(this.buttonUsunProgram_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonUsunProgram);
            this.Controls.Add(this.buttonDodajProgram);
            this.Controls.Add(this.buttonZapisz);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Zarządzanie oprogramowaniem w firmie";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKomputery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProgramy)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewKomputery;
        private System.Windows.Forms.DataGridView dataGridViewProgramy;
        private System.Windows.Forms.Button buttonZapisz;
        private System.Windows.Forms.Button buttonDodajProgram;
        private System.Windows.Forms.Button buttonUsunProgram;
    }
}