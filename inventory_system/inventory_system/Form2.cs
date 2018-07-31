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

namespace inventory_system
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            showAll();
        }

        public void showAll()
        {
            //for orange storeage view
            DbConnection.con.Open();
            string query2 = "select * from Ora_store";
            SqlDataAdapter SDA2 = new SqlDataAdapter(query2, DbConnection.con);
            DataTable dt2 = new DataTable();
            SDA2.Fill(dt2);
            dataGridView3.DataSource = dt2;






            //for apple storage view

            string query1 = "select * from App_store";
            SqlDataAdapter SDA = new SqlDataAdapter(query1, DbConnection.con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView2.DataSource = dt;




            //for grapes storage view

            string query3 = "select * from Gra_store";
            SqlDataAdapter SDA3 = new SqlDataAdapter(query3, DbConnection.con);
            DataTable dt3 = new DataTable();
            SDA3.Fill(dt3);
            dataGridView4.DataSource = dt3;
            DbConnection.con.Close();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Inventory;Integrated Security=True;");
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id,amnt,id2,a2,sub;

            id =Convert.ToInt32(textBox2.Text);
            amnt = Convert.ToInt32(textBox3.Text);

           

            Form1 ob1 = new Form1();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                id2 =Convert.ToInt32( dataGridView1.Rows[i].Cells[0].Value);
                if (id2 == id)
                {
                    //ob1.a2= Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);

                    //sub = a2 - amnt;
                    //textBox2.Text = Convert.ToString(sub);

                    con.Open();
                    string query4 = "insert into App_store(amount)values(textBox2.Text)";
                    SqlDataAdapter SDAt = new SqlDataAdapter(query4, con);
                    SDAt.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    
            con.Open();

            string query1 = "insert into sell_info(id,f_id,f_name,amount,price,total,f_date) values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "')";
            SqlDataAdapter SDA = new SqlDataAdapter(query1, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("insert successfull");


        }

    }

}

        private void Form2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query1 = "select * from sell_info";
            SqlDataAdapter SDA = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            SDA.Fill(dt1);
            dataGridView1.DataSource = dt1;
            con.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query1 = "delete from sell_info where id='" + textBox1.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query1, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete successful!!!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query1 = "update sell_info set f_id='" + textBox2.Text + "',f_name='"+comboBox1.Text+"',amount='"+textBox3.Text+"',price='" + textBox4.Text + "',total='" + textBox5.Text + "',f_date='" + dateTimePicker1.Text + "'where id='" + textBox1.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query1, con);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("update success!!!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
            MessageBox.Show("Thank You!!!!!!!!!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
