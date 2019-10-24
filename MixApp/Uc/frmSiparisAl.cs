using MixApp.Fonksiyonlar;
using MixApp.Properties;
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
    public partial class frmSiparisAl : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        Numaralar N = new Numaralar();
        Formlar F = new Formlar();

        bool edit = false;
        int sprId = -1;
        public frmSiparisAl()
        {
            InitializeComponent();
        }
        public string[] MyArray { get; set; }
        private void frmSiparisAl_Load(object sender, EventArgs e)
        {
            txtSiparisNo.Text = N.SipNo();
            combo();
        }
        void Temizle()
        {
            foreach (Control ct in splitContainer1.Panel1.Controls)
            {
                if (ct is TextBox || ct is ComboBox)
                {
                    ct.Text = "";
                }
                txtSiparisNo.Text = N.SipNo();
                Liste.Rows.Clear();
                MainPage.IAktar = -1;
                edit = false;
                sprId = -1;
            }
        }
        void combo()
        {
            txtFirma.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection veri = new AutoCompleteStringCollection();
            var lst = db.tblFirmas.Select(x => x.FirmaAdi).Distinct();
            foreach (string frm in lst)
            {
                veri.Add(frm);
                txtFirma.Items.Add(frm);
            }
            txtFirma.AutoCompleteCustomSource = veri;

            /********************************************/
            urncmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection veri1 = new AutoCompleteStringCollection();
            var lst1 = db.tblUrunlers.Select(x => x.UrunAdi).Distinct();
            foreach (string frm in lst1)
            {
                veri1.Add(frm);
                urncmb.Items.Add(frm);
            }
            urncmb.AutoCompleteCustomSource = veri1;

            try
            {
                int dgv;
                dgv = urncmb.Items.Count;
                MyArray = new string[dgv];
                for (int i = 0; i < dgv; i++)
                {
                    MyArray[i] = urncmb.Items[i].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        void YeniKaydet()
        {
            Liste.AllowUserToAddRows = false;
            try
            {
                tblSiparisUst ust = new tblSiparisUst();
                ust.Atarih = DateTime.Parse(txtStarih.Text);
                ust.FirmaId = txtFirma.Text != "" ? db.tblFirmas.First(x => x.FirmaAdi == txtFirma.Text).Id : -1;
                ust.StokAciklama = txtAciklama.Text;
                ust.SiparisNo = int.Parse(txtSiparisNo.Text);
                db.tblSiparisUsts.InsertOnSubmit(ust);
                db.SubmitChanges();

                string barkod;
                tblSiparisAlt[] alt = new tblSiparisAlt[Liste.RowCount];
                //tblStokDurum[] durum = new tblStokDurum[Liste.RowCount];
                for (int i = 0; i < Liste.RowCount; i++)
                {
                    alt[i] = new tblSiparisAlt();
                    alt[i].Adet = Convert.ToInt32(Liste.Rows[i].Cells[6].Value);
                    alt[i].LotSeriNo = Liste.Rows[i].Cells[3].Value.ToString();
                    alt[i].UrunId = int.Parse(Liste.Rows[i].Cells[0].Value.ToString());
                    alt[i].SiparisNo = int.Parse(txtSiparisNo.Text);

                    db.tblSiparisAlts.InsertOnSubmit(alt[i]);

                    barkod = Liste.Rows[i].Cells[1].Value + "/" + Liste.Rows[i].Cells[3].Value;
                    tblStokDurum sd = db.tblStokDurums.First(x => x.Barkod == barkod);
                    sd.Adet -= int.Parse(Liste.Rows[i].Cells[6].Value.ToString());
                }
                db.SubmitChanges();
                MessageBox.Show("Kayıt Tamam.");
                Temizle();
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt NaTamam.");
            }
        }

        private void Liste_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                TextBox txt = e.Control as TextBox;
                if (Liste.CurrentCell.ColumnIndex == 1 && txt != null)
                {
                    txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txt.AutoCompleteCustomSource.AddRange(MyArray);
                }
                else if (Liste.CurrentCell.ColumnIndex != 1 && txt != null)
                {
                    txt.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Liste_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    foreach (DataGridViewCell cell in Liste.SelectedCells)
                    {
                        if (cell.Value != null)
                        {
                            //string urn = Liste.CurrentRow.Cells[1].Value.ToString();

                            var lst = (from s in db.tblUrunlers
                                       where s.UrunAdi == Liste.CurrentRow.Cells[1].Value.ToString()
                                       select s).First();
                            int id = lst.Id;
                            string acik = lst.Aciklama;
                            if (Liste.CurrentRow != null) Liste.CurrentRow.Cells[0].Value = id;
                            Liste.CurrentRow.Cells[4].Value = acik;
                        }
                        else
                        {
                            MessageBox.Show("Bu alan boş bırakılamaz yada urun listesi haricinde bir giriş yapılamaz.");
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Liste_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Liste.CurrentRow != null && e.ColumnIndex == 2 && Liste.CurrentRow.Cells[1].Value.ToString() != "")
                {
                    var x = Liste.CurrentRow.Index;

                    MainPage.Aktar = Liste.Rows[x].Cells[1].Value.ToString();
                    F.LotBul();
                    var id = MainPage.IAktar;
                    if (id > 0)
                    {
                        LotAc(id);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        void LotAc(int id)
        {
            sprId = id;
            var stok = db.tblStokDurums.First(s => s.Id == sprId);
            if (Liste.CurrentRow != null)
            {
                Liste.CurrentRow.Cells[3].Value = stok.LotSeriNo;
                Liste.CurrentRow.Cells[5].Value = stok.Adet;
            }
        }

        private void Liste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            var btnSip = new Button();
            btnSip.Size = new Size(25, txtSiparisNo.ClientSize.Height + 2);
            btnSip.Location = new Point(txtSiparisNo.ClientSize.Width - btnSip.Width, -1);
            btnSip.Cursor = Cursors.Default;
            btnSip.BackgroundImage = Resources.at1;
            btnSip.BackgroundImageLayout = ImageLayout.Stretch;
            btnSip.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            txtSiparisNo.Controls.Add(btnSip);
            base.OnLoad(e);
            btnSip.Click += btnSip_Click;
        }

        private void btnSip_Click(object sender, EventArgs e)
        {
            F.SiparisAlListe();
            int id = MainPage.IAktar;
            if (id > 0)
            {
                SipAc(id);
            }
            MainPage.IAktar = -1;
        }

        private void SipAc(int id)
        {
            try
            {
                int i = 0;
                edit = true;
                sprId = id;
                tblSiparisUst ust = db.tblSiparisUsts.First(x => x.SiparisNo == sprId);
                txtFirma.Text = ust.tblFirma.FirmaAdi;
                txtStarih.Text = ust.Atarih.ToString();
                txtAciklama.Text = ust.StokAciklama;
                txtSiparisNo.Text = sprId.ToString().PadLeft(7, '0');

                var srg = from s in db.tblSiparisAlts
                          where s.SiparisNo == sprId
                          select s;
                foreach (var k in srg)
                {
                    Liste.Rows.Add();
                    Liste.Rows[i].Cells[0].Value = k.tblUrunler.Id;
                    Liste.Rows[i].Cells[1].Value = k.tblUrunler.UrunAdi;

                    Liste.Rows[i].Cells[3].Value = k.LotSeriNo;
                    Liste.Rows[i].Cells[4].Value = k.tblUrunler.Aciklama;
                    Liste.Rows[i].Cells[6].Value = k.Adet;


                    //ListeIlk.Rows.Add();
                    //ListeIlk.Rows[i].Cells[0].Value = k.tblUrunler.Id;
                    //ListeIlk.Rows[i].Cells[1].Value = k.tblUrunler.UrunAdi;
                    //ListeIlk.Rows[i].Cells[2].Value = k.tblUrunler.Aciklama;
                    //ListeIlk.Rows[i].Cells[3].Value = k.LotSeriNo;
                    //ListeIlk.Rows[i].Cells[4].Value = k.Adet;
                    i++;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            YeniKaydet();
        }
    }
}
