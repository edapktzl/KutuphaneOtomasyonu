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
    public partial class UyeForm : Form
    {

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\typho\OneDrive\Desktop\Kutuphane_Otomasyonu\KutuphaneDB.mdf;Integrated Security=True");
        public UyeForm()
        {
            InitializeComponent();
        }

        void UyeleriListele()
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();

            SqlDataAdapter da = new SqlDataAdapter("Select * From Uyeler WHERE SilindiMi=0", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

            // Gereksiz sütunları gizle
            if (dataGridView1.Columns.Contains("UyeID")) dataGridView1.Columns["UyeID"].Visible = false;
            if (dataGridView1.Columns.Contains("SilindiMi")) dataGridView1.Columns["SilindiMi"].Visible = false;
        }

        private void UyeForm_Load(object sender, EventArgs e)
        {
            UyeleriListele();
        }



        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            SqlCommand komut = new SqlCommand("INSERT INTO Uyeler (Ad, Soyad, TcNo, Telefon, Email, Adres) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtTc.Text);
            komut.Parameters.AddWithValue("@p4", txtTel.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", txtAdres.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üye kaydedildi.");
            UyeleriListele();
            Temizle();
        }

        void Temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTc.Text = "";
            txtTel.Text = "";
            txtMail.Text = "";
            txtAdres.Text = "";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) { MessageBox.Show("Seçim yapın!"); return; }

            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Uyeler SET SilindiMi=1 WHERE UyeID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üye silindi.");
            UyeleriListele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) { MessageBox.Show("Seçim yapın!"); return; }

            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Uyeler SET Ad=@p1, Soyad=@p2, TcNo=@p3, Telefon=@p4, Email=@p5, Adres=@p6 WHERE UyeID=@p7", baglanti);

            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtTc.Text);
            komut.Parameters.AddWithValue("@p4", txtTel.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", txtAdres.Text);
            komut.Parameters.AddWithValue("@p7", txtID.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üye güncellendi.");
            UyeleriListele();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells["UyeID"].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells["Ad"].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells["Soyad"].Value.ToString();
            txtTc.Text = dataGridView1.Rows[secilen].Cells["TcNo"].Value.ToString();
            txtTel.Text = dataGridView1.Rows[secilen].Cells["Telefon"].Value.ToString();
            txtMail.Text = dataGridView1.Rows[secilen].Cells["Email"].Value.ToString();
            txtAdres.Text = dataGridView1.Rows[secilen].Cells["Adres"].Value.ToString();
        }
    }
}
