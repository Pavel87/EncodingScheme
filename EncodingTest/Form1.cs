using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EncodingTest
{
    public partial class Form1 : Form
    {
        private bool test;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Encoding enc = null;
            String countryCode = null;
            int ccCode = 0;

            countryCode = textBox2.Text;
            //1257
            try
            {
                ccCode = Convert.ToInt16(countryCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Country Code has wrong format");
            }

            if (ccCode != 0 && countryCode.Length > 2)
            {
                test = true;
                try
                {
                    enc = System.Text.Encoding.GetEncoding(ccCode);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                    textBox1.Text = ex.ToString();
                    test = false;
                }

                if (test)
                {
                    textBox1.Text = enc.WebName;
                }
            }
            else
            {
                textBox1.Text = "Enter at least 3 digits(i.e.1250)";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter 3 and more digits code representing codepage. In case you will get exception the code page is not supported at this device");
        }

    }
}