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
    public partial class frmUrunListesi : Form
    {
        Fonksiyonlar.DbFirstDataContext db = new Fonksiyonlar.DbFirstDataContext();

        int secimId = -1;
        public frmUrunListesi()
        {
            InitializeComponent();
        }

        private void frmUrunListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from s in db.tblUrunlers where s.UrunAdi.Contains(txtBul.Text) select s).ToList();
            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Id;
                Liste.Rows[i].Cells[1].Value = k.UrunKodu;
                Liste.Rows[i].Cells[2].Value = k.UrunAdi;
                //Liste.Rows[i].Cells[3].Value = k.SeriLotNo;
                Liste.Rows[i].Cells[4].Value = k.tblMarkalar.MarkaAdi;
                Liste.Rows[i].Cells[5].Value = k.tblKategoriler.KategoriAdi;
                i++;
            }
            Liste.AllowUserToAddRows = false;
        }
        void Sec()
        {
            try
            {
                secimId = int.Parse(Liste.CurrentRow.Cells[1].Value.ToString());
            }
            catch (Exception)
            {

                secimId = -1;
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if (secimId > 0)
            {
                MainPage.IAktar = secimId;
                Close();
            }
        }
    }
}
