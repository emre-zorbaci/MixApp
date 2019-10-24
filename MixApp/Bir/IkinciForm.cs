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
    public partial class IkinciForm : Form
    {
        public IkinciForm()
        {
            InitializeComponent();
        }

        private void IkinciForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
            
        }

        private void btnAl_Click(object sender, EventArgs e)
        {
            IlkFormum frm = new IlkFormum();
            txtBilgiAl.Text = frm.txtBilgi.Text;
        }

        private void IkinciForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAktarAl_Click(object sender, EventArgs e)
        {
            txtBilgiAl.Text = MainPage.Aktar;
            MainPage.Aktar = "";

            //MainPage.Aktar = textbox1.text + "," + textbox2.text + "," + textbox3.text;
        }
    }
}
