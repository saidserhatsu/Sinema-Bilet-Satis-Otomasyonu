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
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }
        int sayac = 5;
        private void Intro_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac--;
            label1.Text = sayac.ToString() + " Saniye sonra açılacak";
            progressBar1.Value += 20;
            if (sayac==0)
            {
                timer1.Stop();
                GirisEkrani grs = new GirisEkrani();
                grs.Show();
                this.Hide();
            }
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            GirisEkrani grs = new GirisEkrani();
            grs.Show();
            this.Hide();
        }
    }
}
