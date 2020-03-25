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
    public partial class SiparişPartiBüyüklüğü : Form
    {
        #region Metodlar

        public void ilkişlem(double[] x, Panel y)
        {
            a3 = 11;

            foreach (Control nesne in y.Controls)
            {
                nesne.Text = x[a3].ToString();
                a3--;
            }


        }

        #endregion

        #region Tanımlamalar

        double[] AD = new double[12];
        double[] PBD = new double[12];
        double[] BM = new double[12];
        double[] SM = new double[12];
        double[] GOM = new double[12];
        double[] GM = new double[12];
        double[] SMM = new double[12];
        double[] TM = new double[12];
        double[] Bi = new double[12];
        double[] PBD2 = new double[12];
        double[] BM2 = new double[12];
        double[] SM2 = new double[12];
        double[] GOM2 = new double[12];
        double[] GM2 = new double[12];
        double[] SMM2 = new double[12];
        double[] TM2 = new double[12];

        #endregion

        #region Değişkenler

        int a2 = 11; int a3 = 11, a1;

        double x1, x2, x3, h, h2, x4, toplam2 = 0, ihtiyaç, P, p, kfix, m0, n0, kges;

        #endregion

        public SiparişPartiBüyüklüğü()
        {
            InitializeComponent();
        }

        #region İlk Sayfa

        private void SiparişPartiBüyüklüğü_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control nesne in panel1.Controls)
            {
                a1 = Convert.ToInt32(nesne.Name.Substring(7));
                Bi[a1 - 2] = int.Parse(nesne.Text);
            }
            label72.Visible = true;
            groupBox1.Enabled = true;
            button1.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ihtiyaç = double.Parse(textBox1.Text);
            P = double.Parse(textBox14.Text);
            p = double.Parse(textBox15.Text);
            kfix = double.Parse(textBox16.Text);
            button2.BackColor = Color.White;
            groupBox2.Enabled = true;
            label73.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m0 = Math.Sqrt((2 * ihtiyaç * kfix) / (P * (p / 100)));
            n0 = ihtiyaç / m0;
            kges = (kfix * n0) + ((m0 / 2) * P * (p / 100));

            textBox17.Text = m0.ToString();
            textBox18.Text = n0.ToString();
            textBox19.Text = kges.ToString();
            button3.BackColor = Color.White;
            tabControl1.SelectedIndex = 1;
        }

        #endregion

        #region İkinci Sayfa

        private void button4_Click(object sender, EventArgs e)
        {
            #region İlk İşlem

            foreach (Control nesne in panel5.Controls)
            {
                nesne.Text = Bi[a2].ToString();
                a2--;
            }

            foreach (Control nesne in panel7.Controls)
            {
                if (a3 % 2 == 0)
                {
                    nesne.Text = m0.ToString(); PBD[a3] = m0;
                }

                else
                {
                    nesne.Text = "0"; PBD[a3] = 0;

                }

                a3--;
            }

            textBox67.Text = PBD[0].ToString();
            BM[0] = PBD[0];

            for (int i = 0; i < 11; i++)
            {
                SM[i] = (BM[i] - Bi[i]);

                BM[i + 1] = (PBD[i + 1] + SM[i]);
            }
            SM[11] = (BM[11] - Bi[11]);

            int a4 = 11;

            foreach (Control nesne in panel8.Controls)
            {
                nesne.Text = BM[a4].ToString();
                a4--;
            }

            a4 = 11;

            foreach (Control nesne in panel9.Controls)
            {
                nesne.Text = SM[a4].ToString();
                a4--;
            }

            #endregion

            #region İkinci İşlem

            h = p / (100 * 12); x1 = h * P; x2 = x1 / 2;

            a4 = 11;

            foreach (Control nesne in panel15.Controls)
            {
                nesne.Text = (x1 * SM[a4]).ToString();
                GOM[a4] = (x1 * SM[a4]);
                a4--;
            }

            a4 = 11;

            foreach (Control nesne in panel11.Controls)
            {
                nesne.Text = (x2 * Bi[a4]).ToString();
                GM[a4] = (x2 * Bi[a4]);
                a4--;

            }

            a3 = 11;

            foreach (Control nesne in panel12.Controls)
            {
                if (a3 % 2 == 0)
                {
                    nesne.Text = kfix.ToString(); SMM[a3] = kfix;
                }

                else
                {
                    nesne.Text = "0"; SMM[a3] = 0;

                }

                a3--;
            }

            for (int i = 0; i < 12; i++)
            {
                TM[i] = GOM[i] + GM[i] + SMM[i];
            }

            a3 = 11;
            double toplam = 0;
            foreach (Control nesne in panel13.Controls)
            {
                nesne.Text = TM[a3].ToString();
                toplam += TM[a3];
                a3--;
            }

            textBox104.Text = toplam + " TL";
            #endregion
        }

        private void button5_Click(object sender, EventArgs e)
        {
            #region İlk İşlem

            AD[0] = 1;
            a3 = 11;
            foreach (Control nesne in panel14.Controls)
            {
                nesne.Text = Bi[a3].ToString();
                a3--;
            }

            textBox152.Text = "1";
            textBox164.Text = m0.ToString(); PBD2[0] = m0;
            textBox176.Text = m0.ToString(); BM2[0] = m0;
            textBox188.Text = (BM2[0] - Bi[0]).ToString(); SM2[0] = (BM2[0] - Bi[0]);

            for (int i = 0; i < 11; i++)
            {
                if (SM2[i] >= Bi[i + 1])
                {
                    AD[i + 1] = 0;
                    PBD2[i + 1] = 0;
                    BM2[i + 1] = (SM2[i] + PBD2[i + 1]);
                    SM2[i + 1] = BM2[i + 1] - Bi[i + 1];
                }

                else if (SM2[i] < Bi[i + 1])
                {
                    AD[i + 1] = 1;
                    PBD2[i + 1] = m0;
                    BM2[i + 1] = (SM2[i] + PBD2[i + 1]);
                    SM2[i + 1] = BM2[i + 1] - Bi[i + 1];
                }
            }

            ilkişlem(AD, panel16);
            ilkişlem(PBD2, panel18);
            ilkişlem(BM2, panel19);
            ilkişlem(SM2, panel20);

            #endregion

            #region İkinci İşlem

            h2 = p / (100 * 12);

            x3 = h * P;

            x4 = x1 / 2;

            for (int i = 0; i < 12; i++)
            {
                GOM2[i] = x3 * SM2[i];
                GM2[i] = x4 * Bi[i];
            }

            for (int i = 0; i < 11; i++)
            {
                if (AD[i] > 0)
                {
                    SMM2[i] = kfix;
                }

                else if (AD[0] == 0)
                {
                    SMM2[i] = 0;
                }
            }

            ilkişlem(GOM2, panel24);
            ilkişlem(GM2, panel23);
            ilkişlem(SMM2, panel22);

            for (int i = 0; i < 12; i++)
            {
                TM2[i] = GOM2[i] + GM2[i] + SMM2[i];
                toplam2 += TM2[i];
            }

            ilkişlem(TM2, panel21);

            textBox189.Text = toplam2 + " TL";
            #endregion

        }
        #endregion
    }
}
