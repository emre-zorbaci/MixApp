using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixApp.Bir
{
    public partial class frmAtYarisi : Form
    {
        Random rnd1 = new Random();
        Random rnd2 = new Random();
        public frmAtYarisi()
        {
            InitializeComponent();
        }

        private void frmAtYarisi_Load(object sender, EventArgs e)
        {

        }

        private void frmAtYarisi_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(btnAt1.Right<=btnFinish.Left && btnAt2.Right<=btnFinish.Left)
            {
                btnAt1.Left += rnd1.Next(1, 5);
                btnAt2.Left += rnd1.Next(1, 5);
            }
            else
            {

                timer1.Stop();
                if (btnAt1.Right > btnAt2.Right)
                {
                    MessageBox.Show("At 1 Şampiyon");
                }
                if (btnAt2.Right > btnAt1.Right)
                {
                    MessageBox.Show("At 2 Şampiyon");
                }
                
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
