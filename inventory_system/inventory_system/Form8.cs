using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace inventory_system
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Document Doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter.GetInstance(Doc, new FileStream("Report.pdf", FileMode.Create));
                Doc.Open();

                var chartImage = new MemoryStream();
                chart1.SaveImage(chartImage, ChartImageFormat.Png);
                iTextSharp.text.Image CI = iTextSharp.text.Image.GetInstance(chartImage.GetBuffer());
                Doc.Add(CI);



                Doc.Close();

                MessageBox.Show("Check ur default Folder", "PDF");

            }
            catch
            {
                MessageBox.Show("Something went wrong !!");
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string query1 = "Select f_name,Sum(amount) as Sold_Quantity From sell_info Group By f_name";
            SqlCommand cmd1 = new SqlCommand(query1, DbConnection.con);
            SqlDataReader rdr1;

            try
            {
                DbConnection.con.Open();
                rdr1 = cmd1.ExecuteReader();
                while (rdr1.Read())
                {
                    this.chart1.Series["Sold Quantity"].Points.AddXY(rdr1.GetString(0), rdr1.GetInt32(1));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DbConnection.con.Close();
            }
        }
    }
}
