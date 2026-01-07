using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu
{


    public partial class KitapForm : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\typho\OneDrive\Desktop\Kutuphane_Otomasyonu\KutuphaneDB.mdf;Integrated Security=True");
        public KitapForm()
        {
            InitializeComponent();
        }

        void KitaplariListele()
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();

            // Verileri çekiyoruz
            SqlDataAdapter da = new SqlDataAdapter("Select * From Kitaplar WHERE SilindiMi=0", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt; // Tabloya aktar

            baglanti.Close();

            // ID sütununu gizleyelim ki kafa karıştırmasın
            if (dataGridView1.Columns.Contains("KitapID"))
                dataGridView1.Columns["KitapID"].Visible = false;
            if (dataGridView1.Columns.Contains("SilindiMi"))
                dataGridView1.Columns["SilindiMi"].Visible = false;
        }

        private void KitapForm_Load(object sender, EventArgs e)
        {
            KitaplariListele();
        }


        // Bu kısmı kod sayfanda uygun bir yere (mesela en alta) yapıştır
        void Temizle()
        {
            txtID.Text = "";
            txtKitapAdi.Text = "";
            txtYazar.Text = "";
            txtYayinevi.Text = "";
            txtYayinYili.Text = "";
            txtISBN.Text = "";
            txtKategori.Text = "";
            txtStok.Text = "";
            txtFiyat.Text = "";
        }




        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();

           
            SqlCommand komut = new SqlCommand("INSERT INTO Kitaplar (KitapAdi, Yazar, Yayinevi, YayinYili, ISBN, Kategori, StokSayisi, KitapFiyati) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);

            komut.Parameters.AddWithValue("@p1", txtKitapAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtYazar.Text);
            komut.Parameters.AddWithValue("@p3", txtYayinevi.Text);
            komut.Parameters.AddWithValue("@p4", txtYayinYili.Text);
            komut.Parameters.AddWithValue("@p5", txtISBN.Text);
            komut.Parameters.AddWithValue("@p6", txtKategori.Text);
            komut.Parameters.AddWithValue("@p7", int.Parse(txtStok.Text)); 
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtFiyat.Text)); 

            komut.ExecuteNonQuery(); 
            baglanti.Close();

            MessageBox.Show("Kitap başarıyla eklendi!");
            KitaplariListele(); 
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Lütfen listeden silinecek kitabı seçin.");
                return;
            }

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();

            
            SqlCommand komut = new SqlCommand("UPDATE Kitaplar SET SilindiMi=1 WHERE KitapID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtID.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kitap silindi.");
            KitaplariListele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Lütfen listeden güncellenecek kitabı seçin.");
                return;
            }

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();

            SqlCommand komut = new SqlCommand("UPDATE Kitaplar SET KitapAdi=@p1, Yazar=@p2, Yayinevi=@p3, YayinYili=@p4, ISBN=@p5, Kategori=@p6, StokSayisi=@p7, KitapFiyati=@p8 WHERE KitapID=@p9", baglanti);

            komut.Parameters.AddWithValue("@p1", txtKitapAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtYazar.Text);
            komut.Parameters.AddWithValue("@p3", txtYayinevi.Text);
            komut.Parameters.AddWithValue("@p4", txtYayinYili.Text);
            komut.Parameters.AddWithValue("@p5", txtISBN.Text);
            komut.Parameters.AddWithValue("@p6", txtKategori.Text);
            komut.Parameters.AddWithValue("@p7", int.Parse(txtStok.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtFiyat.Text));
            komut.Parameters.AddWithValue("@p9", txtID.Text); 

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kitap bilgileri güncellendi.");
            KitaplariListele();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView1.Rows[secilen].Cells["KitapID"].Value.ToString();
            txtKitapAdi.Text = dataGridView1.Rows[secilen].Cells["KitapAdi"].Value.ToString();
            txtYazar.Text = dataGridView1.Rows[secilen].Cells["Yazar"].Value.ToString();
            txtYayinevi.Text = dataGridView1.Rows[secilen].Cells["Yayinevi"].Value.ToString();
            txtYayinYili.Text = dataGridView1.Rows[secilen].Cells["YayinYili"].Value.ToString();
            txtISBN.Text = dataGridView1.Rows[secilen].Cells["ISBN"].Value.ToString();
            txtKategori.Text = dataGridView1.Rows[secilen].Cells["Kategori"].Value.ToString();
            txtStok.Text = dataGridView1.Rows[secilen].Cells["StokSayisi"].Value.ToString();
            txtFiyat.Text = dataGridView1.Rows[secilen].Cells["KitapFiyati"].Value.ToString();
       }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}


