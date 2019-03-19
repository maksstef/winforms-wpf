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
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Product pd = new Product();

        public Form1()
        {
            InitializeComponent();
            /*
            System.Windows.Forms.Button button1 = new System.Windows.Forms.Button(); // создаем контрол
            button1.Location = new System.Drawing.Point(101, 50); // устанавливаем необходимые свойства
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(button1_Click); // button1_Click - функция обработчик события нажатия на кнопку
            Controls.Add(button1);*/
        }

        /*Products name*/
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pd.ProductName = textBox1.Text;
        }

        /*Products date*/
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            pd.date = e.Start.Date;
        }

        /*Products weight*/
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label9.Text = String.Format("Текущее значение: {0}", trackBar1.Value);
            pd.ProductWeight = trackBar1.Value;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        /*Buttons (type of product)*/
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pd.ProductType = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pd.ProductType = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            pd.ProductType = radioButton3.Text;
        }

        /*Products count*/
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pd.Count = (int)numericUpDown1.Value;
        }

        /*Products price*/
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            pd.Price = Int32.Parse(textBox6.Text);
        }

        /*Products size*/
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            pd.ProductSize = Int32.Parse(textBox3.Text);
        }

        /*Profucts ID number*/
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pd.ProductNumber = Int32.Parse(textBox2.Text);
        }


        /*save info*/
        private void button1_Click(object sender, EventArgs e)
        {
            /*textBox4.Text = $"Name : {pd.ProductName}\r\n" +
                            $"Number : {pd.ProductNumber}\r\n" +
                            $"Size : {pd.ProductSize}\r\n" +
                            $"Weight : {pd.ProductWeight}\r\n" +
                            $"Type : {pd.ProductType}\r\n" +
                            $"Date : {pd.date}\r\n" +
                            $"Count : {pd.Count}\r\n" +
                            $"Price : {pd.Price}\r\n" +
                            $"Developer : {pd.Developer}\r\n\r\n" +
                            $"Worker : {ee.WorkerName} {ee.WorkerSurname} {ee.Patronymic}\r\n" +
                            $"Experience : {ee.WorkExperience}\r\n" +
                            $"Adress : {ee.Adress}";*/

            XmlSerializer formatter = new XmlSerializer(typeof(Product));

            using (FileStream fs = new FileStream("c:/temp/persons.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, pd);
            }
            
        }

        /*read info*/
        private void button2_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Product));

            using (FileStream fs = new FileStream("c:/temp/persons.xml", FileMode.OpenOrCreate))
            {
                Product newp = (Product)formatter.Deserialize(fs);

                textBox4.Text = $"Name : {newp.ProductName}\r\n" +
                                $"Number : {newp.ProductNumber}\r\n" +
                                $"Size : {newp.ProductSize}\r\n" +
                                $"Weight : {newp.ProductWeight}\r\n" +
                                $"Type : {newp.ProductType}\r\n" +
                                $"Date : {newp.date}\r\n" +
                                $"Count : {newp.Count}\r\n" +
                                $"Price : {newp.Price}\r\n" +
                                $"Developer : {newp.Developer}\r\n\r\n" +
                                $"Worker : {ee.WorkerName} {ee.WorkerSurname} {ee.Patronymic}\r\n" +
                                $"Experience : {ee.WorkExperience}\r\n" +
                                $"Adress : {ee.Adress}";
                MessageBox.Show("deserialization complete!");
            }
        }

        /*textarea*/
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*Product developer*/
        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            pd.Developer = domainUpDown1.Text;
        }

        Employee ee = new Employee();
        /*Employee*/
        /*WorkerName*/
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            ee.WorkerName = textBox5.Text;
        }

        /*surname*/
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            ee.WorkerSurname = textBox7.Text;
        }

        /*patronymic*/
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            ee.Patronymic = textBox8.Text;
        }

        /*experience*/
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            ee.WorkExperience = (int)numericUpDown2.Value;
        }

        /*adress*/
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ee.Adress = comboBox2.Text;
        }

        private void textBox2_key(object sender, KeyPressEventArgs e)
        {
           if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
           {
             e.Handled = true;
           }
        }




    }
}
