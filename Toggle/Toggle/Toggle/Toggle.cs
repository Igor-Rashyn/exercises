using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toggle
{
    class Toggle : System.Windows.Forms.Button
    {
        public int value;
        public int IPosition;
        public int JPosition;
        private Point startPointP = new Point(40,40);
        private Point startPointM = new Point(65, 15);
        private int xStep = 130;
        private int yStep = 110;
        private Point currentPoint;

        public Toggle(int x, int y, int rand)
        {
            value = rand;
            IPosition = x;
            JPosition = y;
            this.Text = x + "," + y;
            if (value <0)
            {
                this.Width = 50;
                this.Height = 100;
                currentPoint.X = startPointM.X+xStep*x;
                currentPoint.Y = startPointM.Y+yStep*y;
                this.Location = currentPoint;
            }
            else
            {
                this.Width = 100;
                this.Height = 50;
                currentPoint.X = startPointP.X + xStep * x;
                currentPoint.Y = startPointP.Y + yStep * y;
                this.Location = currentPoint;
            }

        }

    }
}
