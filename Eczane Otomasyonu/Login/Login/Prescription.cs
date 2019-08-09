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
    public partial class Prescription : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-MOFJT2H\\SQLEXPRESS2;Initial Catalog='Eczahane Otomasyon';Integrated Security=True");


        public Prescription()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage anasayfa = new HomePage();
            anasayfa.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomePage anasayfa = new HomePage();
            anasayfa.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Prescription_table", baglanti);
            int i = 0;
                try
                {
                 
                    baglanti.Open();
                    cmd.Connection = baglanti;
                    SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {

                    if (textBox1.Text == dr["PrescriptionId"].ToString())
                    {
                        listBox1.Items.Add("> Reçete id : " + dr["PrescriptionId"].ToString() + "  " + " Reçete Tarihi: " + dr["Date"].ToString() );
                        //listBox1.Items.Add(">"+dr["DrugId"].ToString());
                        i = 1;
                    }
                }
                if(i==0)
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
            listBox1.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Drug_table", baglanti);
            int i = 0;
            try
            {

                baglanti.Open();
                cmd.Connection = baglanti;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if (textBox2.Text == dr["DrugId"].ToString())
                    {
                        listBox1.Items.Add(" ");
                        listBox1.Items.Add("> İlaç adı:  "+dr["Name"].ToString()+" Stok:  "+dr["Stock"]);
                        i = 1;
                    }
                }
                if (i == 0)
                {
                    MessageBox.Show("Bu kayda ait ilaç bulunamadı.");
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
        private void button3_Click(object sender, EventArgs e)
        {
            AddPrescription recete = new AddPrescription();
            recete.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from Prescription_table", baglanti);

            cmd.Connection = baglanti;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               
            }
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeletePrescription recete = new DeletePrescription();
            recete.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
