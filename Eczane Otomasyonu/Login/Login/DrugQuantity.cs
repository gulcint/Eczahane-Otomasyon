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
    public partial class DrugQuantity : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-MOFJT2H\\SQLEXPRESS2;Initial Catalog='Eczahane Otomasyon';Integrated Security=True");


        public DrugQuantity()
        {
            InitializeComponent();
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            Drug ilac = new Drug();
            ilac.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("select * from Drug_table", baglanti);
                cmd.Connection = baglanti;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (textBox1.Text == dr["DrugId"].ToString())
                    {
                        int a = int.Parse(string.Format("{0}", dr["Stock"]));
                        int b = System.Convert.ToInt32(textBox2.Text);
                        int toplamstok = a + b;
                        textBox3.Text =Convert.ToString(toplamstok);
                        i = 1;
                        break;
                        
                    }
                }
                dr.Close();
                SqlCommand cmd2 = new SqlCommand("UPDATE Drug_table SET Stock='" + textBox3.Text+"'where DrugId="+textBox1.Text, baglanti);
                cmd2.Connection = baglanti;
                cmd2.ExecuteNonQuery();


                if (i == 0)
                {
                    MessageBox.Show("Bu kayda ait reçete bulunamadı.");
                }
                i = 0;

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

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("select * from Drug_table", baglanti);
                cmd.Connection = baglanti;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (textBox6.Text == dr["DrugId"].ToString())
                    {
                        int a = int.Parse(string.Format("{0}", dr["Stock"]));
                        int b = System.Convert.ToInt32(textBox5.Text);
                        int yenistok = a - b;
                        if (yenistok < 0)
                        {
                            MessageBox.Show("Stokta yeteri kadar ilaç bulunmamaktadır.");
                        }
                        else
                        {
                            textBox4.Text = Convert.ToString(yenistok);
                            i = 1;
                            break;
                        }
                    }
                }
                dr.Close();
                SqlCommand cmd2 = new SqlCommand("UPDATE Drug_table SET Stock='"+textBox4.Text+"'where DrugId="+textBox6.Text,baglanti);
                cmd2.Connection = baglanti;
                cmd2.ExecuteNonQuery();


                if (i == 0)
                {
                    MessageBox.Show("Bu kayda ait reçete bulunamadı.");
                }
                i = 0;

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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //    baglanti.Open();
            //    SqlCommand cmd = new SqlCommand("select DrugId from Drug_table", baglanti);

            //    cmd.Connection = baglanti;
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {

            //        if (textBox1.Text != dr["DrugId"].ToString())
            //        {
            //            MessageBox.Show("Bu ID de bir kayıt bulunmamaktadır.Farklı bir değer giriniz.");
            //            textBox1.Clear();
            //            break;
            //        }
            //    }
            //    baglanti.Close();

            SqlCommand cmd = new SqlCommand("select * from Drug_table", baglanti);
            int i = 0;
            try
            {

                baglanti.Open();
                cmd.Connection = baglanti;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if (textBox1.Text == dr["DrugId"].ToString())
                    {
                        i = 1;
                    }
                }
                if (i == 0)
                {
                    MessageBox.Show("Bu kayda ait ilaç bulunamadı.Lütfen farklı bir ID giriniz.");
                }
                i = 0;

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

        private void textBox6_Leave(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select DrugId from Drug_table", baglanti);

            cmd.Connection = baglanti;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                if (textBox6.Text == dr["DrugId"].ToString())
                {
                    break;
                }
                else
                {
                    MessageBox.Show("Bu ID de bir kayıt bulunmamaktadır.Farklı bir değer giriniz.");
                    textBox6.Clear();
                    break;
                }
            }
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
