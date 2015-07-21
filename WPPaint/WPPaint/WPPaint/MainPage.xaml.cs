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
using System.IO.IsolatedStorage;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace WPPaint
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor

        System.Windows.Point startPoint, endPoint;
        private bool stratDraw = false;
        PhotoChooserTask photoChooserTask;


        public MainPage()
        {
            InitializeComponent();
            photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += PhotoChooserTaskCompleted;

        }

        private void canvas1_MouseMove(object sender, MouseEventArgs e)
        {
            startPoint = e.GetPosition(this.canvas1);

            Line line = new Line() { X1 = startPoint.X, Y1 = startPoint.Y, X2 = endPoint.X, Y2 = endPoint.Y };
            line.Stroke = new SolidColorBrush(Colors.Red);
            line.StrokeThickness = 7;

            this.canvas1.Children.Add(line);
            endPoint = startPoint;
        }

        private void canvas1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void canvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(canvas1);
            endPoint = startPoint;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            int imageNumber = 0;
            settings.TryGetValue<int>("PreviousImageNumber", out imageNumber);
            imageNumber++;

            MediaLibrary library = new MediaLibrary();
            WriteableBitmap wbmp = new WriteableBitmap(canvas1,null);

            MemoryStream ms = new MemoryStream();
            Extensions.SaveJpeg(wbmp, ms, wbmp.PixelWidth, wbmp.PixelHeight, 0, 100);
            ms.Seek(0, SeekOrigin.Begin);
            library.SavePicture(string.Format("Images\\{0}.jpg", imageNumber), ms);

            settings["PreviousImageNumber"] = imageNumber;
            settings.Save();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            photoChooserTask.Show();
        }

        private void PhotoChooserTaskCompleted(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                var bitmap = new WriteableBitmap(464, 441);
                Extensions.LoadJpeg(bitmap, e.ChosenPhoto);
                var image = new Image();
                image.Source = bitmap;

                Canvas.SetLeft(image, 10);
                Canvas.SetTop(image, 10);
                canvas1.Children.Add(image);
            }
        }

    }
}