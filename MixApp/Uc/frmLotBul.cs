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

namespace MixApp.Uc
{
    public partial class frmLotBul : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        Numaralar N = new Numaralar();
        Formlar F = new Formlar();

        int secimId = -1;

        public frmLotBul()
        {
            InitializeComponent();
        }

        private void frmLotBul_Load(object sender, EventArgs e)
        {
            txtUrun.Text = MainPage.Aktar;
            Listele();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = from s in db.tblStokDurums
                      where s.tblUrunler.UrunAdi == txtUrun.Text
                      where s.Adet != 0
                      select s;
            foreach(var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Id;
                Liste.Rows[i].Cells[1].Value = k.tblUrunler.UrunAdi;
                Liste.Rows[i].Cells[2].Value = k.LotSeriNo;
                Liste.Rows[i].Cells[3].Value = k.Adet;
                i++;                
            }
        }
        void Sec()
        {
            try
            {
                secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                secimId = -1;
            }
        }
        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if(secimId>0)
            {
                MainPage.IAktar = secimId;
                Close();
            }
        }
    }
}
