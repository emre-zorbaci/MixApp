using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixApp.Fonksiyonlar
{
    class Numaralar
    {
        Fonksiyonlar.DbFirstDataContext db = new DbFirstDataContext();
        public string CariNumara()
        {
            try
            {
                double numara = double.Parse((from s in db.tblFirmas orderby s.Id descending select s).First().CariKod);
                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;
            }
            catch (Exception)
            {
                return "0000001";
            }
        }
        public string urunNumara()
        {
            try
            {
                int numara = (from s in db.tblUrunlers orderby s.Id descending select s).First().UrunKodu.Value;
                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;//0000111
            }
            catch (Exception)
            {
                return "0000001";
            }
        }
        public string StokGNO()
        {
            try
            {
                int? numara = (from s in db.tblStokGirisUsts orderby s.Id descending select s).First().StokGirisNo;
                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;//0000111
            }
            catch (Exception)
            {
                return "0000001";
            }
        }
        public string SipNo()
        {
            try
            {
                int? numara = (from s in db.tblSiparisUsts orderby s.Id descending select s).First().SiparisNo;
                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;//0000111
            }
            catch (Exception)
            {
                return "0000001";
            }
        }

    }
}
