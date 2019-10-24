using MixApp.Fonksiyonlar;
using MixApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixApp.Iki
{
    public partial class frmUrun : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        Formlar F = new Formlar();
        Numaralar N = new Numaralar();
        Resimler R = new Resimler();

        bool edit = false;
        bool resim = false;
        int urunId = -1;
        OpenFileDialog dosya = new OpenFileDialog();

        public frmUrun()
        {
            InitializeComponent();
        }

        private void frmUrun_Load(object sender, EventArgs e)
        {
            combo();
            txtUrunKodu.Text = N.urunNumara();//0000001
        }
        void temizle()
        {
            foreach (Control ct in splitContainer1.Panel1.Controls)
            {
                if (ct is TextBox || ct is ComboBox )
                {
                    ct.Text = "";
                }
            }
            txtUrunKodu.Text = N.urunNumara();
            edit = false;
            urunId = -1;
        }
        void combo()
        {
            txtKategori.ValueMember = "Id";
            txtKategori.DisplayMember = "KategoriAdi";
            txtKategori.DataSource = db.tblKategorilers.OrderBy(x => x.KategoriAdi).ToList();
            txtKategori.SelectedIndex = -1;

            txtMarka.ValueMember = "Id";
            txtMarka.DisplayMember = "MarkaAdi";
            txtMarka.DataSource = db.tblMarkalars.OrderBy(x => x.MarkaAdi).ToList();
            txtMarka.SelectedIndex = -1;
        }

        private void frmUrun_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }

        private void btnCollaps_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed)
            {
                splitContainer1.Panel2Collapsed = false;
                btnCollaps.Text = "GİZLE";
            }
            else if (splitContainer1.Panel2Collapsed == false)
            {
                splitContainer1.Panel2Collapsed = true;
                btnCollaps.Text = "GÖSTER";
            }
        }

        void YeniKayit()
        {
            try
            {
                tblUrunler urun = new tblUrunler();
                urun.Aciklama = txtAciklama.Text;
                //urun.KategoriId =(int)txtKategori.SelectedValue;

                urun.KategoriId = txtKategori.Text != "" ? db.tblKategorilers.First(x => x.KategoriAdi == txtKategori.Text).Id : 1;

                urun.MarkaId = txtMarka.Text != "" ? (int)txtMarka.SelectedValue : 1;
                urun.Mensei = txtMensei.Text;
                if (pbResim.Image != null) urun.Resim = new Binary(R.ResimYukleme(pbResim.Image));
                urun.SaveDate = DateTime.Now;
                urun.SaveUser = -1;
                //urun.SeriLotNo = txtLot.Text;
                urun.UpdateDate = DateTime.Now;
                urun.UpdateUser = -1;
                urun.UrunKodu = int.Parse(txtUrunKodu.Text);
                urun.UrunAdi = txtUrunAdi.Text;

                db.tblUrunlers.InsertOnSubmit(urun);
                db.SubmitChanges();
                MessageBox.Show("Kayıt gerçekleştirildi.");
                Close();
                F.UrunForm();
            }
            catch (Exception e)
            {
                MessageBox.Show("Hata :" + e.Message);
            }

        }
        void Guncelle()
        {
            try
            {
                DbFirstDataContext gb = new DbFirstDataContext();
                int? kat, mar;
                kat = db.tblKategorilers.First(x => x.KategoriAdi == txtKategori.Text).Id;
                mar = db.tblMarkalars.First(x => x.MarkaAdi == txtMarka.Text).Id;
                //DbFirstDataContext gb = new DbFirstDataContext();
                tblUrunler urn = gb.tblUrunlers.First(x => x.UrunKodu == urunId);
                urn.Aciklama = txtAciklama.Text;
                urn.KategoriId = kat;
                urn.MarkaId = txtMarka.Text != "" ? mar : 1;
                urn.Mensei = txtMensei.Text;
                //urn.SeriLotNo = txtLot.Text;
                urn.UpdateDate = DateTime.Now;
                urn.UpdateUser = -1;
                urn.UrunAdi = txtUrunAdi.Text;
                urn.UrunKodu = int.Parse(txtUrunKodu.Text);
                if (pbResim.Image != null) urn.Resim = new Binary(R.ResimYukleme(pbResim.Image));
                gb.SubmitChanges();
                MessageBox.Show("Kayıt güncellenmiştir.");
                temizle();
                Close();
                F.UrunForm();
            }
            catch (Exception e)
            {
                MessageBox.Show("Hata Kodu : urnGnc" + e.Message);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            var btnUrun = new Button();
            btnUrun.Size = new Size(25, txtUrunKodu.ClientSize.Height + 2);
            btnUrun.Location = new Point(txtUrunKodu.ClientSize.Width - btnUrun.Width, -1);
            btnUrun.Cursor = Cursors.Default;
            btnUrun.BackgroundImage = Resources.at1;
            btnUrun.BackgroundImageLayout = ImageLayout.Stretch;
            btnUrun.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            txtUrunKodu.Controls.Add(btnUrun);


            base.OnLoad(e);

            btnUrun.Click += btnUrun_Click;
        }
        private void btnUrun_Click(object sender, EventArgs e)
        {
            F.UrnListe();
            int id = MainPage.IAktar;
            if (id > 0)
            {
                UrunAc(id);
            }
            MainPage.IAktar = -1;
        }
        void UrunAc(int id)
        {
            try
            {
                edit = true;
                urunId = id;
                tblUrunler frm = db.tblUrunlers.First(s => s.UrunKodu == urunId);
                txtAciklama.Text = frm.Aciklama;
                txtUrunKodu.Text = frm.UrunKodu.ToString().PadLeft(7, '0');
                txtKategori.Text = frm.tblKategoriler.KategoriAdi;
                //txtLot.Text = frm.SeriLotNo;
                txtMarka.Text = frm.tblMarkalar.MarkaAdi;
                txtMensei.Text = frm.Mensei;
                txtUrunAdi.Text = frm.UrunAdi;
                if (frm.Resim != null) pbResim.Image = R.ResimGetirme(frm.Resim.ToArray());
                else pbResim.Image = Resources.resimyok;
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Kodu: UrnAc01");
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (edit && urunId>0 && MessageBox.Show("Seçili olan kayıt güncellenecektir.\n Güncelleme işlemini onaylıyormusunuz.", "Güncelleme işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Guncelle();
            else if (edit == false) YeniKayit();
                
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUrunResim_Click(object sender, EventArgs e)
        {
            ResimSec();
        }
        void ResimSec()
        {
            dosya.Filter = "Jpg(*.jpg)|*.jpg|Jpeg(*.jpeg)|*.jpeg";
            if(dosya.ShowDialog()==DialogResult.OK)
            {
                pbResim.ImageLocation = dosya.FileName;
                resim = true;
            }
        }
    }
}
