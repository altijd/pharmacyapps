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
    public partial class user : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source = localhost;port=3306;Initial Catalog = db_apotik ;User Id = root;password ='marcell98'");
        
        public user()
        {
            InitializeComponent();

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string showquery = " select * from obat where merkObat ='" + textBox1.Text + "' ";

            MySqlCommand cmd = new MySqlCommand(showquery, con);

            con.Open();

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string updateQuery = "update transaksi set jml_obat = jml_obat - '" + textBox4.Text + "' where kd_obat = (select kodeObat from obat where merkObat = '" + textBox1.Text + "')";

            MySqlCommand msda1 = new MySqlCommand(updateQuery, con);
            msda1.ExecuteNonQuery();

            string  updateQuery1 = "select sum('"+ textBox4.Text + "' *(select harga from transaksi where kd_obat = (select kodeObat from obat where merkObat = '" + textBox1.Text + "'))as '" + textBox2.Text + "' from transaksi";
            MySqlCommand msda2 = new MySqlCommand(updateQuery1, con);
            msda2.ExecuteNonQuery();

            con.Close();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            awal f4 = new awal();
            f4.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfull!");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            awal f3 = new awal();
            f3.Show();
            this.Hide();
        }
    }
}
