using MixApp.Fonksiyonlar;
using MixApp.Stok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixApp.Print
{
    public partial class frmPrint : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        public string HangiForm;
        public frmPrint()
        {
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            switch (HangiForm)
            {
                case "StokGiris":
                    StokGiris();
                    break;
                default:
                    break;
            }
        }

        private void StokGiris()
        {
            frmStokGiris stk = Application.OpenForms["frmStokGiris"] as frmStokGiris;
            rStokGiris rsg = new rStokGiris();
            var lst = (from s in db.vwStokGiris
                      where s.StokGirisNo == int.Parse(MainPage.Aktar)
                      select s).ToList();
            if(lst!=null)
            {
                PrintYardim ch = new PrintYardim();
                DataTable dt = ch.ConvertTo(lst);
                rsg.SetDataSource(dt);
                crvPrint.ReportSource = rsg;
            }
            MainPage.Aktar = "";
        }
    }
}
