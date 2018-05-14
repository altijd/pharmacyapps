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
    public partial class obat : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source = localhost;port=3306;Initial Catalog = db_apotik ;User Id = root;password ='marcell98'");

        public obat(string Str_Value)
        {
            InitializeComponent();
            textBox8.Text = Str_Value;
        }

        private void obat_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string insertQuery1 = "insert into obat  values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + this.dateTimePicker1.Text + "')";
            con.Open();
            MySqlCommand command1 = new MySqlCommand(insertQuery1, con);
            command1.ExecuteNonQuery();
            MessageBox.Show("Insert Successfull!");
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = ""; 


        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            string updateQuery1 = "update obat  set  merkObat = '" + textBox2.Text + "',jenisObat ='" + comboBox1.Text + "', expDate ='" + this.dateTimePicker1.Text + "' where kodeObat ='" + textBox1.Text + "'";
            con.Open();
            MySqlDataAdapter msda1 = new MySqlDataAdapter(updateQuery1, con);
            msda1.SelectCommand.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Update Successfull!");
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            textBox1.Enabled = true;

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            string showquery = " select * from obat ";

            MySqlCommand cmd = new MySqlCommand(showquery, con);

            con.Open();

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            con.Open();
            string deleteQuery2 = " delete from obat where kodeObat = '" + textBox1.Text + "' ";
            
            MySqlDataAdapter dq2 = new MySqlDataAdapter(deleteQuery2, con);
            
            dq2.SelectCommand.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Delete Successfull!");
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Enabled = false;

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Form1 f8 = new Form1(textBox8.Text);
            f8.Show();
            this.Hide();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            awal f3 = new awal();
            f3.Show();
            this.Hide();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            access f9 = new access(textBox8.Text);
            f9.Show();
            this.Hide();

           // karyawan f8 = new karyawan(textBox8.Text);
            //f8.Show();
            //this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            Supplier f7 = new Supplier(textBox8.Text);
            f7.Show();
            this.Hide();
        }
    }
}
