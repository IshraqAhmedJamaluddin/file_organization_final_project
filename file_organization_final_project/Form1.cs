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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Create Button
        {
            Class1.filename = " E:\\" + textBox1.Text + ".txt"; // Get the file name from user if I insert file1 in textbox1 ,filename= E:\\file1.txt
            if (!File.Exists(Class1.filename)) // if the file does not exists 
            {
                File.Create(Class1.filename).Close();// We Should include using System.IO;
                MessageBox.Show("File is created");
            }
            else
                label2.Visible = true; // Error Message “ File Exists “ should set Lable2 : visible = false from properties window first
        }

        private void button2_Click(object sender, EventArgs e) // Insert Button
        {
            new Form2().Show();// Open Form 2
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) // Exit Button 
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e) // Delete Button 
        {
            Class1.filename = " E:\\" + textBox1.Text + ".txt"; // Get the file name from user if I insert file1 in textbox1 ,filename= E:\\file1.txt
            File.Delete(Class1.filename);
            MessageBox.Show("File is Deleted");
        }
    }
}
