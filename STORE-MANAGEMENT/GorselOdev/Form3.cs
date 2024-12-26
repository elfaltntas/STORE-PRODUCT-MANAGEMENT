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

namespace GorselOdev
{
    public partial class Form3 : Form
    {
        public string isim;
        public Form3()
        {
            InitializeComponent();
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sorgu = new SqlCommand("Select * from Fareler  where Marka like '%" + textBox1.Text + "%'", baglan);
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            goster("Select * from Fareler");
            baglan.Close() ;
            this.Text = $"Hoşgeldin {isim}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            goster("Select * from Fareler");
            baglan.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 ad = new Form1();
            ad.Show();
            this.Close();
        }
    }
}
