using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MB_Üretim_Planlama_Ve_Kontrol_v3._0
{
    public partial class DolaşımAkışÇizelgeleme2 : Form
    {
        #region Metodlar

        public void değişkenler1()
        {
            x1 = 3;
            x2 = 0;
            y1 = 50;
            y2 = 100;

        }

        public void değişkenler2()
        {
            x1 = 3;
            x2 = 0;
            y1 = 0;
            y2 = 100;


        }

        public void işlem1(TextBox[] x8, GroupBox y)
        {
          
            foreach (Control nesne in y.Controls)
            {
                a3 = Convert.ToInt32(nesne.Name.Substring(3));
                x8[a3] = (TextBox)nesne;
            }
        
        }

        public void işlem2(int i,int j)
        {
            if (txxx1[i].Text != "")
            {
                txxx1[i + 4].Text = (double.Parse(txxx1[i - 3].Text) + double.Parse(txxx1[i+3].Text)).ToString();
                txxx1[i + 5].Text = (double.Parse(txxx1[i + 2].Text) + double.Parse(txxx1[i+4].Text)).ToString();

                txxx1[i + 6].Text = txxx1[i-1].Text;

                günoran = double.Parse(txxx1[i+5].Text) / işgkap;

                if (günoran == 1 || günoran == 2 || günoran == 3 || günoran == 4 || günoran == 5 || günoran == 6 || günoran == 7)
                {
                    txxx1[i + 7].Text = (double.Parse(txxx1[j].Text) + günoran).ToString();
                }

                else
                {
                    txxx1[i + 7].Text = (double.Parse(txxx1[j].Text) + günoran).ToString();
                }

            }
        
        }

        public void işlem3(int i, int j)
        { 
          if (txxx1[i].Text != "")
                {
                    txxx1[i+5].Text = ((double.Parse(txxx1[i+2].Text)) + (double.Parse(txxx1[i+4].Text))).ToString();
                    txxx1[i+6].Text = başgün.ToString();

                    günoran = double.Parse(txxx1[i+5].Text) / işgkap;

                    if (günoran == 1 || günoran == 2 || günoran == 3 || günoran == 4 || günoran == 5 || günoran == 6 || günoran == 7 )
                    {
                        txxx1[i+7].Text = (double.Parse(txxx1[j].Text) + 1).ToString();
                    }

                    else
                    {
                        txxx1[i+7].Text = (double.Parse(txxx1[j].Text) + günoran).ToString();
                    }

                }
        
        }

        public void işlem4(int i, int j)
        {
            işlem3(i, j); işlem2(i + 8, j); işlem2(i + 16, j); işlem2(i + 24, j); işlem2(i + 32, j);
        }

        public void işlem5(int k, int m, int n, int p)
        {
            for (int i = 0; i < 5; i++)
            {
                sipariş3[k, 0] = double.Parse(txxx1[m].Text);
                sipariş3[k, 1] = double.Parse(txxx1[n].Text);
                sipariş33[k] = char.Parse(txxx1[p].Text);
                k += 1; m += 8; n += 8; p += 8;

            }
        
        }

        #endregion

        #region Tanımlamalar

        TextBox[] txxx1 = new TextBox[1000];
        

        double[,] sipariş1 = new double[5, 2];
        double[,] sipariş2 = new double[5, 2];
        double[,] sipariş3 = new double[5, 2];
        double[,] sipariş4 = new double[5, 2];
        double[,] sipariş5 = new double[5, 2];
        double[,] sipariş6 = new double[5, 2];

        char[] sipariş11 = new char[5];
        char[] sipariş22 = new char[5];
        char[] sipariş33 = new char[5];
        char[] sipariş44 = new char[5];
        char[] sipariş55 = new char[5];
        char[] sipariş66 = new char[5];



        #endregion

        #region Değişkenler

        double başgün, başsaat, zue, süs, iigs, işgkap,a1, a2 = 0,günoran;
        
        int x1, x2, x3, y1, y2, y3, y4,say = 0, a3 = 0;
        
        #endregion

        public DolaşımAkışÇizelgeleme2()
        {
            InitializeComponent();
        }

        private void DolaşımAkışÇizelgeleme2_Load(object sender, EventArgs e)
        {
            işlem1(txxx1, groupBox3);
            işlem1(txxx1, groupBox4);
            işlem1(txxx1, groupBox5);
            işlem1(txxx1, groupBox6);
            işlem1(txxx1, groupBox7);
            işlem1(txxx1, groupBox8);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                başsaat = double.Parse(textBox1.Text);
                başgün = double.Parse(textBox2.Text);
                işgkap = double.Parse(textBox3.Text);
                süs = double.Parse(textBox4.Text);
                zue = double.Parse(textBox5.Text);
                iigs = double.Parse(textBox6.Text);

                label31.Visible = true;
                button3.BackColor = Color.White;

                #region GroupBox Aç
                a2 = 0;
                a1 = 6 - süs;

                if (süs>6)
                {
                    MessageBox.Show("Sipariş Ünitesi Sayınız Geçerli Bir Değer Değil.1 ile 6 Arasında Bir Değer Giriniz. ");
                }

                else
                {
                    groupBox2.Enabled = true;
                    foreach (Control nesne in groupBox2.Controls)
                    {
                        if (nesne is GroupBox)
                        {
                            if (a2 < a1)
                            {
                                nesne.Enabled = false;
                                a2++;
                            }

                            else nesne.Enabled = true; 
                        }
                    }
                }
                #endregion
            }

            else
            {
                MessageBox.Show("Boş kalan kısımlar var.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region İlk Sipariş Geçiş

            for (int i = 4; i < 205; i = i + 40)
            {
                txxx1[i].Text = iigs.ToString();
            }
            #endregion

            #region İlk Sipariş Başlangıç

            for (int i = 5; i < 206; i = i + 40)
            {
                txxx1[i].Text = iigs.ToString();
            }

            #endregion

            #region ZUE Değeri

            int q1 = 0;

            for (int i = 12; i < 237; i = i + 8)
            {
                txxx1[i].Text = zue.ToString();
                q1++;
                if (q1 % 4 == 0)
                {
                    i += 8;
                    q1 = 0;
                }
            }
            #endregion

            #region İş İstasyonları

            if (groupBox3.Enabled == true) işlem4(1, 7);

            if (groupBox4.Enabled == true) işlem4(41, 47);

            if (groupBox5.Enabled == true) işlem4(81, 87);

            if (groupBox6.Enabled == true) işlem4(121, 127);

            if (groupBox7.Enabled == true) işlem4(161, 167);

            if (groupBox8.Enabled == true) işlem4(201, 207);

            #endregion

            #region Sipariş Aktar

            işlem5(0, 1, 3, 2);

            işlem5(0, 41, 43, 42);

            işlem5(0, 81, 83, 82);

            işlem5(0, 121, 123, 122);

            işlem5(0, 161, 163, 162);

            işlem5(0, 201, 203, 202);

            #endregion
        }
    }
}
