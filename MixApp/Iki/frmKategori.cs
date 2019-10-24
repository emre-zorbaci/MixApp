using MixApp.Fonksiyonlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MixApp.Iki
{
    public partial class frmKategori : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        string Kat = "";
        int katId = -1;
        public frmKategori()
        {
            InitializeComponent();
        }

        private void frmKategori_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from s in db.tblKategorilers select new { id = s.Id, kat = s.KategoriAdi });
            foreach(var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[1].Value = k.id;
                Liste.Rows[i].Cells[2].Value = k.kat;
                i++;                
            }
            Liste.AllowUserToAddRows = false;
            Liste.AllowUserToDeleteRows = false;
        }
        void YeniKayit()
        {
            try
            {
                tblKategoriler frm = new tblKategoriler();
                frm.KategoriAdi = txtKategori.Text;
                db.tblKategorilers.InsertOnSubmit(frm);
                db.SubmitChanges();
                txtKategori.Text = "";
                Listele();
            }
            catch (Exception)
            {

                throw;
            }
        }
        void Guncelle()
        {
            try
            {
                tblKategoriler frm = db.tblKategorilers.First(s => s.Id == katId);
                frm.KategoriAdi = txtKategori.Text;
                db.SubmitChanges();
                txtKategori.Text = "";
                katId = -1;
                Listele();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void frmKategori_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }

        private void Liste_Click(object sender, EventArgs e)
        {
            txtKategori.Text = Liste.CurrentRow.Cells[2].Value.ToString();
            katId= int.Parse(Liste.CurrentRow.Cells[1].Value.ToString());
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Kat = Liste.CurrentRow.Cells[2].Value.ToString();
            if (MessageBox.Show(Kat + " " + "isimli kategoriyi silmek istiyormusunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Sil();
            }
        }
        void Sil()
        {
            try
            {
                db.tblKategorilers.DeleteOnSubmit(db.tblKategorilers.First(s => s.KategoriAdi == Kat));
                db.SubmitChanges();
                Listele();
                Kat = "";
                txtKategori.Text="";
                txtKategori.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string deger = "";

            if (Liste.CurrentRow.Cells[0].Value!=null && Liste.CurrentRow.Cells[0].Value != "False")
            {
                deger = Liste.CurrentRow.Cells[0].Value.ToString(); 
            }
            else
            {
                katId = -1;
                deger="False";
            }

            if (deger=="True"&&katId > 0 && MessageBox.Show("Bu kayıt güncellenecektir.\n Onaylıyormusunuz?", "Kayıt Güncelleme.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Guncelle();
            else if (katId == -1 && deger=="False")
                YeniKayit();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
