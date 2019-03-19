using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Calculator : Form
    {
        //https://vscode.ru/prog-lessons/kalkulyator-windows-forms-c-shapr.html
        //https://www.c-sharpcorner.com/article/create-basic-calculator-using-windows-forms-and-c-sharp/

        double number1;
        string Operation;

        public Calculator()
        {
            InitializeComponent();
            this.Load += LoadEvent;
        }

        private void LoadEvent(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "0";
            textBox1.Text = textBox1.Text + 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = textBox1.Text + 1;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text = textBox1.Text + 2;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text = textBox1.Text + 3;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text = textBox1.Text + 4;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text = textBox1.Text + 5;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text = textBox1.Text + 6;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text = textBox1.Text + 7;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text = textBox1.Text + 8;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text = textBox1.Text + 9;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text = textBox1.Text + ",";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                number1 = Double.Parse(textBox1.Text);
                textBox1.Text = "";
                Operation = "+";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                number1 = Double.Parse(textBox1.Text);
                textBox1.Text = "";
                Operation = "-";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                number1 = Double.Parse(textBox1.Text);
                textBox1.Text = "";
                Operation = "*";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                number1 = Double.Parse(textBox1.Text);
                textBox1.Text = "";
                Operation = "/";
            }
        }

        private void C_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                double number2;
                double result;

                number2 = Double.Parse(textBox1.Text);
                if (Operation == "+")
                {
                    result = number1 + number2;
                    textBox1.Text = Convert.ToString(result);
                    number1 = result;
                }
                if (Operation == "-")
                {
                    result = number1 - number2;
                    textBox1.Text = Convert.ToString(result);
                    number1 = result;
                }
                if (Operation == "*")
                {
                    result = number1 * number2;
                    textBox1.Text = Convert.ToString(result);
                    number1 = result;
                }
                if (Operation == "/")
                {
                    if (number2 == 0)
                    {
                        textBox1.Text = "mistake!";
                    }
                    else
                    {
                        result = number1 / number2;
                        textBox1.Text = Convert.ToString(result);
                        number1 = result;
                    }
                }
            }

        }

        bool flag = true;

        private void button8_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                    if(flag == true)
                    {
                            if (!textBox1.Text.Contains("-"))
                            {
                                number1 = number1 * -1;
                                textBox1.Text = "-" + textBox1.Text;
                                flag = false;
                            }
                    }
                    else
                    {
                        number1 = number1 * -1;
                        textBox1.Text = textBox1.Text.Replace("-", "");
                        flag = true;
                    }
            }
        }

        private void Load_Event2(object sender, EventArgs e)
        {

        }
    }
}
