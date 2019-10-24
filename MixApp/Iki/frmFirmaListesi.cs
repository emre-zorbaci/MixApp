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
    public partial class frmFirmaListesi : Form
    {
        Fonksiyonlar.DbFirstDataContext db = new Fonksiyonlar.DbFirstDataContext();

        int secimId = -1;
        public frmFirmaListesi()
        {
            InitializeComponent();
        }

        private void frmFirmaListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from s in db.tblFirmas where s.FirmaAdi.Contains(txtBul.Text) select s).ToList();
            foreach(var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.CariKod;
                Liste.Rows[i].Cells[1].Value = k.FirmaAdi;
                Liste.Rows[i].Cells[2].Value = k.Yetkili;
                Liste.Rows[i].Cells[3].Value = k.Tel;
                i++;
            }
            Liste.AllowUserToAddRows = false;
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
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

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();            
        }
    }
}
