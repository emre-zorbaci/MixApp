using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MixApp.Bir;
using MixApp.Iki;
using MixApp.Stok;
using MixApp.Uc;

namespace MixApp.Fonksiyonlar
{
    class Formlar
    {
        public void IlkForm()
        {
            IlkFormum frm = new IlkFormum();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        public void FirmaForm()
        {
            frmFirma frm = new frmFirma();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            MainPage.Kontrol = true;
            frm.Show();
        }
        public void FrmListe()
        {
            frmFirmaListesi frm = new frmFirmaListesi();
            //frm.MdiParent = Form.ActiveForm;
            //frm.WindowState = FormWindowState.Maximized;
            //MainPage.Kontrol = true;
            frm.ShowDialog();
        }
        public void UrunForm()
        {
            frmUrun frm = new frmUrun();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            MainPage.Kontrol = true;
            frm.Show();
        }
        public void UrnListe()
        {
            frmUrunListesi frm = new frmUrunListesi();
            //frm.MdiParent = Form.ActiveForm;
            //frm.WindowState = FormWindowState.Maximized;
            //MainPage.Kontrol = true;
            frm.ShowDialog();
        }
        public void KatListe()
        {
            frmKategori frm = new frmKategori();
            MainPage.Kontrol = true;
            frm.ShowDialog();
        }
        public void StokGiris()
        {
            frmStokGiris frm = new frmStokGiris();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            MainPage.Kontrol = true;
            frm.Show();
        }
        public void StkListe()
        {
            frmStokGirisListe frm = new frmStokGirisListe();
            MainPage.Kontrol = true;
            frm.ShowDialog();
        }
        public void StkDurum()
        {
            frmStokDurumListe frm = new frmStokDurumListe();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            MainPage.Kontrol = true;
            frm.Show();
        }
        public void SprAl()
        {
            frmSiparisAl frm = new frmSiparisAl();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            MainPage.Kontrol = true;
            frm.Show();
        }
        public void LotBul()
        {
            frmLotBul frm = new frmLotBul();
            MainPage.Kontrol = true;
            frm.ShowDialog();
        }
        public void SiparisAlListe()
        {
            frmSiparisAlListe frm = new frmSiparisAlListe();
            //MainPage.Kontrol = true;
            frm.ShowDialog();
        }
    }
}
