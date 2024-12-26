using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;

namespace GorselOdev
{
    public partial class Form2 : Form
    {
        public string isim;

        public Form2()
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
            goster("Select * from Fareler");
            baglan.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sorgu = new SqlCommand("insert into Fareler (FareID,FareAdi,Marka,Model,BaglantiTur,DPI,TusSayisi,SensorTur,Renk,Agirlik,Fiyat,StokDurumu) values" +
                "(@FareID,@FareAdi,@Marka,@Model,@BaglantiTur,@DPI,@TusSayisi,@SensorTur,@Renk,@Agirlik,@Fiyat,@StokDurumu)", baglan);
            sorgu.Parameters.AddWithValue("@FareID", Convert.ToInt32(textBox1.Text));
            sorgu.Parameters.AddWithValue("@Marka", textBox2.Text);
            sorgu.Parameters.AddWithValue("@Model", textBox3.Text);
            sorgu.Parameters.AddWithValue("@BaglantiTur", textBox4.Text);
            sorgu.Parameters.AddWithValue("@DPI", textBox5.Text);
            sorgu.Parameters.AddWithValue("@TusSayisi", textBox6.Text);
            sorgu.Parameters.AddWithValue("@SensorTur", textBox7.Text);
            sorgu.Parameters.AddWithValue("@Renk", textBox8.Text);
            sorgu.Parameters.AddWithValue("@Agirlik", textBox9.Text);
            sorgu.Parameters.AddWithValue("@Fiyat", Convert.ToInt32(textBox10.Text));
            sorgu.Parameters.AddWithValue("@StokDurumu", Convert.ToInt32(textBox11.Text));
            sorgu.Parameters.AddWithValue("@FareAdi", textBox14.Text); ;
            sorgu.ExecuteNonQuery();
            goster("Select * from Fareler");

            baglan.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox14.Clear();
            textBox1.Focus();

            baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sorgu = new SqlCommand("delete from Fareler where FareID=@FareID", baglan);
            sorgu.Parameters.AddWithValue("@FareID", textBox12.Text);
            sorgu.ExecuteNonQuery();
            goster("Select * from Fareler");
            baglan.Close();
            textBox12.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sorgu;



            //SqlCommand sorgu = new SqlCommand("Select * from Fareler  where " +
            //    "Marka like '%" + textBox13.Text + "%'", baglan);

            if (int.TryParse(textBox13.Text, out int id))
            {
                // Kullanıcı bir sayı girdiyse ID'ye göre sorgu yap
                sorgu = new SqlCommand("SELECT * FROM Fareler WHERE FareID = @FareID", baglan);
                sorgu.Parameters.AddWithValue("@FareID", id);
            }
            else
            {
                // Kullanıcı bir sayı girmediyse markaya göre sorgu yap
                sorgu = new SqlCommand("SELECT * FROM Fareler WHERE marka LIKE @FareAdi", baglan);
                sorgu.Parameters.AddWithValue("@FareAdi", "%" + textBox13.Text + "%");
            }



            

            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sorgu = new SqlCommand("update Fareler set FareID='" + textBox1.Text + "',FareAdi = '" + textBox14.Text + "', " +
                "Marka='" + textBox2.Text + "', " +
                "Model='" + textBox3.Text + "', BaglantiTur='" + textBox4.Text + "', " +
                "DPI='" + textBox5.Text + "', TusSayisi='" + textBox6.Text + "', " +
                "SensorTur='" + textBox7.Text + "', Renk='" + textBox8.Text + "'," +
                " Agirlik='" + textBox9.Text + "', Fiyat='" + textBox10.Text + "', " +
                "StokDurumu='" + textBox11.Text + "'where FareID='" + textBox1.Text + "'", baglan);

            sorgu.ExecuteNonQuery();
            goster("Select * from Fareler");
            baglan.Close();



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string FareID = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string FareAdi = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string Marka = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string Model = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string BaglantiTur = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string DPI = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string TusSayisi = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            string SensorTur = dataGridView1.Rows[secilialan].Cells[7].Value.ToString();
            string Renk = dataGridView1.Rows[secilialan].Cells[8].Value.ToString();
            string Agirlik = dataGridView1.Rows[secilialan].Cells[9].Value.ToString();
            string Fiyat = dataGridView1.Rows[secilialan].Cells[10].Value.ToString();
            string StokDurumu = dataGridView1.Rows[secilialan].Cells[11].Value.ToString();

            textBox1.Text = FareID;
            textBox2.Text = Marka;
            textBox3.Text = Model;
            textBox4.Text = BaglantiTur;
            textBox5.Text = DPI;
            textBox6.Text = TusSayisi;
            textBox7.Text = SensorTur;
            textBox8.Text = Renk;
            textBox9.Text = Agirlik;
            textBox10.Text = Fiyat;
            textBox11.Text = StokDurumu;
            textBox12.Text = FareID;
            textBox13.Text = Marka;
            textBox14.Text = FareAdi;

            baglan.Close();

            //(FareID, Marka, Model, BaglantiTur, DPI, TusSayisi, SensorTur, Renk, Agirlik, Fiyat, StokDurumu)

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            goster("Select * from Fareler");
            this.Text = $"Hoşgeldin {isim}";
            anaSayfaToolStripMenuItem.Enabled = false;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 ad = new Form1();
            ad.Show();
            this.Close();
            
        }

        private void istatistikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 ad = new Form4();
            ad.Show();  
            this.Hide();
        }
    }
}
