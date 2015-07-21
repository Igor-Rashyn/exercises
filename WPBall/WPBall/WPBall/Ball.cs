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
using System.Threading;

namespace WPBall
{
    public class Ball:  Canvas
    {
        private Ellipse elip = new Ellipse();
        public int x, y, xvel, yvel,stp;
        

        public Ball(int ix, int iy)
        {
            SolidColorBrush scb = new SolidColorBrush(Colors.Red);
            SolidColorBrush scb1 = new SolidColorBrush(Colors.Yellow);
            x = ix;
            y = iy;

            elip.Stroke = scb; // красим  форму
            elip.StrokeThickness = 2; // задаем ширину борда

            elip.Height = 30; // задаем высоту элемента
            elip.Width = 30; // задаем ширину элемента
            elip.Fill = scb; // красим внутр. область
            Canvas.SetLeft(elip, (double)x);
            Canvas.SetTop(elip, (double)y);
            this.Background = scb1;
            

            elip.HorizontalAlignment = HorizontalAlignment.Left; // Задаем горизонтальные характеристики выравнивание, применённые к данному элементу при его размещении в родительском элементе.
            elip.VerticalAlignment = VerticalAlignment.Top;// задаем вертикальное выравнивние в род. элементе
            //elip.RenderTransform = new TranslateTransform()/* { X = 10, Y = 50 }*/;//  установка сведений о преобразовании, которые влияют на положение отображения элемента.
            this.Children.Add(elip);
        }


        public void Move()
        {
            xvel = 1;
            yvel = 1;
            stp = 5;
            while (true)
            {
                x = x + (xvel * stp);
                y = y + (yvel * stp);

                if (x - 30 < 0 || x + 30 > 441)
                {
                    xvel = -xvel;
                }

                if (y - 30 < 0 || y + 30 > 595)
                {
                    yvel = -yvel;
                }

                Dispatcher.BeginInvoke((Action)(() =>
                { // Выполняет указанный делегат асинхронно в потоке, в котором был создан базовый дескриптор элемента управления.
                Canvas.SetLeft(elip, x);
                Canvas.SetTop(elip, y);
                }));
                Thread.Sleep(30);
            }
        }

    }
}
