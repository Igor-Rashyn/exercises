using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double x;
        private double y;
        private string func = "Equals";
        private bool status=false;

        
        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}

 private void Number_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (status == false)
            {
                textBox1.Text = b.Text;
                if (b.Text!="0")
                status = true;
            }
            else
            {
                textBox1.Text = textBox1.Text + b.Text;
            }
        }

        private void Oppertion_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            y = Convert.ToInt64(textBox1.Text);
            switch (func)
            {
                case "Addition":
                    x = x + y;
                    break;
                case "Subtraction":
                    x = x - y;
                    break;
                case "Multiplication":
                    x = x * y;
                    break;
                case "Division":
                    x = x / y;
                    break;
                case "Equals":
                    x = y;
                    break;
            }
            if (y == 0 && func == "Division")
            {
                textBox1.Text = "ATA-TA!!!";
            }
            else 
            {
                textBox1.Text = Convert.ToString(x);
            }
            status = false;
            func = b.Name;
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            status = false;
            x = 0;
            y = 0;
            textBox1.Text = "0";
            func = "Equals";

        }

      
    }
}
