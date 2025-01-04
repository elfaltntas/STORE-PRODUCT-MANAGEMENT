using System.Data.SqlClient;

namespace ödev
{
    public partial class Form1 : Form
    {
        public string isim;

        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=elif\\SQLEXPRESS01; " +
       "Initial Catalog=görsel;" +
       "Integrated Security=True");



        int kalandeneme = 3;

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();



            SqlCommand giriskontrol = new SqlCommand("SELECT* FROM[dbo].[Kullanici] WHERE[KullaniciAdi] = '" + textBox1.Text + "' AND[Sifre] = '" + textBox2.Text + "';", baglanti);
            SqlCommand adminlikkontrol = new SqlCommand("SELECT [Yetki] FROM [dbo].[Kullanici] WHERE [KullaniciAdi] = '" + textBox1.Text + "' AND [Yetki] = 'admin';", baglanti);
            SqlCommand advesoyad = new SqlCommand("SELECT * FROM[dbo].[Kullanici] WHERE[KullaniciAdi] = '" + textBox1.Text + "'; ", baglanti);

            SqlDataReader reader = giriskontrol.ExecuteReader();

            if (reader.HasRows)
            {
                MessageBox.Show("Giriş Başarılı");

                reader.Close();

                SqlDataReader reader2 = adminlikkontrol.ExecuteReader();


                if (reader2.HasRows)
                {
                    //MessageBox.Show("Admin Paneline yönlendiriliyorsunuz");
                    reader2.Close();

                    SqlDataReader reader3 = advesoyad.ExecuteReader();
                    reader3.Read();

                    isim = reader3["KullaniciAdi"].ToString();


                    reader3.Close();
                    baglanti.Close();

                    //MessageBox.Show($"Hoþgeldiniz {isim} {soyisim}");





                    Form2 adminform = new Form2();
                    adminform.isim = isim;

                    adminform.Show();

                    this.Hide();




                }
                else
                {

                    reader2.Close();

                    SqlDataReader reader3 = advesoyad.ExecuteReader();
                    reader3.Read();

                    isim = reader3["KullaniciAdi"].ToString();


                    reader3.Close();
                    baglanti.Close();
                    Form3 userform = new Form3();

                    userform.Show();

                    this.Hide();
                }

            }
            else
            {

                kalandeneme--;
                if (kalandeneme == 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Giriş başarısız,Deneme hakkınız yok", kalandeneme.ToString());
                }

            }

            reader.Close();
            baglanti.Close();
        }
    }
}