using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MixApp.Fonksiyonlar;
using MixApp.Properties;

namespace MixApp.Iki
{
    public partial class frmFirma : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        Numaralar N = new Numaralar();
        Formlar F = new Formlar();

        bool edit = false;
        string firmaId = "";

        public frmFirma()
        {
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmFirma_Load(object sender, EventArgs e)
        {
            txtCariKod.Text = N.CariNumara();
        }
        void Temizle()
        {
            foreach (Control ct in splitContainer1.Panel1.Controls)
                if (ct is TextBox) ct.Text = "";            

            //txtAdress.Text = "";
            //txtCariKod.Text = "";
            //txtDepartman.Text = "";
            //txtEmail.Text = "";
            //txtFaks.Text = "";
            //txtFirmaAdi.Text = "";
            //txtGsm.Text = "";
            //txtTel.Text = "";
            //txtVd.Text = "";
            //txtVn.Text = "";
            //txtYetkili.Text = "";

            txtCariKod.Text = N.CariNumara();
            edit = false;
            firmaId = "";
        }
        void YeniKayit()
        {
            try
            {
                if (txtFirmaAdi.Text!="" && txtVd.Text!="" && txtVn.Text!="")
                {
                    tblFirma frm = new tblFirma();
                    frm.Adres = txtAdress.Text;
                    frm.CariKod = txtCariKod.Text;
                    frm.Departman = txtDepartman.Text;
                    frm.Email = txtEmail.Text;
                    frm.Faks = txtFaks.Text;
                    frm.FirmaAdi = txtFirmaAdi.Text;
                    frm.Gsm = txtGsm.Text;
                    frm.Tel = txtTel.Text;
                    frm.VergiD = txtVd.Text;
                    frm.VergiN = txtVn.Text;
                    frm.Yetkili = txtYetkili.Text;
                    db.tblFirmas.InsertOnSubmit(frm);
                    db.SubmitChanges();
                    MessageBox.Show("Kayıt başarıyla gerçekleşti.");
                    Temizle(); 
                }
                else
                {
                    MessageBox.Show("Firma adı,Vergi Dairesi ve Vergi No zorunlu alandır.");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message,"Hata Oluştu",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
        void Guncelle()
        {
            tblFirma frm = db.tblFirmas.First(x => x.CariKod == firmaId);
            frm.Adres = txtAdress.Text;
            frm.CariKod = txtCariKod.Text;
            frm.Departman = txtDepartman.Text;
            frm.Email = txtEmail.Text;
            frm.Faks = txtFaks.Text;
            frm.FirmaAdi = txtFirmaAdi.Text;
            frm.Gsm = txtGsm.Text;
            frm.Tel = txtTel.Text;
            frm.VergiD = txtVd.Text;
            frm.VergiN = txtVn.Text;
            frm.Yetkili = txtYetkili.Text;
            db.SubmitChanges();
            MessageBox.Show("Güncelleme başarıyla gerçekleşti");
            Temizle();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (edit && firmaId != "" && MessageBox.Show("Seçili olan kayıt güncellenecektir\n Güncelleme işlemini onaylıyormusunuz?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Guncelle();
            else if (edit == false) YeniKayit();
            else MessageBox.Show("Güncelleme iptal edildi.");
        }

        protected override void OnLoad(EventArgs e)
        {
            var btnCari = new Button();
            btnCari.Size = new Size(25, txtCariKod.ClientSize.Height + 2);
            btnCari.Location = new Point(txtCariKod.ClientSize.Width - btnCari.Width, -1);
            btnCari.Cursor = Cursors.Default;
            btnCari.BackgroundImage = Resources.at1;
            btnCari.BackgroundImageLayout = ImageLayout.Stretch;
            btnCari.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            txtCariKod.Controls.Add(btnCari);
            

            base.OnLoad(e);

            btnCari.Click += btnCari_Click;
        }
        private void btnCari_Click(object sender,EventArgs e)
        {
            F.FrmListe();
            int id = MainPage.IAktar;
            if(id>0)
            {
                CariAc(id);
            }
            MainPage.IAktar = -1;
        }
        public void CariAc(int id)
        {
            edit = true;
            firmaId = id.ToString().PadLeft(7, '0');
            tblFirma frm = db.tblFirmas.First(s => s.CariKod == firmaId);
            txtAdress.Text = frm.Adres;
            txtCariKod.Text = frm.CariKod.ToString().PadLeft(7, '0');
            txtDepartman.Text = frm.Departman;
            txtEmail.Text = frm.Email;
            txtFaks.Text = frm.Faks;
            txtFirmaAdi.Text = frm.FirmaAdi;
            txtGsm.Text = frm.Gsm;
            txtTel.Text = frm.Tel;
            txtVd.Text = frm.VergiD;
            txtVn.Text = frm.VergiN;
            txtYetkili.Text = frm.Yetkili;
        }
        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFirma_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }
        void Sil()
        {
            db.tblFirmas.DeleteAllOnSubmit(db.tblFirmas.Where(x => x.CariKod == firmaId));
            db.SubmitChanges();
            MessageBox.Show("Kayıt silindi.");
            Temizle();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if(edit && firmaId!="" && MessageBox.Show("Seçili olan kayıt silinecektir.\n Silme işlemini onaylıyormusunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Sil();
        }
    }
}
