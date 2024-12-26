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

namespace GorselOdev
{
    public partial class Form4 : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=BURHAN-USTUBI; " +
        "Initial Catalog=gorsel_odev;" +
        "Integrated Security=True");
        public void goster(string veri)
        {
            SqlDataAdapter da = new SqlDataAdapter(veri, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            istatistikToolStripMenuItem.Enabled = false;
            baglan.Open();
            SqlCommand sorgu = new SqlCommand("SELECT COUNT(*) AS ToplamUrunSayisi FROM Fareler;", baglan);
            SqlDataReader oku = sorgu.ExecuteReader();
            oku.Read();

            label2.Text = oku[0].ToString();
            baglan.Close();

            baglan.Open();
            SqlCommand sorgu2 = new SqlCommand("SELECT COUNT(*) AS ToplamKisiSayısı FROM Kullanicilar;", baglan);
            SqlDataReader oku2 = sorgu2.ExecuteReader();
            oku2.Read();
            label4.Text = oku2[0].ToString();
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goster("SELECT Marka, SUM(StokDurumu) AS ToplamStok FROM Fareler GROUP BY Marka;");
            baglan.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            goster("SELECT Marka, AVG(Fiyat) AS OrtalamaFiyat FROM Fareler GROUP BY Marka;");
            baglan.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            goster("SELECT FareAdi, SUM(StokDurumu) AS ToplamStok FROM Fareler GROUP BY FareAdi;");
            baglan.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            goster("SELECT BaglantiTur, COUNT(*) AS Adet FROM Fareler GROUP BY BaglantiTur;");
            baglan.Close();
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 ad = new Form2();
            ad.Show();
            this.Close();
        }
    }
}
