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

namespace Login
{
    public partial class AddDeleteDrugManufacturer : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-MOFJT2H\\SQLEXPRESS2;Initial Catalog='Eczahane Otomasyon';Integrated Security=True");

        public AddDeleteDrugManufacturer()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DrugManufacturer tedarikci = new DrugManufacturer();
            tedarikci.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "" )|( textBox2.Text == "") | (textBox3.Text == "" )|( textBox4.Text == ""))
            {
                MessageBox.Show("Boş alanları doldurunuz.");
            }
            else
            {
                try
                {

                    baglanti.Open();
                    string kayit = "insert into DrugManufacturer_table(CompanyId,CompanyName,Adress,PhoneNumber) values (@CompanyId,@CompanyName,@Adress,@PhoneNumber)";
                    SqlCommand cmd = new SqlCommand(kayit, baglanti);

                    cmd.Connection = baglanti;
                    cmd.Parameters.AddWithValue("@CompanyId", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@CompanyName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Adress", textBox3.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber",textBox4.Text);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    baglanti.Close();
                    MessageBox.Show("Yeni tedarikçi bilgileri eklendi.");
                    DrugManufacturer tedarikci = new DrugManufacturer();
                    tedarikci.Show();
                    this.Hide();
                }
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from DrugManufacturer_table", baglanti);

            cmd.Connection = baglanti;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (textBox1.Text == dr["CompanyId"].ToString())
                {
                    MessageBox.Show("Bu ID de bir kayıt bulunmaktadır.Farklı bir değer giriniz.");
                    textBox1.Clear();
                    break;
                }
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string secmeSorgusu2 = "SELECT * from DrugManufacturer_table where CompanyId=@CompanyId";
            SqlCommand secmeKomutu2 = new SqlCommand(secmeSorgusu2, baglanti);
            secmeKomutu2.Parameters.AddWithValue("@CompanyId", textBox8.Text);
            SqlDataAdapter da1 = new SqlDataAdapter(secmeKomutu2);
            SqlDataReader dr3 = secmeKomutu2.ExecuteReader();
            if (dr3.Read())
            {
                string ID = dr3["CompanyId"].ToString();
                dr3.Close();
                DialogResult durum = MessageBox.Show(ID + " numaralı kaydı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == durum)
                {
                    string silmeSorgusu2 = "DELETE from DrugManufacturer_table where CompanyId=@CompanyId";
                    SqlCommand silKomutu2 = new SqlCommand(silmeSorgusu2, baglanti);
                    silKomutu2.Parameters.AddWithValue("@CompanyId", textBox8.Text);
                    silKomutu2.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi.");
                    textBox8.Clear();
                }
            }
            dr3.Close();
            baglanti.Close();

            DrugManufacturer tedarikci = new DrugManufacturer();
            tedarikci.Show();
            this.Hide();
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("select * from DrugManufacturer_table", baglanti);

            cmd2.Connection = baglanti;
            SqlDataReader dr2 = cmd2.ExecuteReader();
            int i = 0;
            while (dr2.Read())
            {
                if (textBox8.Text == dr2["CompanyId"].ToString())
                {
                    i = 1;

                    break;
                }
            }
            if (textBox8.Text == "")
            {
                MessageBox.Show("Boş alanları doldurunuz:");
            }
            else if (i == 0)
            {
                MessageBox.Show("Böyle bir kayıt bulunamadı.");
                textBox8.Clear();

            }
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
