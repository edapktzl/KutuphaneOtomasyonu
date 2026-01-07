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
    public partial class IstatistikForm : Form
    {

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\typho\OneDrive\Desktop\Kutuphane_Otomasyonu\KutuphaneDB.mdf;Integrated Security=True");
        public IstatistikForm()
        {
            InitializeComponent();
        }

        private void IstatistikForm_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();

            
            SqlCommand komut1 = new SqlCommand("SELECT SUM(StokSayisi) FROM Kitaplar WHERE SilindiMi=0", baglanti);
         
            object sonuc1 = komut1.ExecuteScalar();
            lblKitapSayisi.Text = sonuc1 != DBNull.Value ? sonuc1.ToString() : "0";

            
            SqlCommand komut2 = new SqlCommand("SELECT COUNT(*) FROM Uyeler WHERE SilindiMi=0", baglanti);
            lblUyeSayisi.Text = komut2.ExecuteScalar().ToString();

            
      
            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM Hareketler WHERE IslemDurumu=1", baglanti);
            lblEmanetSayisi.Text = komut3.ExecuteScalar().ToString();

       
            SqlCommand komut4 = new SqlCommand("SELECT COUNT(*) FROM Uyeler WHERE CezaPuani > 0 AND SilindiMi=0", baglanti);
            lblCezaSayisi.Text = komut4.ExecuteScalar().ToString();

            baglanti.Close();
        }
    }
}
