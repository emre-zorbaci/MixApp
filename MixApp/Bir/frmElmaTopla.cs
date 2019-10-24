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
    public partial class frmElmaTopla : Form
    {
        int elmaSayisi = 20, sepetMevcut = 0, buttonKonum;

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            timerBaslat.Start();
        }

        private void timerBaslat_Tick(object sender, EventArgs e)
        {
            if(btnRobot.Top>=pbAgac.Top)
            {
                btnRobot.Top = btnRobot.Top - 3;
            }
            else
            {
                if(btnRobot.Left>=pbAgac.Right)
                {
                    btnRobot.Left -= 3;
                }
                else
                {
                    timerBaslat.Stop();
                    elmaSayisi--;
                    lblElma.Text = "Elma Sayısı :" + elmaSayisi;
                    timerBitir.Start();
                }
            }
        }

        private void btnTekrar_Click(object sender, EventArgs e)
        {
            btnRobot.Left = buttonKonum;
            elmaSayisi = 20;
            sepetMevcut = 0;
        }

        private void timerBitir_Tick(object sender, EventArgs e)
        {
            if(btnRobot.Left<=pbSepet.Left)
            {
                btnRobot.Left += 3;
            }
            else
            {
                if(btnRobot.Bottom<=pbSepet.Top)
                {
                    btnRobot.Top += 3;
                }
                else if(sepetMevcut!=19)
                {
                    timerBitir.Stop();
                    sepetMevcut++;
                    lblSepet.Text = "Sepetteki Elma Sayısı :" + sepetMevcut;
                    timerBaslat.Start();
                }
                else
                {
                    timerBitir.Stop();
                    timerBaslat.Stop();
                    sepetMevcut++;
                    lblSepet.Text = "Sepetteki Elma Sayısı :" + sepetMevcut;
                    MessageBox.Show("Elma toplama işi bitmiştir.");
                }
            }
        }

        private void frmElmaTopla_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }

        public frmElmaTopla()
        {
            InitializeComponent();
        }

        private void frmElmaTopla_Load(object sender, EventArgs e)
        {
            lblElma.Text = "Elma Sayısı : " + elmaSayisi;
            lblSepet.Text = "Sepetteki Elma Sayısı :" + sepetMevcut;
            buttonKonum = btnRobot.Left;
        }
    }
}
