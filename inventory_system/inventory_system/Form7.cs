using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_system
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
            MessageBox.Show("Thank You!!!!!!!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DGVPrinter pr = new DGVPrinter();
            pr.Title = "Order Details\n\n\n";
            pr.SubTitle = string.Format("Date: {0}", DateTime.Now.ToShortDateString());
            pr.PageNumbers = true;
            pr.PageNumberInHeader = false;
            pr.PorportionalColumns = true;
            pr.HeaderCellAlignment = StringAlignment.Near;
            pr.Footer = "Created by Garbage";
            pr.FooterSpacing = 10;
            pr.PrintDataGridView(dataGridView1);


            MessageBox.Show("Pdf Creadted !!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbConnection.con.Open();
            string query2 = "select * from sell_info Where del_date BETWEEN  '"+dateTimePicker1.Text+ "' and '" + dateTimePicker2.Text + "' ";
            SqlDataAdapter SDA2 = new SqlDataAdapter(query2, DbConnection.con);
            DataTable dt2 = new DataTable();
            SDA2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }
    }
}
