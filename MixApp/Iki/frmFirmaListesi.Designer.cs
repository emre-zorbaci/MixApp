﻿namespace MixApp.Iki
{
    partial class frmFirmaListesi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Liste = new System.Windows.Forms.DataGridView();
            this.CariKod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Firma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Yetkili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBul = new System.Windows.Forms.TextBox();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnBul = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Liste);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Panel2.Controls.Add(this.txtBul);
            this.splitContainer1.Panel2.Controls.Add(this.btnKapat);
            this.splitContainer1.Panel2.Controls.Add(this.btnBul);
            this.splitContainer1.Size = new System.Drawing.Size(800, 337);
            this.splitContainer1.SplitterDistance = 622;
            this.splitContainer1.TabIndex = 0;
            // 
            // Liste
            // 
            this.Liste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Liste.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CariKod,
            this.Firma,
            this.Yetkili,
            this.Tel});
            this.Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Liste.Location = new System.Drawing.Point(0, 0);
            this.Liste.Name = "Liste";
            this.Liste.ReadOnly = true;
            this.Liste.RowTemplate.Height = 24;
            this.Liste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Liste.Size = new System.Drawing.Size(618, 333);
            this.Liste.TabIndex = 0;
            this.Liste.DoubleClick += new System.EventHandler(this.Liste_DoubleClick);
            // 
            // CariKod
            // 
            this.CariKod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CariKod.HeaderText = "Cari Kodu";
            this.CariKod.Name = "CariKod";
            this.CariKod.ReadOnly = true;
            this.CariKod.Width = 99;
            // 
            // Firma
            // 
            this.Firma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Firma.HeaderText = "Firma Adı";
            this.Firma.Name = "Firma";
            this.Firma.ReadOnly = true;
            // 
            // Yetkili
            // 
            this.Yetkili.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Yetkili.HeaderText = "Yetkili";
            this.Yetkili.Name = "Yetkili";
            this.Yetkili.ReadOnly = true;
            this.Yetkili.Width = 74;
            // 
            // Tel
            // 
            this.Tel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tel.HeaderText = "Telefon";
            this.Tel.Name = "Tel";
            this.Tel.ReadOnly = true;
            this.Tel.Width = 85;
            // 
            // txtBul
            // 
            this.txtBul.Location = new System.Drawing.Point(3, 112);
            this.txtBul.Name = "txtBul";
            this.txtBul.Size = new System.Drawing.Size(157, 22);
            this.txtBul.TabIndex = 2;
            // 
            // btnKapat
            // 
            this.btnKapat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKapat.Location = new System.Drawing.Point(0, 290);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(170, 43);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "KAPAT";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnBul
            // 
            this.btnBul.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBul.Location = new System.Drawing.Point(0, 0);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(170, 49);
            this.btnBul.TabIndex = 0;
            this.btnBul.Text = "BUL";
            this.btnBul.UseVisualStyleBackColor = true;
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // frmFirmaListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 337);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmFirmaListesi";
            this.Text = "frmFirmaListesi";
            this.Load += new System.EventHandler(this.frmFirmaListesi_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView Liste;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.DataGridViewTextBoxColumn CariKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Firma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Yetkili;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tel;
        private System.Windows.Forms.TextBox txtBul;
    }
}