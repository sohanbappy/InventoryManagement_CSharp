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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
   //     SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Inventory;Integrated Security=True;");

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // grapes for insert...........................
            if (comboBox1.Text == "Grapes")
            {
                double txt, txt2;
                txt = Convert.ToInt32(textBox2.Text);
                double sum = 0;
                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {
                    sum += Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);

                }


                txt2 = sum + txt;
                if (txt2 <= 300)
                {
                    DbConnection.con.Open();

                    string query3 = "insert into Gra_store(id,name,amount,price,total,input_date,expire_date) values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "')";
                    SqlDataAdapter SDA3 = new SqlDataAdapter(query3, DbConnection.con);
                    SDA3.SelectCommand.ExecuteNonQuery();
                    DbConnection.con.Close();
                    MessageBox.Show("insert successfull");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    double limt;
                    limt = 500 - sum;
                    MessageBox.Show("Sorry your storage limited!! you can store maximum:=" + limt.ToString());

                }
            }

            // for orange insert.......................

            else if (comboBox1.Text == "Orange")
            {
                double txt, txt2;
                txt = Convert.ToInt32(textBox2.Text);
                double sum = 0;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);

                }


                txt2 = sum + txt;
                if (txt2 <= 500)
                {
                    DbConnection.con.Open();

                    string query2 = "insert into Ora_store(id,name,amount,price,total,input_date,expire_date) values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "')";
                    SqlDataAdapter SDA = new SqlDataAdapter(query2, DbConnection.con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    DbConnection.con.Close();
                    MessageBox.Show("insert successfull");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    double limt;
                    limt = 400 - sum;
                    MessageBox.Show("Sorry your storage limited!! you can store maximum:=" + limt.ToString());

                }
            }



            // for apple insert........................................

            else if (comboBox1.Text == "Apple")
            {
                double txt, txt2;
                txt = Convert.ToInt32(textBox2.Text);
                double sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);

                }


                txt2 = sum + txt;
                if (txt2 <= 500)
                {


                    DbConnection.con.Open();

                    DateTime today = Convert.ToDateTime(dateTimePicker1.Text);
                    DateTime exp_date = today.AddDays(10);

                    dateTimePicker2.Text = exp_date.ToString();



                    string query1 = "insert into App_store(id,name,amount,price,total,input_date,expire_date) values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "')";
                    SqlDataAdapter SDA = new SqlDataAdapter(query1, DbConnection.con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    DbConnection.con.Close();
                    MessageBox.Show("insert successfull");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    double limt;
                    limt = 500 - sum;
                    MessageBox.Show("Sorry your storage limited!! you can store maximum:=" + limt.ToString());

                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = (double.Parse(textBox2.Text) * double.Parse(textBox3.Text)).ToString();
            }
            catch
            {
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = (double.Parse(textBox2.Text) * double.Parse(textBox3.Text)).ToString();
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //for orange storeage view
            DbConnection.con.Open();
            string query2 = "select * from Ora_store";
            SqlDataAdapter SDA2 = new SqlDataAdapter(query2, DbConnection.con);
            DataTable dt2 = new DataTable();
            SDA2.Fill(dt2);
            dataGridView2.DataSource = dt2; 






            //for apple storage view

            string query1 = "select * from App_store";
            SqlDataAdapter SDA = new SqlDataAdapter(query1, DbConnection.con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;




            //for grapes storage view

            string query3 = "select * from Gra_store";
            SqlDataAdapter SDA3 = new SqlDataAdapter(query3, DbConnection.con);
            DataTable dt3 = new DataTable();
            SDA3.Fill(dt3);
            dataGridView3.DataSource = dt3;
            DbConnection.con.Close();

            // calculation for apple storage................
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);

            }
            button3.Text = sum.ToString();

            //calculation for orange...........................
            double sum2 = 0;
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                sum2 += Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);

            }
            button4.Text = sum2.ToString();

            //calculation for Grapes storage.......................
            double sum3 = 0;
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                sum3 += Convert.ToDouble(dataGridView3.Rows[i].Cells[2].Value);

            }
            button5.Text = sum3.ToString();


            //rotten message for apple storage.....................................

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DateTime from = Convert.ToDateTime(dataGridView1.Rows[i].Cells[6].Value);
                DateTime to = DateTime.Now.Date;
                TimeSpan tspan = from - to;
                double days = tspan.TotalDays;
                string idn = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                string fname = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                if (days <= 3)
                {
                    MessageBox.Show("your fruits are rottening where your id="+idn+"fruit="+fname+"Expire Date ="+from);


                }
            }
            //for orange rotten info
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                DateTime from = Convert.ToDateTime(dataGridView2.Rows[i].Cells[6].Value);
                DateTime to = DateTime.Now.Date;
                TimeSpan tspan = from - to;
                double days = tspan.TotalDays;
                string idn = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
                string fname = Convert.ToString(dataGridView2.Rows[i].Cells[1].Value);
                if (days == 3)
                {
                    MessageBox.Show("your fruits are rotten where your id=" + idn + "fruit=" + fname + "Date=" + from);


                }
            }
            // for grapes rotten info
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                DateTime from = Convert.ToDateTime(dataGridView3.Rows[i].Cells[6].Value);
                DateTime to = DateTime.Now.Date;
                TimeSpan tspan = from - to;
                double days = tspan.TotalDays;
                string idn = Convert.ToString(dataGridView3.Rows[i].Cells[0].Value);
                string fname = Convert.ToString(dataGridView3.Rows[i].Cells[1].Value);
                if (days == 3)
                {
                    MessageBox.Show("your fruits are rotten where your id=" + idn + "fruit=" + fname + "Date=" + from);


                }
            }
            }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
            MessageBox.Show("Thank You!!!!!!!!!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void dateTimePicker1_MouseLeave(object sender, EventArgs e)
        {
           
        }
    }
        }
    

