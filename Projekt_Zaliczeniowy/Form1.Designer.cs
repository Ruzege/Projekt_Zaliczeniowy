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
            splitContainer1.Size = new Size(700, 300);
            splitContainer1.SplitterDistance = 350;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridViewKomputery
            // 
            dataGridViewKomputery.AllowDrop = true;
            dataGridViewKomputery.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKomputery.Dock = DockStyle.Fill;
            dataGridViewKomputery.Location = new Point(0, 0);
            dataGridViewKomputery.Margin = new Padding(3, 2, 3, 2);
            dataGridViewKomputery.Name = "dataGridViewKomputery";
            dataGridViewKomputery.Size = new Size(350, 300);
            dataGridViewKomputery.TabIndex = 0;
            // 
            // dataGridViewProgramy
            // 
            dataGridViewProgramy.AllowDrop = true;
            dataGridViewProgramy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProgramy.Dock = DockStyle.Fill;
            dataGridViewProgramy.Location = new Point(0, 0);
            dataGridViewProgramy.Margin = new Padding(3, 2, 3, 2);
            dataGridViewProgramy.Name = "dataGridViewProgramy";
            dataGridViewProgramy.Size = new Size(346, 300);
            dataGridViewProgramy.TabIndex = 0;
            // 
            // buttonZapisz
            // 
            buttonZapisz.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonZapisz.Location = new Point(569, 308);
            buttonZapisz.Margin = new Padding(3, 2, 3, 2);
            buttonZapisz.Name = "buttonZapisz";
            buttonZapisz.Size = new Size(114, 22);
            buttonZapisz.TabIndex = 1;
            buttonZapisz.Text = "Zapisz zmiany";
            buttonZapisz.UseVisualStyleBackColor = true;
            buttonZapisz.Click += buttonZapisz_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
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
    }
}
