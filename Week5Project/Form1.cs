using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Week5Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Initialize path in a global level
        string path = Environment.CurrentDirectory + "/" + "WorldCupRecords.txt";
        private void button1_Click(object sender, EventArgs e)
        {
            
            if(!File.Exists(path))
            {
                File.CreateText(path );
                MessageBox.Show("File created successfully");
            }
            else
            {
                MessageBox.Show("File Already exists");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(File.Exists(path))
            {
                File.Delete(path);
                MessageBox.Show("Delete File");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{0} ",comboBox1.Text);
            stringBuilder.AppendFormat("{0} ", textBox1.Text);
            stringBuilder.AppendFormat("{0} ", textBox2.Text);
            stringBuilder.AppendFormat("{0} ", textBox3.Text);
            stringBuilder.Append(textBox4.Text);
            stringBuilder.AppendLine();

            File.AppendAllText(path, stringBuilder.ToString());

            comboBox1.ResetText();

            foreach (var control in this.Controls)
            {
                var textBox = control as TextBox;

                if(textBox != null)
                {
                    textBox.Clear();
                }
            }

            MessageBox.Show("Added");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            StreamReader worldCupWinner = new StreamReader(path);
            richTextBox1.Text = worldCupWinner.ReadToEnd();

            worldCupWinner.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = new Bitmap(ofd.FileName);
                pictureBox1.Image = bit;
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
    }
}
//List<string> winners = new List<string>();
//File.WriteAllLines(path, winners, comboBox1.Text + "  " +  textBox1.Text +" " +  textBox2.Text + " " + textBox3.Text + " " + textBox4.Text).ToString();
//MessageBox.Show("Added");