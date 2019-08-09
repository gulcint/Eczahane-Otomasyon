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
    public partial class Login : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-MOFJT2H\\SQLEXPRESS2;Initial Catalog='Eczahane Otomasyon';Integrated Security=True");


        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici_adi = textBox1.Text;
            string sifre = textBox2.Text;

            if(kullanici_adi=="a"&&sifre=="1")
            {
                HomePage anasayfa = new HomePage();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Geçerli bir kullanıcı adı veya şifre giriniz.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
                //MessageBox.Show("");// hiçbir işlem yaptırmıyorum
            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        internal class Eczahane_OtomasyonDataSet
        {
            public Eczahane_OtomasyonDataSet()
            {
            }

            public string DataSetName { get; internal set; }
            public SchemaSerializationMode SchemaSerializationMode { get; internal set; }
        }

        internal class Eczahane_OtomasyonDataSet2
        {
            public Eczahane_OtomasyonDataSet2()
            {
            }

            public string DataSetName { get; internal set; }
            public SchemaSerializationMode SchemaSerializationMode { get; internal set; }
        }
    }
}
