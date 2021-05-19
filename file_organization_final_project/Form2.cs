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

namespace file_organization_final_project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Class1.filename;
        }

        private void button2_Click(object sender, EventArgs e) //back Button
        {
            new Form1().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) // Save Button
        {

            BinaryWriter bw = new BinaryWriter(File.Open(Class1.filename, FileMode.Open, FileAccess.Write)); // We Should include using System.IO;
            int length = (int)bw.BaseStream.Length;


            if (length == 0) // if File is Empty insert fe awl el file
            {
                bw.Write(int.Parse(textBox2.Text)); // ID text box
                textBox3.Text = textBox3.Text.PadRight(9); // Name Textbox
                bw.Write(textBox3.Text.Substring(0, 9));

                textBox4.Text = textBox4.Text.PadRight(11);// Tel textbox
                bw.Write(textBox4.Text.Substring(0, 11));


                bw.Write(int.Parse(textBox5.Text));// Year Textbox

                bw.Write(textBox6.Text.Substring(0, 1)); // Gender Textbox

                length += Class1.rec_size;

            }
            else
            {
                bw.BaseStream.Seek(length, SeekOrigin.Begin);// hymshy 32 bit (record size) w b3d keda yktb
                bw.Write(int.Parse(textBox2.Text));
                textBox3.Text = textBox3.Text.PadRight(9);
                bw.Write(textBox3.Text.Substring(0, 9));

                textBox4.Text = textBox4.Text.PadRight(11);
                bw.Write(textBox4.Text.Substring(0, 11));


                bw.Write(int.Parse(textBox5.Text));

                bw.Write(textBox6.Text.Substring(0, 1));
                length += Class1.rec_size;

            }

            textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
            label9.Text = (length / Class1.rec_size).ToString();// update number of records label
            label10.Text = length.ToString();//update file length label
            MessageBox.Show("Data is saved successfully");
            bw.Close();

        }

    }
}
