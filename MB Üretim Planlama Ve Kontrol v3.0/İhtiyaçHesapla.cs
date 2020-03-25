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
    public partial class İhtiyaçHesapla : Form
    {
        #region Metodlar

        public void Erişim(RadioButton x, GroupBox y)
        {
            if (x.Checked == true)
            {
                y.Enabled = true;
            }
            else
                y.Enabled = false;

        }

        #endregion

        #region Tanımlamalar

        int[] A = new int[100];

        int[] B = new int[100];

        #endregion

        #region Değişkenler

        int a1, a2 = 12, hafta1, hafta2;

        double sonuc1, sonuç2, sonuç3, sonuç4, sonuc5,sonuç6, sonuç7, sonuç8, sonuc9, sonuc10, sonuc11, sonuc12,hafta5,hafta6,öncekihafta1,alınacakhafta,n1 = 0, n2, n3, n4,xi, xiyi, xi2, yi,sxy, sx2,a;
        
        #endregion

        public İhtiyaçHesapla()
        {
            InitializeComponent();
        }

        private void İhtiyaçHesapla_Load(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;

            textBox27.Enabled = false;
            textBox28.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control nesne in panel1.Controls)
            {
                a1 = Convert.ToInt32(nesne.Name.Substring(7));
                A[a1-1] = int.Parse(nesne.Text);
            }

            foreach (Control nesne in panel2.Controls)
            {
                B[a2] = int.Parse(nesne.Text); a2--;
            }

            button1.BackColor = Color.White;
            label26.Visible = true;
        }

        #region Hesaplama Yöntemi Seçimi

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Erişim(radioButton3, groupBox3);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Erişim(radioButton4, groupBox4);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Erişim(radioButton5, groupBox5);
        }

        #endregion

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox27.Enabled = true;
                textBox28.Enabled = true;
            }

            else textBox27.Enabled = false;  
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox28.Enabled = true;
            }
        }

        #region İşlemler

        private void button2_Click(object sender, EventArgs e)
        {
            sonuc1 = 0; sonuç2 = 0;

            if (radioButton1.Checked == true)
            {
                öncekihafta1 = int.Parse(textBox27.Text);
                hafta1 = int.Parse(textBox28.Text);

                for (int i = 0; i < hafta1; i++)
                {
                    sonuc1 += A[i];
                    sonuç2 += B[i];
                }

                textBox29.Text = (sonuc1 / (öncekihafta1 + hafta1 - 1)).ToString("F") + " Adet";
                textBox30.Text = (sonuç2 / (öncekihafta1 + hafta1 - 1)).ToString("F") + " Adet";
            }

            else
            {
                hafta1 = int.Parse(textBox28.Text);

                for (int i = 1; i < hafta1; i++)
                {
                    sonuc1 += A[i];
                    sonuç2 += B[i];
                }

                textBox29.Text = (sonuc1 / (hafta1 - 1)).ToString("F") + " Adet".ToString();
                textBox30.Text = (sonuç2 / (hafta1 - 1)).ToString("F") + " Adet".ToString();
            }

            button2.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sonuç3 = 0;
            sonuç4 = 0;

            hafta2 = int.Parse(textBox31.Text);
            alınacakhafta = double.Parse(textBox32.Text);
            for (int i = hafta2 - 1; i >= hafta2 - alınacakhafta; i--)
            {
                sonuç3 += A[i];
                sonuç4 += B[i];

            }

            textBox33.Text= (sonuç3 / alınacakhafta).ToString("F") + " Adet";
            textBox34.Text = (sonuç4 / alınacakhafta).ToString("F") + " Adet";
            button3.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hafta5 = double.Parse(textBox35.Text);

            if (radioButton7.Checked == true)
            {
                n1 = hafta5 - 1;

                for (int i = 1; i < hafta5; i++)  sonuc5 += A[i];

                sonuç6 = sonuc5 * (1 / n1);

                textBox36.Text = sonuç6 + " Adet";
            }

            else if (radioButton6.Checked == true)
            {
                sonuç8 = 0;

                n1 = hafta5 - 1;

                for (int i = 1; i < hafta5; i++)
                {
                    yi += A[i]; // yi ler toplamı
                    xi += i; // xi ler toplamı
                    xiyi += (i * A[i]); // xiyi toplamı
                    xi2 += i * i;
                }

                double x1 = 1.0 / n1;

                double x2 = xi * yi;

                sxy = xiyi - (x1 * x2);

                sx2 = xi2 - ((1 / n1) * Math.Pow(xi, 2));

                a = sxy / sx2;

                sonuç7 = (1 / n1) * (yi - a * xi);

                sonuç8 = a * hafta5 + sonuç7;

                textBox36.Text = sonuç8 + " Adet";
            }

            button4.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            hafta6 = int.Parse(textBox38.Text);

            if (radioButton8.Checked == true)
            {
                n2 = hafta6 - 1;

                for (int i = 1; i < hafta6; i++)  sonuc9 += B[i];

                sonuc10 = sonuc9 * (1 / n2);

                textBox37.Text = sonuc10 + " Adet";
            }

            else if (radioButton9.Checked == true)
            {
                n2 = hafta6 - 1;

                sonuc12 = 0;

                for (int i = 1; i < hafta6; i++)
                {
                    yi += B[i]; // yi ler toplamı
                    xi += i; // xi ler toplamı
                    xiyi += (i * B[i]); // xiyi toplamı
                    xi2 += i * i;
                }

                double x3 = 1.0 / n2;

                double x4 = xi * yi;

                sxy = xiyi - (x3 * x4);

                sx2 = xi2 - ((1 / n2) * Math.Pow(xi, 2));

                a = sxy / sx2;

                sonuc11 = (1 / n2) * (yi - a * xi);

                sonuc12 = a * hafta5 + sonuc11;

                textBox37.Text = sonuc12 + " Adet";
            }
            button5.BackColor = Color.White;
        }

        #endregion
    }
}
