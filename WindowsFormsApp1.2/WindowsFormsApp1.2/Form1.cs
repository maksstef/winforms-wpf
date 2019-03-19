using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1._2
{
    public partial class Form1 : Form
    {
        List<int> MyCollection = new List<int>();
        Random rand = new Random();
        
        
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "5";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //сортировка по убыванию
        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            MyCollection.Sort();
            MyCollection.Reverse();

            foreach(var i in MyCollection)
            {
                textBox2.Text += " " + Convert.ToString(i);
            }

        }

        //сортировка по возрастанию
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            MyCollection.Sort();
            foreach(var i in MyCollection)
            {
                textBox2.Text += " " + Convert.ToString(i);
            }
        }

        //сгенерировать коллекцию
        private void button1_Click(object sender, EventArgs e)
        {
            int count = Int32.Parse(textBox1.Text);
            textBox3.Text = "";
            for (int i = 0; i < count; ++i)
            {
                MyCollection.Add(rand.Next(1, 20));
            }
            foreach(var i in MyCollection)
            {
                textBox3.Text = textBox3.Text +" "+Convert.ToString(i);
            }
        }

        //запрос 1
        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox3.Text != "")
            {
                textBox2.Text = "";
                textBox2.Text = Convert.ToString(MyCollection.Max());
            }
        }

        //запрос2
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                textBox2.Text = "";
                textBox2.Text = Convert.ToString(MyCollection.Sum());
            }
        }

        //запрос3
        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox3.Text != "")
            {
                textBox2.Text = "";
                textBox2.Text = Convert.ToString(MyCollection.Min());
            }
        }
    }
}
