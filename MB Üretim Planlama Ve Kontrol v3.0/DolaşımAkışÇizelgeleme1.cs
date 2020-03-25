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
    public partial class DolaşımAkışÇizelgeleme1 : Form
    {
        #region Değişkenler

        double gs, stg, itg, vs, vçs, miktar,tr1, tr2, tp1, tp2, te1, te2, th1, th2,zdf1, zdf2, zdl1, zdl2;

        double d1, s1, g1, d2, s2, g2,x1, x2, x3, x4, x5, x6, x7, x8;

        #endregion

        public DolaşımAkışÇizelgeleme1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gs = double.Parse(textBox1.Text) * 60;
            stg = double.Parse(textBox5.Text);
            itg = double.Parse(textBox6.Text);
            vs = double.Parse(textBox2.Text);
            vçs = double.Parse(textBox3.Text) * 60;
            miktar = double.Parse(textBox4.Text);


            tr1 = double.Parse(textBox7.Text);
            tr2 = double.Parse(textBox14.Text);
            tp1 = double.Parse(textBox8.Text);
            tp2 = double.Parse(textBox13.Text);
            te1 = double.Parse(textBox9.Text);
            te2 = double.Parse(textBox12.Text);
            th1 = double.Parse(textBox10.Text);
            th2 = double.Parse(textBox11.Text);

            button2.BackColor = Color.White;
            label29.Visible = true;
            groupBox1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            zdf1 = tr1 + (miktar * (te1 + tp1 + th1));
            zdf2 = tr2 + (miktar * (te2 + tp2 + th2));

            textBox15.Text = zdf1 + " Dk";
            textBox24.Text = zdf2 + " Dk";

            zdl1 = zdf1;
            zdl2 = gs + zdf2;

            textBox16.Text = zdl1 + " Dk";
            textBox23.Text = zdl2 + " Dk";

            d1 = zdl1;
            s1 = zdl1 / 60;
            g1 = zdl1 / vçs;

            d2 = zdl2;
            s2 = zdl2 / 60;
            g2 = zdl2 / vçs;

            textBox17.Text = d1.ToString();
            textBox18.Text = s1.ToString("F");
            textBox19.Text = g1.ToString("F");

            textBox22.Text = d2.ToString();
            textBox21.Text = s2.ToString("F");
            textBox20.Text = g2.ToString("F");


            textBox28.Text = stg.ToString();

            x1 = stg - g2 + 1;


            textBox27.Text = x1.ToString("F");

            x2 = Math.Truncate(x1);


            if (x1 - x2 == 0)
            {
                x3 = x2 - 1;
                textBox26.Text = x3.ToString();
            }

            else
            {
                x3 = x1;
                textBox26.Text = x3.ToString("F");
            }

            x4 = x3 - g1;

            textBox25.Text = x4.ToString("F");

            textBox32.Text = itg.ToString();

            x5 = itg + g1;

            textBox31.Text = x5.ToString("F");

            x6 = Math.Truncate(x5);

            if (x5 - x6 == 0)
            {
                x7 = x6 + 1;
                textBox30.Text = x7.ToString();
            }

            else
            {
                x7 = x5;
                textBox30.Text = x7.ToString("F");

            }

            x8 = x7 + g2;

            textBox29.Text = x8.ToString("F");
        }

        private void DolaşımAkışÇizelgeleme1_Load(object sender, EventArgs e)
        {

        }
    }
}
