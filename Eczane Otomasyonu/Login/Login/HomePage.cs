using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Login
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DrugManufacturer tedarikci1 = new DrugManufacturer();
            tedarikci1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prescription recete = new Prescription();
            recete.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Drug ilac = new Drug();
            ilac.Show();
            this.Hide();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Patient hasta = new Patient();
            hasta.Show();
            this.Hide();
        }
    }
}
