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
    public partial class BiletSatisEkrani : Form
    {
        public BiletSatisEkrani()
        {
            InitializeComponent();
        }

        private void BiletSatisEkrani_Load(object sender, EventArgs e)
        {
            label1.Text = GirisEkrani.id.ToString();
        }
    }
}
