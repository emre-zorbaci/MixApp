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
    public partial class frmSiparisAlListe : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        int secimId = -1;
        public frmSiparisAlListe()
        {
            InitializeComponent();
        }

        private void frmSiparisAlListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from s in db.tblSiparisUsts where s.tblFirma.FirmaAdi.Contains(txtBul.Text) select s).ToList().OrderByDescending(x=>x.Atarih);
            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Id;
                Liste.Rows[i].Cells[1].Value = k.SiparisNo;
                Liste.Rows[i].Cells[2].Value = k.tblFirma.FirmaAdi;
                Liste.Rows[i].Cells[3].Value = k.Atarih;
               
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

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if(secimId>0)
            {
                MainPage.IAktar = secimId;
                Close();
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
