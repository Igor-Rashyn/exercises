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

namespace WPPaintVector
{
    public partial class MainPage : PhoneApplicationPage
    {
        myFigure figure;
        string type;
        Point startP;
        Color cl;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void canvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startP = e.GetPosition(canvas1);
        }

        private void canvas1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var endP = e.GetPosition(canvas1);
            figure = new myFigure(cl, type, Convert.ToInt32(endP.X - startP.X), Convert.ToInt32(endP.Y - startP.Y), startP, endP);
            canvas1.Children.Add(figure);
            
        }

        private void SelectionShape_Click(object sender, RoutedEventArgs e)
        {
            Button bb = (Button)sender;
            type = (string)bb.Content;
            type = type.Trim(new Char[] { '"', '*', '.' });
        }

        private void SavetoXML_Click(object sender, RoutedEventArgs e)
        {        
            var fg = canvas1.Children.OfType<myFigure>().ToList();
            DS_XML file = new DS_XML();
            file.Save(fg);
        }

        private void LoadFromXML_Click(object sender, RoutedEventArgs e)
        {
            DS_XML file = new DS_XML();
            var listFigur = file.Load();
            foreach (myFigure fgg in listFigur)
            {
                this.canvas1.Children.Add(fgg);
            }
        }

        private void SelectColor_Click(object sender, RoutedEventArgs e)
        {
            Button bb = (Button)sender;
            Brush newColor = bb.Background;
            SolidColorBrush newBrush = (SolidColorBrush)newColor;
            cl = newBrush.Color;
        }


    }
}