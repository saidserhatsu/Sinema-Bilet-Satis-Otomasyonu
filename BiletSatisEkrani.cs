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
    public partial class BiletSatisEkrani : Form
    {
        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=biletsatisotomasyonuDB.accdb");
        OleDbDataAdapter Veri_Adaptor;
        OleDbCommand Veri_Komutu;
        OleDbDataReader Veri_Oku;
        DataTable tablo = new DataTable();
        public BiletSatisEkrani()
        {
            InitializeComponent();
        }
        private void SinemaListele()
        {
            tablo.Rows.Clear();
            dataGridView1.Refresh();
            Veri_Adaptor = new OleDbDataAdapter("select * From FilmBilgileri", Veritabani_Baglanti);
            Veri_Adaptor.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        int kullaniciid = 0;
        private void BiletSatisEkrani_Load(object sender, EventArgs e)
        {
            label5.Text = "";
            kullaniciid = Convert.ToInt32(GirisEkrani.id.ToString());
            SinemaListele();
            Koltuk();
            foreach (Control item in panel2.Controls)
            {
                if (item is RadioButton)
                {
                    ((RadioButton)item).CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
                }
            }
        }
        private void Koltuk()
        {
            foreach (Control c in panel2.Controls)
            {
                if (c is RadioButton && ((RadioButton)c).Enabled == false)
                {
                    ((RadioButton)c).Checked = false;
                    c.BackColor = Color.White;
                    c.Enabled = true;
                }
            } 
        }
        private void DoluKoltuk()
        {
            Koltuk();
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Select * from SatisBilgileri where filmadi='" + label5.Text + "'";
            Veri_Oku = Veri_Komutu.ExecuteReader();
            while (Veri_Oku.Read())
            {
                foreach (Control item in panel2.Controls)
                {
                    if (item is RadioButton)
                    {
                        if (Veri_Oku["koltukno"].ToString()==item.Text)
                        {
                            ((RadioButton)item).Checked = false;
                            item.BackColor = Color.Red;
                            item.Enabled = false;
                        }
                    }
                }
            }
            Veritabani_Baglanti.Close();
        }
        string tarih="";
        int ucret = 0;
        string filmid = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label5.Text = dataGridView1.CurrentRow.Cells["filmadi"].Value.ToString();
            filmid = dataGridView1.CurrentRow.Cells["filmid"].Value.ToString();
            tarih = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["tarih"].Value.ToString()).ToShortDateString();
            ucret = 50;
            DoluKoltuk();
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in panel2.Controls)
            {
                if (c is RadioButton && ((RadioButton)c).Checked == true)
                {
                    label3.Text = c.Text;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();

            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Insert into SatisBilgileri(koltukno,filmadi,tarih,kullaniciid,ucret,filmid) " +
                "values (" + "'" + Convert.ToInt32(label3.Text) + "','" + label5.Text + "','" + tarih + "','" + kullaniciid + "','"+ ucret + "','" + filmid + "')";
            
            Veri_Komutu.ExecuteNonQuery();

            Veritabani_Baglanti.Close();
            DoluKoltuk();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Select * from SatisBilgileri where kullaniciid=@kull";
            Veri_Komutu.Parameters.AddWithValue("@kull", kullaniciid);
            Veri_Oku = Veri_Komutu.ExecuteReader();
            string biletler = "", a = "", c = "", b = "", d = "";
            while (Veri_Oku.Read())
            {
                a = Veri_Oku.GetString(2);
                b = Veri_Oku.GetInt32(1).ToString();
                c = Veri_Oku["tarih"].ToString();
                d = Veri_Oku.GetInt32(5).ToString();
                biletler += "\nFilm adı:" + a + " Koltuk numarası:" + b + " Tarih:" + c + " Ücret:" + d;
            }
            Veritabani_Baglanti.Close();
            MessageBox.Show(biletler, "Biletlerim");
        }
    }
}
