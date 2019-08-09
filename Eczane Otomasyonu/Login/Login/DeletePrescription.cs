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
    public partial class DeletePrescription : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-MOFJT2H\\SQLEXPRESS2;Initial Catalog='Eczahane Otomasyon';Integrated Security=True");


        public DeletePrescription()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Prescription recete = new Prescription();
            recete.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Prescription_table", baglanti);

            try
            {

                baglanti.Open();
                cmd.Connection = baglanti;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listBox1.Items.Add("> " + dr["PrescriptionId"].ToString() + " İlaç Adedi: " + dr["Quantity"] + " Verilme Tarihi: " + dr["Date"] + " Hasta ID: " + dr["PPatientId"] + " Doktor ID: " + dr["PDoctorID"]);
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

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string secmeSorgusu = "SELECT * from Prescription_table where PrescriptionId=@PrescriptionId";
            SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
            secmeKomutu.Parameters.AddWithValue("@PrescriptionId", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
            SqlDataReader dr = secmeKomutu.ExecuteReader();

            if (textBox1.Text == "")
                MessageBox.Show("Lüften bir reçete ID si girin.");

            else if (dr.Read())
            {
                string ID = dr["PrescriptionId"].ToString() ;
                dr.Close();
                DialogResult durum = MessageBox.Show(ID + " numaralı kaydı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                
                if (DialogResult.Yes == durum) 
                {
                    string silmeSorgusu = "DELETE from Prescription_table where PrescriptionId=@PrescriptionId";
                    SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                    silKomutu.Parameters.AddWithValue("@PrescriptionId", textBox1.Text);
                    silKomutu.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi.");
                }
            }
            else
                MessageBox.Show("Reçete Bulunamadı.");
            textBox1.Clear();
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
