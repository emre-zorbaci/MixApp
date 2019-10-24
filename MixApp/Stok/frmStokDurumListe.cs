using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixApp.Stok
{
    public partial class frmStokDurumListe : Form
    {
        Fonksiyonlar.DbFirstDataContext db = new Fonksiyonlar.DbFirstDataContext();
        public frmStokDurumListe()
        {
            InitializeComponent();
        }

        private void frmStokDurumListe_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from s in db.tblStokDurums where s.tblUrunler.UrunAdi.Contains(txtBul.Text) select s).ToList();
            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Id;
                Liste.Rows[i].Cells[1].Value = k.Barkod;
                Liste.Rows[i].Cells[2].Value = k.tblUrunler.UrunAdi;
                Liste.Rows[i].Cells[3].Value = k.tblUrunler.Aciklama;
                Liste.Rows[i].Cells[4].Value = k.LotSeriNo;
                Liste.Rows[i].Cells[5].Value = k.Adet;
                i++;
            }
            Liste.AllowUserToAddRows = false;
        }
    }
}
