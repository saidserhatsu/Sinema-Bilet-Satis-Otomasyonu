using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sinema_Bilet_Satis_Otomasyonu
{
    public partial class KayitEkrani : Form
    {

        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=biletsatisotomasyonuDB.accdb");
        OleDbDataAdapter Veri_Adaptor;
        DataSet Veri_Set;
        OleDbCommand Veri_Komutu;
        //OleDbDataReader Veri_Oku;
        public KayitEkrani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Insert into Kullanicilar(ad,soyad,email,sifre,gizlisoru,gizliyanit) values (" +"'"+ textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text +"')";
            
            Veri_Komutu.ExecuteNonQuery();
            
            Veritabani_Baglanti.Close();
        }

        private void KayitEkrani_Load(object sender, EventArgs e)
        {

        }
    }
}
