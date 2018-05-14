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
    public partial class createuser : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source = localhost;port=3306;Initial Catalog = db_apotik ;User Id = root;password ='marcell98'");
        
        public createuser()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            awal f1 = new awal();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string insertQuery = "insert into karyawan values('" + textBox3.Text + "','"+ textBox1.Text +"','"+ comboBox1.Text+"','"+ richTextBox1.Text +"','"+ textBox6.Text +"','" +textBox2.Text +"')";
            con.Open();
            MySqlCommand command = new MySqlCommand(insertQuery , con);
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Welcome , Have a Great Work!\nPlease,Login Immediately!");
                    awal f1 = new awal();
                    f1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Data is invalid \n Please Try Again!");
                    createuser f2 = new createuser();
                    f2.Show();
                    this.Hide();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
            
            con.Close();
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void createuser_Load(object sender, EventArgs e)
        {

        }
    }
}
