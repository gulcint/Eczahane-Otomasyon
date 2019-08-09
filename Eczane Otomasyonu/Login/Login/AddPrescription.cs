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
    public partial class AddPrescription : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-MOFJT2H\\SQLEXPRESS2;Initial Catalog='Eczahane Otomasyon';Integrated Security=True");

        public AddPrescription()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Prescription recete = new Prescription();
            recete.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Refresh();
            if ((textBox1.Text == "") | (textBox3.Text == "") | (textBox4.Text == "") | (textBox5.Text=="") )
            {
                MessageBox.Show("Boş alanları doldurunuz.");
            }
            else
            {
                try
                {

                    baglanti.Open();
                    string kayit = "insert into Prescription_table(PrescriptionId,Quantity,Date,PPatientId,PDoctorID) values (@PrescriptionId,@Quantity,@p1,@PPatientId,@PDoctorID)";

                    SqlCommand cmd = new SqlCommand(kayit, baglanti);

                    cmd.Connection = baglanti;
                    cmd.Parameters.AddWithValue("@PrescriptionId",textBox1.Text);
                    cmd.Parameters.AddWithValue("@Quantity",textBox3.Text);
                    cmd.Parameters.AddWithValue("@p1",this.dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@PPatientId",textBox4.Text);
                    cmd.Parameters.AddWithValue("@PDoctorID",textBox5.Text);

                    string kayit2 = "insert into Prescription_Drug(DPrescriptionId, DDrugId) values(@DPrescriptionId,@DDrugId)";
                    SqlCommand cmd2 = new SqlCommand(kayit2, baglanti);
                    cmd2.Connection = baglanti;


                    foreach (object item in checkedListBox1.CheckedItems)
                    {
                        cmd2.Parameters.AddWithValue("@DPrescriptionId", textBox1.Text);
                        cmd2.Parameters.AddWithValue("@DDrugId", item);
                    }
                    MessageBox.Show("Kayıt Başarılı");


                    //if (checkedListBox1.CheckedItems.Count != 0)
                    //{
                    //    string s = "";
                    //    for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                    //    {
                    //        cmd2.Parameters.AddWithValue("@PrescriptionId", textBox1.Text);
                    //        cmd2.Parameters.AddWithValue("@DrugID", checkedListBox1.CheckedItems[x]);
                    //    }
                    //}
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    baglanti.Close();
                    MessageBox.Show("Yeni reçete bilgileri eklendi.");
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from Prescription_table", baglanti);

            cmd.Connection = baglanti;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (textBox1.Text == dr["PrescriptionId"].ToString())
                {
                    MessageBox.Show("Bu ID de bir kayıt bulunmaktadır.Farklı bir değer giriniz.");
                    textBox1.Clear();
                    break;
                }
            }
            baglanti.Close();
        }
        
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if(textBox3.Text=="")
            {
                MessageBox.Show("İlaç adedi girin.");
            }
            else if ((Convert.ToInt32(textBox3.Text)) > 10)
            {
                MessageBox.Show("Lütfen daha az ilaç adedi giriniz.");
                textBox3.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Prescription_table", baglanti);

            try
            {

                baglanti.Open();

                string tarih = dateTimePicker1.Value.ToString();
                cmd.Connection = baglanti;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listBox1.Items.Add(">" + dr["PrescriptionId"].ToString() + "   Veriliş Tarihi:   " + dr["Date"] + "  İlaç Adedi:   " + dr["Quantity"] + "   Hasta ID:   " + dr["PPatientId"] + "   Doktor ID:  " + dr["PDoctorID"]);
                    listBox1.Items.Add(" ");

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SqlCommand komut = new SqlCommand("SELECT DrugID FROM  Drug_table", baglanti);

                komut.Connection = baglanti;
                SqlDataReader dr2 = komut.ExecuteReader();

                while (dr2.Read())
                {
                    checkedListBox1.Items.Add(dr2["DrugId"].ToString());
                }
                dr2.Close();
                baglanti.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
