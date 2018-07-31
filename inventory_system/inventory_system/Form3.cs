using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_system
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            Timer tm = new Timer();
            tm.Interval = 1000;
            tm.Tick += new EventHandler(changeImageSlide);
            tm.Tick += new EventHandler(changeColor);
            tm.Start();
        }

        public void changeImageSlide(object sender, EventArgs e) {
            //for Image Sliding

                    List<Bitmap> b1 = new List<Bitmap>();

                    b1.Add(Properties.Resources.gr1);
                    b1.Add(Properties.Resources.app1);
                    b1.Add(Properties.Resources.or1);
                    b1.Add(Properties.Resources.gr2);
                    b1.Add(Properties.Resources.app2);


                   int j = DateTime.Now.Second % 5;

                   pictureBox1.BackgroundImage = b1[j];

        }
        public void changeColor(object sender, EventArgs e)
        {
            //for Changing Color
            List<Color> c1 = new List<Color>();

            c1.Add(Color.Red);
            c1.Add(Color.Blue);
            c1.Add(Color.Green);
            int i = DateTime.Now.Second % 3;
            label3.ForeColor = c1[i];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("admin") && textBox2.Text.Equals("1234"))
            {
                Form4 f4 =new Form4();
                f4.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Info is not correct!!!!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {
                textBox2.UseSystemPasswordChar = false;
                    }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }

        }

        private void aBoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           

 

        }
    }
}
