using System;
using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_anjing
{
    public partial class access : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source = localhost;port=3306;Initial Catalog = db_apotik ;User Id = root;password ='marcell98'");

        public access(string Str_Value)
        {
            InitializeComponent();
            textBox8.Text = Str_Value;
        }

        private void access_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "12345")
            {
                karyawan f8 = new karyawan(textBox8.Text);
                f8.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Code!");
                textBox2.Text = "";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f8 = new Form1(textBox8.Text);
            f8.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
