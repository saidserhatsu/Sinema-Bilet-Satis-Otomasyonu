using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Bilet_Satis_Otomasyonu
{
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KayitEkrani ff = new KayitEkrani();
            ff.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email="";
            string kullanicisifre="";
            if (textBox1.Text ==email && textBox2.Text == kullanicisifre)
            {
                BiletSatisEkrani bse = new BiletSatisEkrani();
                bse.Show();
            }
            else
            {
                MessageBox.Show("Email veya şifre hatalı");
            }
        }
    }
}
