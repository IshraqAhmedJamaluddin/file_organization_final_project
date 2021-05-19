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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = Class1.filename;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BinaryReader br = new BinaryReader(File.Open(Class1.filename, FileMode.Open, FileAccess.Read));
                int num_of_records = (int)br.BaseStream.Length / Class1.rec_size;
                if (num_of_records > 0) // If The file Not Empty
                {
                    button1.Text = "Next";// Change the Button Text
                    label9.Text = num_of_records.ToString(); // Number of Records Label
                    label10.Text = br.BaseStream.Length.ToString(); // File Size Lable
                    br.BaseStream.Seek(Class1.count, SeekOrigin.Begin); // Move to Specific Position in a File

                    textBox2.Text = br.ReadInt32().ToString(); // Read ID and display it in the textbox2

                    textBox3.Text = br.ReadString(); // Read Name 
                    textBox4.Text = br.ReadString(); // Read Tel
                    textBox5.Text = br.ReadInt32().ToString(); // Read Year

                    textBox6.Text = br.ReadString(); // Read Gender


                    if ((Class1.count / Class1.rec_size) >= (num_of_records - 1)) // If I reach the End of file , Go to the Beginning of file
                        Class1.count = 0;
                    else
                        Class1.count += Class1.rec_size;

                }
                else MessageBox.Show("Empty File");
                br.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)//Back Button
        {
            new Form1().Show();
            this.Hide();
        }

    }
}
