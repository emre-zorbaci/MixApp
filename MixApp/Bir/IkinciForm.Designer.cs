namespace MixApp.Bir
{
    partial class IkinciForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtBilgiAl = new System.Windows.Forms.TextBox();
            this.btnAl = new System.Windows.Forms.Button();
            this.btnAktarAl = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "İkinci Formum";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Navy;
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(800, 54);
            this.pnlTop.TabIndex = 1;
            // 
            // txtBilgiAl
            // 
            this.txtBilgiAl.Location = new System.Drawing.Point(161, 81);
            this.txtBilgiAl.Name = "txtBilgiAl";
            this.txtBilgiAl.Size = new System.Drawing.Size(237, 22);
            this.txtBilgiAl.TabIndex = 2;
            // 
            // btnAl
            // 
            this.btnAl.Location = new System.Drawing.Point(48, 81);
            this.btnAl.Name = "btnAl";
            this.btnAl.Size = new System.Drawing.Size(75, 23);
            this.btnAl.TabIndex = 3;
            this.btnAl.Text = "Al";
            this.btnAl.UseVisualStyleBackColor = true;
            this.btnAl.Click += new System.EventHandler(this.btnAl_Click);
            // 
            // btnAktarAl
            // 
            this.btnAktarAl.Location = new System.Drawing.Point(252, 124);
            this.btnAktarAl.Name = "btnAktarAl";
            this.btnAktarAl.Size = new System.Drawing.Size(146, 23);
            this.btnAktarAl.TabIndex = 3;
            this.btnAktarAl.Text = "Aktarma Al";
            this.btnAktarAl.UseVisualStyleBackColor = true;
            this.btnAktarAl.Click += new System.EventHandler(this.btnAktarAl_Click);
            // 
            // IkinciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAktarAl);
            this.Controls.Add(this.btnAl);
            this.Controls.Add(this.txtBilgiAl);
            this.Controls.Add(this.pnlTop);
            this.Name = "IkinciForm";
            this.Text = "IkinciForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IkinciForm_FormClosing);
            this.Load += new System.EventHandler(this.IkinciForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTop;
        public System.Windows.Forms.TextBox txtBilgiAl;
        private System.Windows.Forms.Button btnAl;
        private System.Windows.Forms.Button btnAktarAl;
    }
}