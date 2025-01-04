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

namespace ödev
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=elif\\SQLEXPRESS01; " +
        "Initial Catalog=görsel;" +
        "Integrated Security=True");
        public void goster(string veri)
        {
            SqlDataAdapter da = new SqlDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select Count(*) as toplamurun from Laptop", baglanti);
            SqlDataReader rdr = sorgu.ExecuteReader();
            rdr.Read();
            label2.Text = rdr[0].ToString();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goster("SELECT Marka, Count(Marka) AS ToplamStok FROM Laptop GROUP BY Marka;");
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            goster("SELECT Islemci, Count(Islemci) AS ToplamStok FROM Laptop GROUP BY Islemci;");
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            goster("SELECT RAM, Count(RAM) AS ToplamStok FROM Laptop GROUP BY RAM;");
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            goster("SELECT Depolama, Count(Depolama) AS ToplamStok FROM Laptop GROUP BY Depolama;");
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form1 ad = new Form1();
            ad.Show();
            this.Close();
        }
    }
}
