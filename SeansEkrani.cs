using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Bilet_Satis_Otomasyonu
{
    public partial class SeansEkrani : Form
    {
        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=biletsatisotomasyonuDB.accdb");
        OleDbDataAdapter Veri_Adaptor;
        DataTable tablo = new DataTable();
        public SeansEkrani()
        {
            InitializeComponent();
        }

        private void SeansEkrani_Load(object sender, EventArgs e)
        {
            tablo.Rows.Clear();
            dataGridView1.Refresh();
            Veri_Adaptor = new OleDbDataAdapter("select * From SeansBilgileri", Veritabani_Baglanti);
            Veri_Adaptor.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
    }
}
