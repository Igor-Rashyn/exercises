using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WPPaintVector
{
    public class myFigure:Canvas
    {
        private string shapeF;
        private int height;
        private int width;
        private Point startPoint;
        private Point endPoint;
        private Color colorF;


        public string ShapeF   
        {
          get { return shapeF; }
          //set {shapeF = value;}
        }

        public int Height
        {
            get { return height; }
            //set {height = value;}
        }
        public int Width
        {
            get { return width; }
            //set {width = value;}
        }
        public Point StartPoint
        {
            get { return startPoint; }
            //set {width = value;}
        }
        public Point EndPoint
        {
            get { return endPoint; }
            //set {width = value;}
        }
        public Color ColorF
        {
            get { return colorF; }
            //set {width = value;}
        }


        public myFigure(Color color, string temShape, int temHeight, int temWidth, Point p, Point endP)
        {
            shapeF = temShape;
            colorF = color;
            endPoint = endP;
            startPoint = p;
            height = temHeight;
            width = temWidth;
            switch (temShape)
            {
                case "Circle":
                    Ellipse el = new Ellipse();
                     el.VerticalAlignment = VerticalAlignment.Stretch;
                     el.HorizontalAlignment = HorizontalAlignment.Stretch;
                     el.Stroke = new SolidColorBrush(colorF);
                     el.Margin = new Thickness(startPoint.X, startPoint.Y, 0, 0);
                    // el.Fill = new SolidColorBrush(Colors.Green);
                     el.Width = width;
                     el.Height = height;
                    // Canvas.SetLeft(el,(double)p.X);
                    // Canvas.SetTop(el,(double)p.Y);
                     this.Children.Add(el);
                    break;
                case "Rect":
                    Rectangle rc = new Rectangle();
                    rc.VerticalAlignment = VerticalAlignment.Stretch;
                    rc.HorizontalAlignment = HorizontalAlignment.Stretch;
                    rc.Stroke = new SolidColorBrush(colorF);
                    rc.Margin = new Thickness(startPoint.X, startPoint.Y, 0, 0);
                    rc.Width = width;
                    rc.Height = height;
                    this.Children.Add(rc);
                    break;
                case "Line":
                    var myLine = new Line();
                    myLine.Stroke = new SolidColorBrush(colorF);
                    myLine.X1 = startPoint.X;
                    myLine.X2 = endPoint.X;
                    myLine.Y1 = startPoint.Y;
                    myLine.Y2 = endPoint.Y;
                    myLine.HorizontalAlignment = HorizontalAlignment.Left;
                    myLine.VerticalAlignment = VerticalAlignment.Center;
                    myLine.StrokeThickness = 2;
                    this.Children.Add(myLine);
                    break;
                case "RoRc":
                    Rectangle rdrc= new Rectangle();
                    rdrc.VerticalAlignment = VerticalAlignment.Stretch;
                    rdrc.HorizontalAlignment = HorizontalAlignment.Stretch;
                    rdrc.Stroke = new SolidColorBrush(colorF);
                    rdrc.Margin = new Thickness(startPoint.X, startPoint.Y, 0, 0);
                    rdrc.Width = width;
                    rdrc.Height = height;
                    rdrc.RadiusX = 20;
                    rdrc.RadiusY = 20;
                    this.Children.Add(rdrc);                   
                    break;
            }
        }
            public void Move()
            {
            }
        

    }
}
