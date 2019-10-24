namespace MixApp.Bir
{
    partial class frmElmaTopla
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
            this.components = new System.ComponentModel.Container();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.btnTekrar = new System.Windows.Forms.Button();
            this.btnRobot = new System.Windows.Forms.Button();
            this.pbSepet = new System.Windows.Forms.PictureBox();
            this.pbAgac = new System.Windows.Forms.PictureBox();
            this.lblSepet = new System.Windows.Forms.Label();
            this.lblElma = new System.Windows.Forms.Label();
            this.timerBaslat = new System.Windows.Forms.Timer(this.components);
            this.timerBitir = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbSepet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgac)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBaslat
            // 
            this.btnBaslat.Location = new System.Drawing.Point(64, 267);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(75, 23);
            this.btnBaslat.TabIndex = 1;
            this.btnBaslat.Text = "Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // btnTekrar
            // 
            this.btnTekrar.Location = new System.Drawing.Point(166, 267);
            this.btnTekrar.Name = "btnTekrar";
            this.btnTekrar.Size = new System.Drawing.Size(75, 23);
            this.btnTekrar.TabIndex = 1;
            this.btnTekrar.Text = "Tekrar";
            this.btnTekrar.UseVisualStyleBackColor = true;
            this.btnTekrar.Click += new System.EventHandler(this.btnTekrar_Click);
            // 
            // btnRobot
            // 
            this.btnRobot.BackgroundImage = global::MixApp.Properties.Resources.cinali;
            this.btnRobot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRobot.Location = new System.Drawing.Point(589, 267);
            this.btnRobot.Name = "btnRobot";
            this.btnRobot.Size = new System.Drawing.Size(56, 51);
            this.btnRobot.TabIndex = 1;
            this.btnRobot.UseVisualStyleBackColor = true;
            // 
            // pbSepet
            // 
            this.pbSepet.Image = global::MixApp.Properties.Resources.sepet;
            this.pbSepet.Location = new System.Drawing.Point(664, 251);
            this.pbSepet.Name = "pbSepet";
            this.pbSepet.Size = new System.Drawing.Size(98, 83);
            this.pbSepet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSepet.TabIndex = 0;
            this.pbSepet.TabStop = false;
            // 
            // pbAgac
            // 
            this.pbAgac.Image = global::MixApp.Properties.Resources.elama;
            this.pbAgac.Location = new System.Drawing.Point(12, 12);
            this.pbAgac.Name = "pbAgac";
            this.pbAgac.Size = new System.Drawing.Size(135, 99);
            this.pbAgac.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAgac.TabIndex = 0;
            this.pbAgac.TabStop = false;
            // 
            // lblSepet
            // 
            this.lblSepet.BackColor = System.Drawing.Color.Red;
            this.lblSepet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSepet.ForeColor = System.Drawing.Color.White;
            this.lblSepet.Location = new System.Drawing.Point(545, 337);
            this.lblSepet.Name = "lblSepet";
            this.lblSepet.Size = new System.Drawing.Size(217, 34);
            this.lblSepet.TabIndex = 2;
            this.lblSepet.Text = "Sepetteki Elma Sayısı :";
            this.lblSepet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblElma
            // 
            this.lblElma.BackColor = System.Drawing.Color.Red;
            this.lblElma.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblElma.ForeColor = System.Drawing.Color.White;
            this.lblElma.Location = new System.Drawing.Point(9, 124);
            this.lblElma.Name = "lblElma";
            this.lblElma.Size = new System.Drawing.Size(138, 34);
            this.lblElma.TabIndex = 2;
            this.lblElma.Text = "Elma Sayısı :";
            this.lblElma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerBaslat
            // 
            this.timerBaslat.Interval = 5;
            this.timerBaslat.Tick += new System.EventHandler(this.timerBaslat_Tick);
            // 
            // timerBitir
            // 
            this.timerBitir.Interval = 5;
            this.timerBitir.Tick += new System.EventHandler(this.timerBitir_Tick);
            // 
            // frmElmaTopla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 380);
            this.Controls.Add(this.lblElma);
            this.Controls.Add(this.lblSepet);
            this.Controls.Add(this.btnRobot);
            this.Controls.Add(this.btnTekrar);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.pbSepet);
            this.Controls.Add(this.pbAgac);
            this.Name = "frmElmaTopla";
            this.Text = "frmElmaTopla";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmElmaTopla_FormClosing);
            this.Load += new System.EventHandler(this.frmElmaTopla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSepet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgac)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAgac;
        private System.Windows.Forms.PictureBox pbSepet;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Button btnTekrar;
        private System.Windows.Forms.Button btnRobot;
        private System.Windows.Forms.Label lblSepet;
        private System.Windows.Forms.Label lblElma;
        private System.Windows.Forms.Timer timerBaslat;
        private System.Windows.Forms.Timer timerBitir;
    }
}