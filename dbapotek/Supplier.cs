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
    public partial class Supplier : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source = localhost;port=3306;Initial Catalog = db_apotik ;User Id = root;password ='marcell98'");

        public Supplier(string Str_Value)
        {
            InitializeComponent();
            textBox8.Text = Str_Value;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string insertQuery1 = "insert into supplier  values('" + textBox3.Text + "','" + textBox1.Text + "','"  + textBox2.Text + "')";
            con.Open();
            MySqlCommand command1 = new MySqlCommand(insertQuery1, con);
            command1.ExecuteNonQuery();
            MessageBox.Show("Insert Successfull!");
            con.Close();
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            string updateQuery1 = "update supplier  set nama_pabrik= '" + textBox1.Text  + "', kontak ='" + textBox2.Text + "' where id_supplier ='" + textBox3.Text + "'";
            con.Open();
            MySqlDataAdapter msda1 = new MySqlDataAdapter(updateQuery1, con);
            msda1.SelectCommand.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Update Successfull!");

            textBox3.Enabled = true;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            con.Open();
            string deleteQuery2 = " delete from supplier where id_supplier = '" + textBox3.Text + "' ";

            MySqlDataAdapter dq2 = new MySqlDataAdapter(deleteQuery2, con);

            dq2.SelectCommand.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Delete Successfull!");
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            string showquery = " select * from supplier ";

            MySqlCommand cmd = new MySqlCommand(showquery, con);

            con.Open();

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            obat f6 = new obat(textBox8.Text);
            f6.Show();
            this.Hide();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            karyawan f8 = new karyawan(textBox8.Text);
            f8.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Form1 f8 = new Form1(textBox8.Text);
            f8.Show();
            this.Hide();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            login f3 = new login();
            f3.Show();
            this.Hide();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox3.Enabled = false;

            textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void bunifuFlatButton8_Click_1(object sender, EventArgs e)
        {
            access f9 = new access(textBox8.Text);
            f9.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            textBox3.Enabled = false;

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void bunifuFlatButton6_Click_1(object sender, EventArgs e)
        {
            obat f6 = new obat(textBox8.Text);
            f6.Show();
            this.Hide();
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            Supplier f7 = new Supplier(textBox8.Text);
            f7.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            Form1 f8 = new Form1(textBox8.Text);
            f8.Show();
            this.Hide();
        }

        private void bunifuFlatButton7_Click_1(object sender, EventArgs e)
        {
            awal f3= new awal();
            f3.Show();
            this.Hide();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
