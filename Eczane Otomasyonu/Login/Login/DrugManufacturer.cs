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
    public partial class DrugManufacturer : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-MOFJT2H\\SQLEXPRESS2;Initial Catalog='Eczahane Otomasyon';Integrated Security=True");


        public DrugManufacturer()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HomePage anasayfa = new HomePage();
            anasayfa.Show();
            this.Hide();
        }

        private void DrugManufacturer_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from DrugManufacturer_table", baglanti);
            
            try
            {

                baglanti.Open();
                cmd.Connection = baglanti;
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    listBox1.Items.Add("> " + dr["CompanyId"].ToString() + "  " +dr["CompanyName"] + " / " + dr["Adress"] + " / " + dr["PhoneNumber"]);
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

        private void button2_Click(object sender, EventArgs e)
        {
            AddDeleteDrugManufacturer tedarikci = new AddDeleteDrugManufacturer();
            tedarikci.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
