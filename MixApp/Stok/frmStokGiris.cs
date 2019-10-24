using MixApp.Fonksiyonlar;
using MixApp.Print;
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

namespace MixApp.Stok
{
    public partial class frmStokGiris : Form
    {
        DbFirstDataContext db = new DbFirstDataContext();
        Numaralar N = new Numaralar();
        Formlar F = new Formlar();

        bool edit = false;
        int stkId = -1;
        public frmStokGiris()
        {
            InitializeComponent();
        }
        public string[] MyArray { get; set; }

        private void frmStokGiris_Load(object sender, EventArgs e)
        {
            Combo();
            txtStokGirisNo.Text = N.StokGNO();
        }
        private void Combo()
        {
            //txtFirma.ValueMember = "Id";
            //txtFirma.DisplayMember = "FirmaAdi";
            //txtFirma.DataSource = db.tblFirmas.ToList();
            //txtFirma.SelectedIndex = -1;

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

        void Yenikaydet()
        {
            Liste.AllowUserToAddRows = false;
            try
            {
                tblStokGirisUst ust = new tblStokGirisUst();
                ust.Atarih = DateTime.Parse(txtStarih.Text);
                ust.StokAciklama = txtAciklama.Text;
                ust.StokGirisNo = int.Parse(txtStokGirisNo.Text);
                ust.FirmaId = txtFirma.Text != "" ? db.tblFirmas.First(x => x.FirmaAdi == txtFirma.Text).Id : -1;

                //tblStokGirisUst ust1 = new tblStokGirisUst
                //{
                //    Atarih = DateTime.Parse(txtStarih.Text),
                //    StokAciklama = txtAciklama.Text,
                //    StokGirisNo = int.Parse(txtStokGirisNo.Text),
                //    FirmaId = txtFirma.Text != "" ? db.tblFirmas.First(x => x.FirmaAdi == txtFirma.Text).Id : -1,
                //};
                db.tblStokGirisUsts.InsertOnSubmit(ust);
                db.SubmitChanges();

                int uid;
                string barkod;
                tblStokGirisAlt[] alt = new tblStokGirisAlt[Liste.RowCount];
                tblStokDurum[] durum = new tblStokDurum[Liste.RowCount];
                for (int i = 0; i < Liste.RowCount; i++)
                {    
                    uid= int.Parse(Liste.Rows[i].Cells[0].Value.ToString());
                    barkod = Liste.Rows[i].Cells[1].Value + "/" + Liste.Rows[i].Cells[3].Value;
                    alt[i] = new tblStokGirisAlt();
                    alt[i].StokGirisNo = int.Parse(txtStokGirisNo.Text);
                    alt[i].UrunId = uid;
                    alt[i].LotSeriNo = Liste.Rows[i].Cells[3].Value.ToString();
                    alt[i].Adet = int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                    db.tblStokGirisAlts.InsertOnSubmit(alt[i]);

                    durum[i] = new tblStokDurum();
                    var srg = (from s in db.tblStokDurums
                              where s.Barkod == barkod
                              select s).ToList();

                    if(srg.Count==0)
                    {
                        durum[i].UrunId = uid;
                        durum[i].LotSeriNo= Liste.Rows[i].Cells[3].Value.ToString();
                        durum[i].Adet= int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                        durum[i].Barkod = barkod;
                        db.tblStokDurums.InsertOnSubmit(durum[i]);
                        
                    }
                    else
                    {
                        tblStokDurum sd = db.tblStokDurums.First(x => x.Barkod == barkod);
                        sd.Adet+= int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                    }

                    db.SubmitChanges();
                }               

            }
            catch (Exception)
            {

                throw;
            }
        }
        void Guncelle()
        {
            Liste.AllowUserToAddRows = false;
            ListeIlk.AllowUserToAddRows = false;
            edit = true;
            tblStokGirisUst ust = db.tblStokGirisUsts.First(x => x.StokGirisNo == int.Parse(txtStokGirisNo.Text));
            ust.Atarih = DateTime.Parse(txtStarih.Text);
            ust.FirmaId = txtFirma.Text != "" ? db.tblFirmas.First(x => x.FirmaAdi == txtFirma.Text).Id : -1;
            ust.StokAciklama = txtAciklama.Text;
            db.SubmitChanges();

            int uid;
            string barkod;

            for (int i = 0; i < ListeIlk.RowCount; i++)
            {
                barkod = ListeIlk.Rows[i].Cells[1].Value + "/" + ListeIlk.Rows[i].Cells[3].Value;
                tblStokDurum sd = db.tblStokDurums.First(x => x.Barkod == barkod);
                sd.Adet-= int.Parse(ListeIlk.Rows[i].Cells[4].Value.ToString());
            }
            
            db.tblStokGirisAlts.DeleteAllOnSubmit(db.tblStokGirisAlts.Where(x=>x.StokGirisNo==int.Parse(txtStokGirisNo.Text)));
            db.SubmitChanges();

            DbFirstDataContext gb = new DbFirstDataContext();

            

            tblStokGirisAlt[] alt = new tblStokGirisAlt[Liste.RowCount];
            tblStokDurum[] durum = new tblStokDurum[Liste.RowCount];

            for (int i = 0; i < Liste.RowCount; i++)
            {
                uid = int.Parse(Liste.Rows[i].Cells[0].Value.ToString());
                barkod = Liste.Rows[i].Cells[1].Value + "/" + Liste.Rows[i].Cells[3].Value;

                alt[i] = new tblStokGirisAlt();
                alt[i].StokGirisNo = int.Parse(txtStokGirisNo.Text);
                alt[i].UrunId = uid;
                alt[i].LotSeriNo = Liste.Rows[i].Cells[3].Value.ToString();
                alt[i].Adet = int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                gb.tblStokGirisAlts.InsertOnSubmit(alt[i]);

                durum[i] = new tblStokDurum();
                var srg = (from s in gb.tblStokDurums
                           where s.Barkod == barkod
                           select s).ToList();

                if (srg.Count == 0)
                {
                    durum[i].UrunId = uid;
                    durum[i].LotSeriNo = Liste.Rows[i].Cells[3].Value.ToString();
                    durum[i].Adet = int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                    durum[i].Barkod = barkod;
                    gb.tblStokDurums.InsertOnSubmit(durum[i]);                   
                }
                else
                {
                    tblStokDurum sd = gb.tblStokDurums.First(x => x.Barkod == barkod);
                    int? adt = sd.Adet;
                    sd.Adet =adt + int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                    gb.SubmitChanges();
                }
                gb.SubmitChanges();
            }
            MessageBox.Show("Güncelleme yapıldı");
            Close();
            F.StokGiris();
        }
        protected override void OnLoad(EventArgs e)
        {
            var btnStk = new Button();
            btnStk.Size = new Size(25, txtStokGirisNo.ClientSize.Height + 2);
            btnStk.Location = new Point(txtStokGirisNo.ClientSize.Width - btnStk.Width, -1);
            btnStk.Cursor = Cursors.Default;
            btnStk.BackgroundImage = Resources.at1;
            btnStk.BackgroundImageLayout = ImageLayout.Stretch;
            btnStk.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            txtStokGirisNo.Controls.Add(btnStk);
            base.OnLoad(e);
            btnStk.Click += btnStk_Click;
        }

        private void btnStk_Click(object sender,EventArgs e)
        {
            F.StkListe();
            int id = MainPage.IAktar;
            if(id>0)
            {
                StkGirisAc(id);
            }
            MainPage.IAktar = -1; 
        }

        private void StkGirisAc(int id)
        {
            try
            {
                int i = 0;
                edit = true;
                stkId = id;
                tblStokGirisUst ust = db.tblStokGirisUsts.First(x => x.StokGirisNo == stkId);
                txtFirma.Text = ust.tblFirma.FirmaAdi;
                txtStarih.Text = ust.Atarih.ToString();
                txtAciklama.Text = ust.StokAciklama;
                txtStokGirisNo.Text = stkId.ToString().PadLeft(7, '0');

                var srg = from s in db.tblStokGirisAlts
                          where s.StokGirisNo == stkId
                          select s;
                foreach(var k in srg)
                {
                    Liste.Rows.Add();
                    Liste.Rows[i].Cells[0].Value = k.tblUrunler.Id;
                    Liste.Rows[i].Cells[1].Value = k.tblUrunler.UrunAdi;
                    Liste.Rows[i].Cells[2].Value = k.tblUrunler.Aciklama;
                    Liste.Rows[i].Cells[3].Value = k.LotSeriNo;
                    Liste.Rows[i].Cells[4].Value = k.Adet;

                    ListeIlk.Rows.Add();
                    ListeIlk.Rows[i].Cells[0].Value = k.tblUrunler.Id;
                    ListeIlk.Rows[i].Cells[1].Value = k.tblUrunler.UrunAdi;
                    ListeIlk.Rows[i].Cells[2].Value = k.tblUrunler.Aciklama;
                    ListeIlk.Rows[i].Cells[3].Value = k.LotSeriNo;
                    ListeIlk.Rows[i].Cells[4].Value = k.Adet;
                    i++;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmStokGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
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
                            Liste.CurrentRow.Cells[2].Value = acik;
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (edit) Guncelle();
            else if(edit==false) Yenikaydet();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Yazdir();
        }

        private void Yazdir()
        {
            frmPrint prnt = new frmPrint();
            prnt.HangiForm = "StokGiris";
            MainPage.Aktar = txtStokGirisNo.Text;
            prnt.Show();
        }
    }
}
