using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MB_Üretim_Planlama_Ve_Kontrol_v3._0
{
    public partial class Form1 : Form
    {
        #region DLL Import

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
         );

        #endregion
        

        #region Metodlar

        public void formaç(Form x)
        {
            this.Hide();
            x.ShowDialog();
            this.Show();
        }

        #endregion

        #region Tanımlamalar

        İhtiyaçHesapla newih = new İhtiyaçHesapla();
        SiparişPartiBüyüklüğü newsbh = new SiparişPartiBüyüklüğü();
        DolaşımAkışÇizelgeleme1 newdç1 = new DolaşımAkışÇizelgeleme1();
        DolaşımAkışÇizelgeleme2 newdç2 = new DolaşımAkışÇizelgeleme2();

        #endregion

        public Form1()
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 767, 451, 15, 15));
            InitializeComponent();
        }

        #region Picturebox ArkaPlan Animasyonu

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.CadetBlue;
            panel1.BackColor = Color.CadetBlue;
            
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            panel1.BackColor = Color.White;
            label1.BackColor = Color.Transparent;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.CornflowerBlue;
            
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
            panel2.BackColor = Color.White;
            label2.BackColor = Color.Transparent;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.DarkCyan;
            panel3.BackColor = Color.DarkCyan;
            
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
            panel3.BackColor = Color.White;
            label3.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Red;
            panel4.BackColor = Color.Red;
           
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
            panel4.BackColor = Color.White;
            label4.BackColor = Color.Transparent;
        }

        #endregion

        #region Click Olayı

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            formaç(newih);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            formaç(newsbh);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            formaç(newdç1);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            formaç(newdç2);
        }

        #endregion

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}