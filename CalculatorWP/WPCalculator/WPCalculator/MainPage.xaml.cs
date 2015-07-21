using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace WPCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        
        private bool status = false;
        private string func = "Equals";
        private double x;
        private double y;

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (status == false)
            {
                textBox1.Text = (string)b.Content;
                if ((string)b.Content != "0")
                    status = true;
            }
            else
            {
                textBox1.Text = textBox1.Text + (string)b.Content;
            }
        }


        private void Oppertion_Click(object sender, RoutedEventArgs e)
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

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            status = false;
            x = 0;
            y = 0;
            textBox1.Text = "0";
            func = "Equals";

        }

    }
}