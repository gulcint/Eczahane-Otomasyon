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

    public partial class Drug : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-MOFJT2H\\SQLEXPRESS2;Initial Catalog='Eczahane Otomasyon';Integrated Security=True");


        public Drug()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") | (textBox2.Text == "") | (textBox3.Text == "") | (textBox4.Text=="")  )
            {
                MessageBox.Show("Boş alanları doldurunuz.");
            }
            else
            {
                try
                {

                    baglanti.Open();
                    string kayit = "insert into Drug_table(DrugId,Name,Stock,CompanyId) values (@DrugId,@Name,@Stock,@CompanyId)";
                    SqlCommand cmd = new SqlCommand(kayit, baglanti);

                    //listbao id listeleme başlangıcı

                    //SqlCommand cmd2 = new SqlCommand("select PrescriptionId from Prescription_table ", baglanti);
                    //cmd2.Connection = baglanti;
                    //SqlDataReader oku = cmd2.ExecuteReader();
                    //while (oku.Read())
                    //{
                    //    comboBox1.Items.Add(oku["PrescriptionId"]);

                    //}
                    // listbox id listeleme bitişi

                    cmd.Connection = baglanti;
                    cmd.Parameters.AddWithValue("@DrugId", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Stock", textBox3.Text);
                    cmd.Parameters.AddWithValue("@CompanyId", textBox4.Text);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    baglanti.Close();
                    MessageBox.Show("Yeni ilaç bilgileri eklendi.");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    

                }
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            HomePage anasayfa = new HomePage();
            anasayfa.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HomePage anasayfa = new HomePage();
            anasayfa.Show();
            this.Hide();
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            DrugQuantity miktar = new DrugQuantity();
            miktar.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from Drug_table", baglanti);

            cmd.Connection = baglanti;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add("> " + dr["DrugId"].ToString() + " İlaç Adı: " + dr["Name"] + " Stok Bilgisi: " + dr["Stock"] + " Şirket Id: " + dr["CompanyId"]);
                listBox1.Items.Add(" ");
            }
            baglanti.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from Drug_table", baglanti);

            cmd.Connection = baglanti;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (textBox1.Text == dr["DrugId"].ToString())
                {
                    MessageBox.Show("Bu ID de bir kayıt bulunmaktadır.Farklı bir değer giriniz.");
                    textBox1.Clear();
                    break;
                }
            }
            baglanti.Close();
        }

        private void Drug_Load(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Drug_table", baglanti);
            
            try
            {
                
                baglanti.Open();
                cmd.Connection = baglanti;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listBox1.Items.Add("> " + dr["DrugId"].ToString() + " İlaç Adı: " + dr["Name"] + " Stok Bilgisi: " + dr["Stock"] + " Şirket Id: " + dr["CompanyId"]);
                    listBox1.Items.Add(" ");
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from Drug_table", baglanti);

            cmd.Connection = baglanti;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (textBox1.Text == dr["DrugId"].ToString())
                {
                    MessageBox.Show("Bu ID de bir kayıt bulunmaktadır.Farklı bir değer giriniz.");
                    textBox1.Clear();
                    break;
                }
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteDrug ilac = new DeleteDrug();
            ilac.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
