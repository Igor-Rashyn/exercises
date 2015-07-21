using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace BallWorker
{
    class Ball : Panel
    {
        public int xvel, yvel;
        public Brush brush;
        public double st;
        int stp;
        Point pt;


        public Ball(int ix, int iy)
        {
            Random r = new Random();
            pt = new Point(ix, iy);
            this.Location = pt;
            this.Width = r.Next(15, 35);
            this.Height = this.Width;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            xvel = r.Next(0, 15);
            yvel = r.Next(0, 15);
            st = Math.Pow((-1), r.Next(0, 10));
            stp = Convert.ToInt32(st);
            brush = new SolidBrush(Color.FromArgb(r.Next(254), r.Next(254), r.Next(254)));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(brush, new Rectangle(0, 0, this.Size.Width, this.Size.Height));
            this.Location = pt;
            this.DoubleBuffered = true;
        }


        public void Move()
        {
                pt.X = pt.X + (xvel * stp);
                pt.Y = pt.Y + (yvel * stp);

                if (pt.X - this.Height < 0 || pt.X + this.Height > 400)
                {
                    xvel = -xvel;
                }

                if (pt.Y - this.Height < 0 || pt.Y + this.Height > 400)
                {
                    yvel = -yvel;
                }
                this.Location = pt;

        }

    }
}
