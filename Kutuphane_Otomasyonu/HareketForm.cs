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
    public partial class HareketForm : Form
    {

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\typho\OneDrive\Desktop\Kutuphane_Otomasyonu\KutuphaneDB.mdf;Integrated Security=True");
        public HareketForm()
        {
            InitializeComponent();
        }

        void HareketleriListele()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            string sorgu = "SELECT Hareketler.HareketID, Uyeler.Ad + ' ' + Uyeler.Soyad as 'Üye', Kitaplar.KitapAdi as 'Kitap', Hareketler.AlisTarihi, Hareketler.PlanlananIadeTarihi " +
                           "FROM Hareketler " +
                           "JOIN Uyeler ON Hareketler.UyeID = Uyeler.UyeID " +
                           "JOIN Kitaplar ON Hareketler.KitapID = Kitaplar.KitapID " +
                           "WHERE Hareketler.IslemDurumu = 1";

            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        void ListeleriDoldur()
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            SqlCommand komutUye = new SqlCommand("SELECT UyeID, Ad + ' ' + Soyad AS AdSoyad FROM Uyeler WHERE SilindiMi=0", baglanti);
            SqlDataAdapter daUye = new SqlDataAdapter(komutUye);
            DataTable dtUye = new DataTable();
            daUye.Fill(dtUye);
            cmbUyeler.DisplayMember = "AdSoyad"; 
            cmbUyeler.ValueMember = "UyeID";    
            cmbUyeler.DataSource = dtUye;

            SqlCommand komutKitap = new SqlCommand("SELECT KitapID, KitapAdi FROM Kitaplar WHERE SilindiMi=0 AND StokSayisi > 0", baglanti);
            SqlDataAdapter daKitap = new SqlDataAdapter(komutKitap);
            DataTable dtKitap = new DataTable();
            daKitap.Fill(dtKitap);
            cmbKitaplar.DisplayMember = "KitapAdi";
            cmbKitaplar.ValueMember = "KitapID";
            cmbKitaplar.DataSource = dtKitap;

            baglanti.Close();
        }

        private void HareketForm_Load(object sender, EventArgs e)
        {
            HareketleriListele();
            ListeleriDoldur();
        }

        private void btnOduncVer_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            
            SqlCommand komut = new SqlCommand("INSERT INTO Hareketler (UyeID, KitapID, AlisTarihi, PlanlananIadeTarihi, IslemDurumu) VALUES (@p1, @p2, @p3, @p4, 1)", baglanti);
            komut.Parameters.AddWithValue("@p1", cmbUyeler.SelectedValue);
            komut.Parameters.AddWithValue("@p2", cmbKitaplar.SelectedValue);
            komut.Parameters.AddWithValue("@p3", DateTime.Now);
            komut.Parameters.AddWithValue("@p4", dateIade.Value); 

            komut.ExecuteNonQuery();

            SqlCommand komutStok = new SqlCommand("UPDATE Kitaplar SET StokSayisi = StokSayisi - 1 WHERE KitapID = @p1", baglanti);
            komutStok.Parameters.AddWithValue("@p1", cmbKitaplar.SelectedValue);
            komutStok.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Kitap ödünç verildi!");
            HareketleriListele();
            ListeleriDoldur(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtHareketID.Text = dataGridView1.Rows[secilen].Cells["HareketID"].Value.ToString();

      
            DateTime planlananTarih = Convert.ToDateTime(dataGridView1.Rows[secilen].Cells["PlanlananIadeTarihi"].Value);
            DateTime bugun = DateTime.Now;

         
            TimeSpan fark = bugun - planlananTarih;
            double gunSayisi = fark.TotalDays;

            if (gunSayisi > 0)
            {
                double ceza = gunSayisi * 5;
                lblCeza.Text = ceza.ToString("0.00") + " TL";
            }
            else
            {
                lblCeza.Text = "0 TL";
            }
        }

        private void btnIadeAl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHareketID.Text))
            {
                MessageBox.Show("Lütfen listeden iade edilecek işlemi seçin.");
                return;
            }

            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            decimal cezaTutari = decimal.Parse(lblCeza.Text.Replace(" TL", ""));

            SqlCommand komut = new SqlCommand("UPDATE Hareketler SET TeslimTarihi=@p1, IslemDurumu=0, CezaBedeli=@p2 WHERE HareketID=@p3", baglanti);
            komut.Parameters.AddWithValue("@p1", DateTime.Now);
            komut.Parameters.AddWithValue("@p2", cezaTutari);
            komut.Parameters.AddWithValue("@p3", txtHareketID.Text);
            komut.ExecuteNonQuery();

            SqlCommand kitapBul = new SqlCommand("SELECT KitapID FROM Hareketler WHERE HareketID=@p1", baglanti);
            kitapBul.Parameters.AddWithValue("@p1", txtHareketID.Text);
            int kitapID = (int)kitapBul.ExecuteScalar();

           
            SqlCommand stokArttir = new SqlCommand("UPDATE Kitaplar SET StokSayisi = StokSayisi + 1 WHERE KitapID=@p1", baglanti);
            stokArttir.Parameters.AddWithValue("@p1", kitapID);
            stokArttir.ExecuteNonQuery();

           
        }
    }
}
