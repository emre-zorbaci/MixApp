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
    public partial class frmFibonacci : Form
    {
        public frmFibonacci()
        {
            InitializeComponent();
        }

        private void frmFibonacci_Load(object sender, EventArgs e)
        {

        }

        private void frmFibonacci_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int sayi = Convert.ToInt32(txtSayi.Text);
            int birinciSayi = 0;
            int ikinciSayi = 1;
            listBox1.Items.Add(birinciSayi);
            listBox1.Items.Add(ikinciSayi);
            for (int i = 2; i < sayi; i++)
            {
                int temp = birinciSayi + ikinciSayi;
                listBox1.Items.Add(temp);
                birinciSayi = ikinciSayi;
                ikinciSayi = temp;
            }
        }
    }
}
