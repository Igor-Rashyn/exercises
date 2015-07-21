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
using System.Threading;

namespace WPBall
{
    public partial class MainPage : PhoneApplicationPage
    {
        System.Windows.Point point;
 
        public MainPage()
        {
            InitializeComponent();
        }

        private void canvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            point = e.GetPosition(MyPanel);
            Ball b = new Ball((int)point.X, (int)point.Y);
            canvas1.Children.Add(b);
            var tr = new Thread(b.Move);
            tr.Start();
        }
    


        
    }
}