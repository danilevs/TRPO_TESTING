using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Testing
{
    public partial class Form1 : Form
    {
        double a;
        double b;
        double c;
        string s;


        string line, res;
        string[] lines = new string[2];
        int k = 0;
        bool longcoord = false;

        IConvertible inv = true;



        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty && textBox2.Text != String.Empty)
            {
                
                
                s = textBox1.Text;
                a = Convert.ToDouble(s);
                s = textBox2.Text;
                b = Convert.ToDouble(s);
                c = a + b;
                textBox3.Text = Convert.ToString(c);
            }
            else
            {
                MessageBox.Show("Введите значение!", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        public int DS_Count(string s)
        {
            string substr = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString();
            int count = (s.Length - s.Replace(substr, "").Length) / substr.Length;
            return count;
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int a1 = rnd.Next(0, 99);
            int b1 = rnd.Next(0, 99);
            int a2 = rnd.Next(0, 99);
            int b2 = rnd.Next(0, 99);

            textBox1.Text = a1.ToString() + "," + a2.ToString();
            textBox2.Text = b1.ToString() + "," + b2.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
