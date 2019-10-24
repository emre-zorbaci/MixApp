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
    public partial class frmGridKontrol : Form
    {
        public frmGridKontrol()
        {
            InitializeComponent();
        }

        private void frmGridKontrol_Load(object sender, EventArgs e)
        {

        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            txtId.BackColor = DefaultBackColor;
            txtAd.BackColor = DefaultBackColor;
            txtSoyad.BackColor = DefaultBackColor;
            if (txtId.Text!="" && txtAd.Text!="" && txtSoyad.Text!="")
            {
                int satir = Liste.Rows.Add();
                Liste.Rows[satir].Cells[0].Value = txtId.Text;
                Liste.Rows[satir].Cells[1].Value = txtAd.Text;
                Liste.Rows[satir].Cells[2].Value = txtSoyad.Text;
                Temizle();
            }
            else
            {
                if (txtId.Text == "") txtId.BackColor = Color.Red;
                if (txtAd.Text == "") txtAd.BackColor = Color.Yellow;
                if (txtSoyad.Text == "") txtSoyad.BackColor = Color.Green;
            }

            
        }
        void Temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
        }

        private void frmGridKontrol_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = Liste.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = Liste.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = Liste.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
