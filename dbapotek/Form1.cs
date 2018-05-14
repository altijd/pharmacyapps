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
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source = localhost;port=3306;Initial Catalog = db_apotik ;User Id = root;password ='marcell98'");

        public Form1(string Str_Value)
        {
            InitializeComponent();
            textBox8.Text = Str_Value;
          
        
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
            string insertQuery1 = "insert into transaksi (kd_transaksi,kd_obat,id_supplier,jml_obat,harga) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox5.Text + "','" + textBox7.Text + "')";
            string insertQuery2 = "insert into obat  values('" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + this.dateTimePicker1.Text + "')";
            string insertQuery3 = "insert into supplier  values('" + textBox1.Text + "','" + textBox6.Text + "','" + textBox9.Text + "')";
            string insertQuery4 = "update transaksi set nip = (select nip from karyawan where username='" + textBox8.Text + "') where kd_transaksi = '"+ textBox2.Text +"'";

            con.Open(); 
            MySqlCommand command1 = new MySqlCommand(insertQuery3, con);
            MySqlCommand command2 = new MySqlCommand(insertQuery2, con);
            MySqlCommand command3 = new MySqlCommand(insertQuery1, con);
            MySqlCommand command4 = new MySqlCommand(insertQuery4, con);

            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            command4.ExecuteNonQuery();


            MessageBox.Show("Insert Successfull!");
            
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
        }

        private void bunifuGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            awal f3 = new awal();
            f3.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            string showquery = " select transaksi.kd_transaksi,transaksi.id_supplier,obat.kodeObat,obat.merkObat,obat.jenisObat,obat.ExpDate,transaksi.jml_obat,transaksi.harga , supplier.nama_pabrik,supplier.kontak from transaksi,obat,supplier,karyawan where transaksi.kd_obat=obat.kodeObat and transaksi.id_supplier =  supplier.id_supplier and karyawan.NIP= transaksi.nip "; 
           
            MySqlCommand cmd = new MySqlCommand(showquery, con);

            con.Open();

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter (cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
            con.Open();
            string updateQuery1 = "update transaksi set kd_obat = '" + textBox3.Text + "',jml_obat= '" + textBox5.Text + "',harga = '" + textBox7.Text + "',id_supplier ='" + textBox1.Text +"' where kd_transaksi= '" + textBox2.Text + "'";
            string updateQuery2 = "update obat  set kodeObat ='" + textBox3.Text + "', merkObat = '" + textBox4.Text + "',jenisObat ='" + comboBox1.Text + "', expDate ='" + this.dateTimePicker1.Text + "' where kodeObat = (select kd_obat from transaksi where  kd_transaksi='" + textBox2.Text + "')";
            string updateQuery3 = "update supplier  set id_supplier = '" + textBox1.Text + "' ,nama_pabrik = '" + textBox6.Text + "',kontak= '" + textBox9.Text + "' where id_supplier = (select id_supplier from transaksi where kd_transaksi='" + textBox2.Text + "')";
            //string updateQuery4 = "update transaksi set nip = (select nip from karyawan where username='" + textBox8.Text + "') where kd_transaksi = '" + textBox2.Text + "'";
             
            MySqlDataAdapter msda1 = new MySqlDataAdapter(updateQuery1, con);
            MySqlDataAdapter msda2 = new MySqlDataAdapter(updateQuery2, con);
            MySqlDataAdapter msda3 = new MySqlDataAdapter(updateQuery3, con);

            msda3.SelectCommand.ExecuteNonQuery();
            msda2.SelectCommand.ExecuteNonQuery();
            msda1.SelectCommand.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Update Successfull!");

            textBox2.Enabled = true;


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";

            
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            con.Open();
            string deleteQuery1 = " delete from transaksi where kd_transaksi = '" + textBox2.Text + "'";
            string deleteQuery2 = " delete from obat where kodeObat = '" + textBox3.Text + "' ";
            string deleteQuery3 = " delete from supplier  where id_supplier =  '" + textBox1.Text + "' ";

            MySqlDataAdapter dq1 = new MySqlDataAdapter(deleteQuery1, con);
            MySqlDataAdapter dq2 = new MySqlDataAdapter(deleteQuery2, con);
            MySqlDataAdapter dq3 = new MySqlDataAdapter(deleteQuery3, con);

            dq1.SelectCommand.ExecuteNonQuery();
            dq2.SelectCommand.ExecuteNonQuery();
            dq3.SelectCommand.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Delete Successfull!");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Enabled = false;

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            obat f6 = new obat(textBox8.Text);
            f6.Show();
            this.Hide();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            access f9 = new access(textBox8.Text);
            f9.Show();

           // karyawan f8 = new karyawan(textBox8.Text);
            //f8.Show();
            this.Hide();
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            Supplier f7 = new Supplier(textBox8.Text);
            f7.Show();
            this.Hide();
        }
    }
}
