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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ödev
{
    public partial class Form3 : Form
    {
        public Form3()
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

        private void Form3_Load(object sender, EventArgs e)
        {
            goster("Select * from Laptop");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Laptop where Marka = '" + textBox1.Text + "'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            goster("Select * from Laptop");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 ad = new Form1();
            ad.Show();
            this.Close();
        }
    }
}
