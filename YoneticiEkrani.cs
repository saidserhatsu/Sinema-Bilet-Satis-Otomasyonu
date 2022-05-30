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
    public partial class YoneticiEkrani : Form
    {
        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=biletsatisotomasyonuDB.accdb");
        OleDbDataAdapter Veri_Adaptor;
        OleDbCommandBuilder cb;
        OleDbCommand Veri_Komutu;
        DataTable tablo = new DataTable();

        public YoneticiEkrani()
        {
            InitializeComponent();
           
        }

        private void YoneticiEkrani_Load(object sender, EventArgs e)
        {
            FilmTabloListele();

        }
        private void FilmTabloListele()
        {
            tablo.Rows.Clear();
            dataGridView1.Refresh();
            Veri_Adaptor = new OleDbDataAdapter("select * From FilmBilgileri", Veritabani_Baglanti);
            Veri_Adaptor.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            FilmTabloListele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            FilmTabloListele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SeansEkrani se = new SeansEkrani();
            se.Show();
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Insert into FilmBilgileri(filmadi,yonetmen,filmturu,filmsuresi,tarih) " +
                "values (" + "'" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "')";
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            MessageBox.Show("Ekleme Başarılı..!");
            FilmTabloListele();
        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            cb = new OleDbCommandBuilder(Veri_Adaptor);
            Veri_Adaptor.Update(tablo);
            MessageBox.Show("Güncelleme Başarılı..!");
            FilmTabloListele();
        }

        private void ıconButton3_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "delete from FilmBilgileri where filmid=" + dataGridView1.CurrentRow.Cells["filmid"].Value.ToString() + "";
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            MessageBox.Show("Silme Başarılı..!");
            FilmTabloListele();
        }
    }
}
