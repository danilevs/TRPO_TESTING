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
            e.Handled = !(e.KeyChar == 8 || Char.IsDigit(e.KeyChar) || ((e.KeyChar == System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]) && (DS_Count(((TextBox)sender).Text) < 1)));
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(e.KeyChar == 8 || Char.IsDigit(e.KeyChar) || ((e.KeyChar == System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]) && (DS_Count(((TextBox)sender).Text) < 1)));


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"counters.txt";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);



                while (((line = sr.ReadLine()) != null) && k != 2)
                {
                    lines[k] = line;
                    k++;
                }

                if (lines[0] != null && lines[1] == null)
                {
                    MessageBox.Show("В файле содержится только одно слагаемое", "Введите второе слагаемое", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    longcoord = true;
                }

                if (lines[0] == "" && !(lines[1] == "" || lines[1] == null))
                {
                    MessageBox.Show("В файле содержится только одно слагаемое", "Введите первое слагаемое", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    longcoord = true;
                }

                if (longcoord == false)
                {

                    if (lines[1] != "")
                    {
                        try
                        {
                            double resu = Convert.ToDouble(lines[0]);

                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Слагаемые введены неверно!", "Неверный формат слагаемых", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            longcoord = true;
                        }
                    }


                    if (lines[1] != "" || lines[1] != null)
                    {
                        try
                        {
                            double resu1 = Convert.ToDouble(lines[1]);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Слагаемые введены неверно!", "Неверный формат слагаемых", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            longcoord = true;
                        }
                    }
                }

                if ((lines[0] == null && lines[1] == null))
                {
                    MessageBox.Show("В файле нет данных", "Файл пуст!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (longcoord == false)
                {
                    if ((Convert.ToDouble(lines[0]) < 0 || Convert.ToDouble(lines[1]) < 0))
                    {
                        MessageBox.Show("В файле содержатся отрицательные числа", "Неверный формат слагаемых", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        longcoord = true;
                    }
                }

                if (lines[1] != null)
                {
                    if (lines[0].Length > 5 || lines[1].Length > 5)
                    {
                        MessageBox.Show("Все значения должны быть не более 5 знаков", "Большое значение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        longcoord = true;
                    }
                }

                if (k == 2 && lines[0] != "" && lines[1] != "" && lines[1] != null && longcoord == false)
                {
                    textBox1.Text = lines[0];
                    textBox2.Text = lines[1];
                }

                sr.Close();
            }
            else
            {
                MessageBox.Show("Создайте текстовый файл counters.txt и введите в него данные", "Отсутствует файл входных значений", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            string path1 = @"result.txt";
            FileStream outtxt = new FileStream($"{path1}", FileMode.OpenOrCreate);

            res = textBox3.Text;

            if (textBox3.Text !="") {

                byte[] array = System.Text.Encoding.Default.GetBytes(res);
                outtxt.Write(array, 0, array.Length);

                MessageBox.Show("Запись в файл была произведена успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                outtxt.Close();
            }
            else
            {
                MessageBox.Show("Записывать в файл нечего", "Пусто", MessageBoxButtons.OK, MessageBoxIcon.Information);
                outtxt.Close();
            }
        }
    }
}
