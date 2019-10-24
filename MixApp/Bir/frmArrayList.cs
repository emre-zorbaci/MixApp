using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MixApp.Bir
{
    public partial class frmArrayList : Form
    {
        public frmArrayList()
        {
            InitializeComponent();
            label2.Click += new EventHandler(Label2_Click);
            button1.Click += new EventHandler(Abdullah);
        }

        private void btnArray_Click(object sender, EventArgs e)
        {
            int[] Sayilar = new int[5];
            Sayilar[0] = 10;
            Sayilar[1] = 12;
            Sayilar[2] = 15;
            Sayilar[3] = 18;
            Sayilar[4] = 20;
            lstData.Items.Clear();
            foreach (int sayi in Sayilar)
            {
                lstData.Items.Add(sayi);
            }
        }

        private void btnArrayList_Click(object sender, EventArgs e)
        {
            ArrayList arrayDizi = new ArrayList();
            arrayDizi.Add(2);
            arrayDizi.Add(11);
            arrayDizi.Add(15);
            arrayDizi.Add(18);
            arrayDizi.Add("Onur");
            arrayDizi.Add("Çorum");
            
            lstData.Items.Clear();

            arrayDizi.RemoveAt(2);
            foreach (object eleman in arrayDizi)
            {
                lstData.Items.Add(eleman);
            }
            MainPage.Aaktar = arrayDizi;
            IlkFormum ilk = new IlkFormum();
            Close();
            ilk.Show();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<object> Lst = new List<object>();
            Lst.Add(1);
            Lst.Add(10);
            Lst.Add(15);
            Lst.Add("Selin");
            Lst.Add("İstanbul");
            Lst.Add(8);
            
            lstData.Items.Clear();
            foreach (var eleman in Lst)
            {
                lstData.Items.Add(eleman);
            }
            MainPage.Laktar = Lst;
            
            IlkFormum ilk = new IlkFormum();
            Close();
            ilk.Show();
            

        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<Button> Dugmeler = new List<Button>();
            for (int i = 0; i < 7; i++)
            {
                Button btn = new Button();
                btn.Text = ("Görev " + i);
                btn.Name = "btn" + i;
                Dugmeler.Add(btn);
                btn.Click += new EventHandler(btnList3_Click);
                flowLayoutPanel1.Controls.Add(Dugmeler[i]);
            }
        }
        private void btnList3_Click(object sender,EventArgs e)
        {
            Button btn=(Button)sender;
            if(btn.Name=="btn0")
            {
                MessageBox.Show("Test0");
            }else
            if(btn.Name=="btn1")
            {
                MessageBox.Show("Test1");
            }

        }
        private void Label2_Click(object sender, EventArgs e)
        {
            
                MessageBox.Show("Label düğme oldu");
           
        }
        private void Abdullah(object sender, EventArgs e)
        {
            
                MessageBox.Show("Label düğme oldu");
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" düğme oldu");
        }

        private void frmArrayList_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainPage.Kontrol = false;
        }
    }
}
