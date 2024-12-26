using System.Data.SqlClient;

namespace GorselOdev
{
    public partial class Form1 : Form
    {
        public string isim;
        public string soyisim;

        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=BURHAN-USTUBI; " +
        "Initial Catalog=gorsel_odev;" +
        "Integrated Security=True");

        int hak = 3;

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand giriskontrol = new SqlCommand("SELECT* FROM[dbo].[Kullanicilar] WHERE[KullaniciAdi] = " +
                "'" + textBox1.Text + "' AND[Sifre] = '" + textBox2.Text + "';", baglan);
            SqlCommand adminlikkontrol = new SqlCommand("SELECT [Rol] FROM [dbo].[Kullanicilar] WHERE [KullaniciAdi] = " +
                "'" + textBox1.Text + "' AND [Rol] = 'Admin';", baglan);
            SqlCommand advesoyad = new SqlCommand("SELECT [Ad], [Soyad] FROM[dbo].[Kullanicilar] WHERE[KullaniciAdi] = " +
                "'" + textBox1.Text + "'; ", baglan);

            SqlDataReader reader = giriskontrol.ExecuteReader();

            if (reader.HasRows)
            {
               
                label3.Text = $"Giriş Başarılı";

                reader.Close();

                SqlDataReader reader2 = adminlikkontrol.ExecuteReader();

                if (reader2.HasRows)
                {

                    reader2.Close();

                    SqlDataReader reader3 = advesoyad.ExecuteReader();
                    reader3.Read();

                    isim = reader3["Ad"].ToString();
                    soyisim = reader3["Soyad"].ToString();

                    reader3.Close();
                    baglan.Close();

                    Form2 adminform = new Form2();
                    adminform.isim = isim;

                    adminform.Show();

                    this.Hide();

                }
                else
                {
                    //MessageBox.Show("Kullanýcý Paneline yönlediriliyorsunuz");
                    reader2.Close();

                    SqlDataReader reader3 = advesoyad.ExecuteReader();
                    reader3.Read();

                    isim = reader3["Ad"].ToString();
                    soyisim = reader3["Soyad"].ToString();

                    reader3.Close();
                    baglan.Close();
                    Form3 userform = new Form3();
                    userform.isim = isim;

                    userform.Show();

                    this.Hide();
                }

            }
            else
            {

                hak--;
                if (hak == 0)
                {
                    this.Close();
                }
                else
                {
                    label3.Text = $"Giriş başarısız kalan deneme hakkınız: {hak.ToString()}";
                }

            }

            reader.Close();
            baglan.Close();
        }
    }
}
