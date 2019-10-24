using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixApp
{
    public partial class MainPage : Form
    {
        Fonksiyonlar.Formlar F = new Fonksiyonlar.Formlar();

        public static bool Kontrol = false;
        public static string Aktar = "";
        public static List<object> Laktar;
        public static ArrayList Aaktar;
        public static int IAktar;
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnBir_Click(object sender, EventArgs e)
        {
            grb1.Visible = true;
            grb2.Visible = false;
            grb3.Visible = false;
            grb1.Text = "Alan Bir";
        }

        private void BtnIki_Click(object sender, EventArgs e)
        {
            grb1.Visible = false;
            grb2.Visible = true;
            grb3.Visible = false;
            grb2.Text = "Alan İki";
        }

        private void btnUc_Click(object sender, EventArgs e)
        {
            grb1.Visible = false;
            grb2.Visible = false;
            grb3.Visible = true;
            grb3.Text = "Alan Üç";
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            grb1.Text = "Alan Bir";
        }

        private void btnIlkForm_Click(object sender, EventArgs e)
        {

            if (Kontrol==false)
            {
                F.IlkForm();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Kontrol==false)
            {
                Bir.IkinciForm frm = new Bir.IkinciForm();
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                Kontrol = true;
                frm.Show(); 
            }
        }

        private void btnArrayList_Click(object sender, EventArgs e)
        {
            if (Kontrol == false)
            {
                Bir.frmArrayList frm = new Bir.frmArrayList();
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                Kontrol = true;
                frm.Show();
            }
        }

        private void btnFibo_Click(object sender, EventArgs e)
        {
            if (Kontrol == false)
            {
                Bir.frmFibonacci frm = new Bir.frmFibonacci();
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                Kontrol = true;
                frm.Show();
            }
        }

        private void btnGridKontrol_Click(object sender, EventArgs e)
        {
            if (Kontrol == false)
            {
                Bir.frmGridKontrol frm = new Bir.frmGridKontrol();
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                Kontrol = true;
                frm.Show();
            }
        }

        private void btnElmaTopla_Click(object sender, EventArgs e)
        {
            if (Kontrol == false)
            {
                Bir.frmElmaTopla frm = new Bir.frmElmaTopla();
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                Kontrol = true;
                frm.Show();
            }
        }

        private void btnAtYarisi_Click(object sender, EventArgs e)
        {
            if (Kontrol == false)
            {
                Bir.frmAtYarisi frm = new Bir.frmAtYarisi();
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                Kontrol = true;
                frm.Show();
            }
        }

        private void btnFirma_Click(object sender, EventArgs e)
        {
            if (Kontrol==false)
            {
                F.FirmaForm();
                //Kontrol = true;
            }
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            if (Kontrol == false)
            {
                F.UrunForm();

                //Kontrol = true;
            }
        }

        private void btnKategoriGiris_Click(object sender, EventArgs e)
        {
            if (Kontrol==false)
            {
                F.KatListe();
                
            }
        }

        private void btnStokGiris_Click(object sender, EventArgs e)
        {
            if (Kontrol == false)
            {
                F.StokGiris();

            }
        }

        private void btnStokDurum_Click(object sender, EventArgs e)
        {
            F.StkDurum();
        }

        private void btnSiparisAl_Click(object sender, EventArgs e)
        {
            F.SprAl();
        }
    }
}
