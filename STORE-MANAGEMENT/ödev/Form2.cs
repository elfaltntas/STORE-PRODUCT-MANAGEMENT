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
using System.Runtime.Intrinsics.Arm;

namespace ödev
{
    public partial class Form2 : Form
    {
        public string isim;
        public Form2()
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
        private void button1_Click(object sender, EventArgs e)
        {
            goster("Select * from Laptop");
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("insert into Laptop (LaptopID,LaptopAdi,Marka,Islemci,RAM,Depolama,EkranBoyutu,EkranCozunurlugu,EkranTeknolojisi,GrafikKarti,IsletimSistemi,PilOmru) values" +
                "(@LaptopID,@LaptopAdi,@Marka,@Islemci,@RAM,@Depolama,@EkranBoyutu,@EkranCozunurlugu,@EkranTeknolojisi,@GrafikKarti,@IsletimSistemi,@PilOmru)", baglanti);
            sorgu.Parameters.AddWithValue("@LaptopID", Convert.ToInt32(textBox1.Text));
            sorgu.Parameters.AddWithValue("@LaptopAdi", textBox2.Text);
            sorgu.Parameters.AddWithValue("@Marka", textBox3.Text);
            sorgu.Parameters.AddWithValue("@Islemci", textBox4.Text);
            sorgu.Parameters.AddWithValue("@RAM", textBox5.Text);
            sorgu.Parameters.AddWithValue("@Depolama", textBox6.Text);
            sorgu.Parameters.AddWithValue("@EkranBoyutu", textBox7.Text);
            sorgu.Parameters.AddWithValue("@EkranCozunurlugu", textBox8.Text);
            sorgu.Parameters.AddWithValue("@EkranTeknolojisi", textBox9.Text);
            sorgu.Parameters.AddWithValue("@GrafikKarti", textBox10.Text);
            sorgu.Parameters.AddWithValue("@IsletimSistemi", textBox11.Text);
            sorgu.Parameters.AddWithValue("@PilOmru", Convert.ToInt32(textBox12.Text));
            sorgu.ExecuteNonQuery();
            goster("Select * from Laptop");

            baglanti.Close();
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
            textBox12.Clear();
            textBox1.Focus();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Laptop where LaptopID=@LaptopID", baglanti);
            komut.Parameters.AddWithValue("@LaptopID", textBox13.Text);
            komut.ExecuteNonQuery();
            goster("Select * from Laptop");
            baglanti.Close();

            textBox13.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Laptop where Marka = '" + textBox14.Text + "'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Laptop set LaptopAdi = '" + textBox2.Text + "'," +
                "Marka= '" + textBox3.Text + "',Islemci= '" + textBox4.Text + "'," +
                "RAM= '" + textBox5.Text + "',Depolama='" + textBox6.Text + "',EkranBoyutu= '" + textBox7.Text + "'," +
                "EkranCozunurlugu= '" + textBox8.Text + "'," +
                "EkranTeknolojisi= '" + textBox9.Text + "',GrafikKarti= '" + textBox10.Text + "',IsletimSistemi='" + textBox11.Text + "'," +
                "PilOmru= '" + Convert.ToInt32(textBox12.Text) + "' where  LaptopID= '" + textBox1.Text + "'", baglanti);

            //(LaptopID, LaptopAdi, Marka, Islemci, RAM, Depolama, EkranBoyutu, EkranCozunurlugu, 
            //    EkranTeknolojisi, GrafikKarti, IsletimSistemi, PilOmru)

            komut.ExecuteNonQuery();
            goster("select * from Laptop");
            baglanti.Close();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sectiginizalan = dataGridView1.SelectedCells[0].RowIndex;
            string LaptopID = dataGridView1.Rows[sectiginizalan].Cells[0].Value.ToString();
            string LaptopAdi = dataGridView1.Rows[sectiginizalan].Cells[1].Value.ToString();
            string Marka = dataGridView1.Rows[sectiginizalan].Cells[2].Value.ToString();
            string Islemci = dataGridView1.Rows[sectiginizalan].Cells[3].Value.ToString();
            string RAM = dataGridView1.Rows[sectiginizalan].Cells[4].Value.ToString();
            string Depolama = dataGridView1.Rows[sectiginizalan].Cells[5].Value.ToString();
            string EkranBoyutu = dataGridView1.Rows[sectiginizalan].Cells[6].Value.ToString();
            string EkranCozunurlugu = dataGridView1.Rows[sectiginizalan].Cells[7].Value.ToString();
            string EkranTeknolojisi = dataGridView1.Rows[sectiginizalan].Cells[8].Value.ToString();
            string GrafikKarti = dataGridView1.Rows[sectiginizalan].Cells[9].Value.ToString();
            string IsletimSistemi = dataGridView1.Rows[sectiginizalan].Cells[10].Value.ToString();
            string PilOmru = dataGridView1.Rows[sectiginizalan].Cells[11].Value.ToString();

            textBox1.Text = LaptopID;
            textBox2.Text = LaptopAdi;
            textBox3.Text = Marka;
            textBox4.Text = Islemci;
            textBox5.Text = RAM;
            textBox6.Text = Depolama;
            textBox7.Text = EkranBoyutu;
            textBox8.Text = EkranCozunurlugu;
            textBox9.Text = EkranTeknolojisi;
            textBox10.Text = GrafikKarti;
            textBox11.Text = IsletimSistemi;
            textBox12.Text = PilOmru;
            textBox13.Text = LaptopID;
            baglanti.Close();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            goster("Select * from Laptop");
            this.Text = $"Hoşgeldin {isim}";


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 ad = new Form1();
            ad.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 user = new Form4();

            user.Show();

            this.Hide();
        }
    }
}
