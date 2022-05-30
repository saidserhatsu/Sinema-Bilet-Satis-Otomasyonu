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
    public partial class GirisEkrani : Form
    {
        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=biletsatisotomasyonuDB.accdb");
        OleDbDataAdapter Veri_Adaptor;
        DataSet Veri_Set;
        OleDbCommand Veri_Komutu;
        OleDbDataReader Veri_Oku;
        public static int id = 0;
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();

            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "SELECT * FROM kullanicilar where email=@email AND sifre=@sifre";
            Veri_Komutu.Parameters.AddWithValue("@email", textBox1.Text);
            Veri_Komutu.Parameters.AddWithValue("@sifre", textBox2.Text);
            Veri_Oku = Veri_Komutu.ExecuteReader();

            if (Veri_Oku.Read())
            {
                id = Convert.ToInt32(Veri_Oku[0]);
                BiletSatisEkrani bse = new BiletSatisEkrani();
                bse.Show();
            }
            else
                MessageBox.Show("Email veya şifre hatalı");

            Veritabani_Baglanti.Close();
        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {

        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            KayitEkrani ff = new KayitEkrani();
            ff.Show();
        }

        private void ıconButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "serhat" && textBox2.Text == "1234")
            {
                YoneticiEkrani ye = new YoneticiEkrani();
                ye.Show();
            }
            else
                MessageBox.Show("Email veya şifre hatalı");
        }
    }
}
