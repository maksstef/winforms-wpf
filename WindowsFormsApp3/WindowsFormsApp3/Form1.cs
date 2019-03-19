using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;

        public Form1()
        {
            InitializeComponent();

            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        List<ProductInfo> Cards = new List<ProductInfo>();

        //----------------------------------------------------------------------
        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text != "so")
                e.Cancel = true;
        }
        //----------------------------------------------------------------------


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                MessageBox.Show("enter data");
            else
            {
                Cards.Add(new ProductInfo()
                {
                    Name = textBox2.Text,
                    Number = Int32.Parse(textBox3.Text),
                    Size = Int32.Parse(textBox4.Text),
                    Weight = Int32.Parse(textBox5.Text),
                    Price = Int32.Parse(textBox6.Text)
                });
                label7.Text = $"{DateTime.Today} , save";
                MessageBox.Show("Complete!");
            }

        }

        private void serializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlSerializer XS = new XmlSerializer(typeof(List<ProductInfo>));
            using (FileStream FS = new FileStream("c:/temp/cards.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                XS.Serialize(FS, Cards);
            }

            label7.Text = $"{DateTime.Today} , serialize";
            MessageBox.Show("Serialization complete!");
        }

        private void pullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlSerializer XS = new XmlSerializer(typeof(List<ProductInfo>));
            using (FileStream FS = new FileStream("c:/temp/cards.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                Cards = (List<ProductInfo>)XS.Deserialize(FS);
            }
            label7.Text = $"{DateTime.Today} , pull";
            MessageBox.Show("Pull complete!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
            textBox1.Refresh();
        }

        //Find
        private void iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load("c:/temp/cards.xml");

            string FindingText = "";
            if (textBox7.Text == "")
            {
                MessageBox.Show("!!!");
            }
            else
            {
                FindingText = textBox7.Text;
            }
            string InfoIntext = "";

            foreach (var i in Cards)
            {
                //InfoIntext += i.Name + "\r\n" + i.Number + "\r\n" + i.Price + "\r\n" + i.Size + "\r\n" + i.Weight + "*";
                InfoIntext +=    "Name: " + i.Name + "\r\n" +
                                 "Number: " + i.Number + "\r\n" +
                                 "Price: " + i.Price + "\r\n" +
                                 "Size: " + i.Size + "\r\n" +
                                 "Weight: " + i.Weight + "*";
            }

            string[] CardsArr = InfoIntext.Split('*');
            Regex regex = new Regex(FindingText + @"(\w*)");

            foreach (var s in CardsArr)
            {
                MatchCollection matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        //MessageBox.Show(match.Value);
                        if(FindingText != "")
                        {
                            MessageBox.Show(s);
                        }
                    }
                }
                /*else
                {
                    MessageBox.Show("not found!");
                }*/
            }
            label7.Text = $"{DateTime.Today} , find";

        }



        //Sort by price
        private void sortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*XmlSerializer XS = new XmlSerializer(typeof(List<ProductInfo>));
            using (FileStream FS = new FileStream("c:/temp/cards.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                Cards = (List<ProductInfo>)XS.Deserialize(FS);
            }*/

            textBox1.Text = "";
            Cards.Sort();

            foreach(var i in Cards)
            {
                textBox1.Text += "Name: "+i.Name +"\r\n"+
                                 "Number: "+i.Number+"\r\n"+
                                 "Price: "+i.Price+"\r\n"+
                                 "Size: "+i.Size+"\r\n"+
                                 "Weight: "+i.Weight+"\r\n\r\n";
            }
            label7.Text = $"{DateTime.Today} , sort";
        }

        //SaveSearchResult
        private void saveSearchResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cards.Sort();
            XmlSerializer XS = new XmlSerializer(typeof(List<ProductInfo>));
            using (FileStream FS = new FileStream("c:/temp/cards_sort.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                XS.Serialize(FS, Cards);
            }



            XDocument doc = XDocument.Load("c:/temp/cards.xml");
            string FindingText = "";
            if (textBox7.Text == "")
            {
                MessageBox.Show("!!!");
            }
            else
            {
                FindingText = textBox7.Text;
            }
            string InfoIntext = "";

            foreach (var i in Cards)
            {
                //InfoIntext += i.Name + "\r\n" + i.Number + "\r\n" + i.Price + "\r\n" + i.Size + "\r\n" + i.Weight + "*";
                InfoIntext += "Name: " + i.Name + "\r\n" +
                                 "Number: " + i.Number + "\r\n" +
                                 "Price: " + i.Price + "\r\n" +
                                 "Size: " + i.Size + "\r\n" +
                                 "Weight: " + i.Weight + "*";
            }

            string[] CardsArr = InfoIntext.Split('*');
            Regex regex = new Regex(FindingText + @"(\w*)");
            string result = "";

            foreach (var s in CardsArr)
            {
                MatchCollection matches = regex.Matches(s);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        //MessageBox.Show(match.Value);
                        if (FindingText != "")
                        {
                            result +="\r\n"+s+"\r\n";
                        }
                    }
                }
            }

            using (FileStream fstream = new FileStream(@"C:\temp\cards_search.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(result);
                fstream.Write(array, 0, array.Length);
            }

            label7.Text = $"{DateTime.Today} , save SR";
            MessageBox.Show("Search/Sort results resorded!");
        }






        private void label3_Click(object sender, EventArgs e)
        {

        }

        //Name
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Primer validation
            ProductInfo pd = new ProductInfo();
            pd.Name = textBox2.Text;
            pd.IsValid(pd);
        }

        //Number
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //Size
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        //Weight
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //Price
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            label7.Text = $"{DateTime.Today} , about";
            MessageBox.Show("Version: 1.0.0.0 \r\n\r\nStefanenko M.S.");
        }

    }
}
