using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKitaplar_Click(object sender, EventArgs e)
        {
            KitapForm kForm = new KitapForm();
            kForm.ShowDialog();
        }

        private void btnUyeler_Click(object sender, EventArgs e)
        {
            UyeForm uForm = new UyeForm();
            uForm.ShowDialog();
        }

        private void btnOdunc_Click(object sender, EventArgs e)
        {
            HareketForm hForm = new HareketForm();
            hForm.ShowDialog();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            IstatistikForm iForm = new IstatistikForm();
            iForm.ShowDialog();
        }
    }
}
