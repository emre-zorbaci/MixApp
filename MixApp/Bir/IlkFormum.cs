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
    public partial class IlkFormum : Form
    {
        public IlkFormum()
        {
            InitializeComponent();
        }

        private void IlkFormum_Load(object sender, EventArgs e)
        {
            DenemeList();
            DenemeArrayList();
        }

        private void IlkFormum_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            IkinciForm frm = new IkinciForm();
            frm.txtBilgiAl.Text = txtBilgi.Text;
            frm.Show();
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            MainPage.Aktar = txtBilgi.Text;
            Close();
        }
        private void DenemeList()
        {
            listBox1.Items.Clear();
            if (MainPage.Laktar!=null)
            {
                foreach (var eleman in MainPage.Laktar)
                {
                    listBox1.Items.Add(eleman);
                }
                MainPage.Laktar.Clear(); 
            }
        }
        private void DenemeArrayList()
        {
            listBox2.Items.Clear();
            if (MainPage.Aaktar!=null)
            {
                foreach (var eleman in MainPage.Aaktar)
                {
                    listBox2.Items.Add(eleman);
                }
                MainPage.Aaktar.Clear();
            }            
        }
    }
}
