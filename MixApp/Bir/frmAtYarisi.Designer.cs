namespace MixApp.Bir
{
    partial class frmAtYarisi
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
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnAt2 = new System.Windows.Forms.Button();
            this.btnAt1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(753, 12);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(23, 313);
            this.btnFinish.TabIndex = 0;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(29, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(50, 313);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnAt2
            // 
            this.btnAt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAt2.BackgroundImage = global::MixApp.Properties.Resources.at2;
            this.btnAt2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAt2.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnAt2.FlatAppearance.BorderSize = 5;
            this.btnAt2.Location = new System.Drawing.Point(109, 169);
            this.btnAt2.Name = "btnAt2";
            this.btnAt2.Size = new System.Drawing.Size(69, 39);
            this.btnAt2.TabIndex = 1;
            this.btnAt2.UseVisualStyleBackColor = false;
            // 
            // btnAt1
            // 
            this.btnAt1.BackgroundImage = global::MixApp.Properties.Resources.at1;
            this.btnAt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAt1.Location = new System.Drawing.Point(109, 99);
            this.btnAt1.Name = "btnAt1";
            this.btnAt1.Size = new System.Drawing.Size(69, 39);
            this.btnAt1.TabIndex = 1;
            this.btnAt1.UseVisualStyleBackColor = true;
            // 
            // frmAtYarisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 337);
            this.Controls.Add(this.btnAt2);
            this.Controls.Add(this.btnAt1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnFinish);
            this.Name = "frmAtYarisi";
            this.Text = "frmAtYarisi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAtYarisi_FormClosing);
            this.Load += new System.EventHandler(this.frmAtYarisi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnAt1;
        private System.Windows.Forms.Button btnAt2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
    }
}