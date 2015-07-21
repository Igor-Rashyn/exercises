using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintVector
{
    public class Figure:Panel
    {
       public Color color = Color.Black;
       public int height;
        public int width;
        public int thickness;
        public string type;
        public Point position;
        public Graphics g;
        public Pen pen;

        public Figure(Color pcolor, Point pposition, int pthickness, int pwidth, int pheight, string ptype)
        {
            height = pheight;
            width = pwidth;
            thickness = pthickness;
            position = pposition;
            color = pcolor;
            pen = new Pen(color, thickness);
            this.Location = pposition;
            this.Width = pwidth - pposition.X;
            this.Height = pheight - pposition.Y;
          //  this.BackColor = Color.Aqua;
            type = ptype;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            switch (type)
            {
                case "Circle":
                    e.Graphics.DrawEllipse(pen, 4, 4, this.Width-9, this.Height-9);
                    break;
                case "Rectangle":
                    e.Graphics.DrawRectangle(pen, 4, 4, this.Width-9, this.Height-9);
                    break;
                case "Line":
                    e.Graphics.DrawLine(pen, 0, 0, this.Width, this.Height);
                    break;
                case "RoundRec":
                    DrawRoundedRectangle(e.Graphics, pen, 4, 4, this.Width -10, this.Height -10, 10, 10);
                    break;
            }
        }


        static void DrawRoundedRectangle(Graphics g, Pen p, int x, int y, int w, int h, int rx, int ry)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(x, y, rx + rx, ry + ry, 180, 90);
            path.AddLine(x + rx, y, x + w - rx, y);
            path.AddArc(x + w - 2 * rx, y, 2 * rx, 2 * ry, 270, 90);
            path.AddLine(x + w, y + ry, x + w, y + h - ry);
            path.AddArc(x + w - 2 * rx, y + h - 2 * ry, rx + rx, ry + ry, 0, 91);
            path.AddLine(x + rx, y + h, x + w - rx, y + h);
            path.AddArc(x, y + h - 2 * ry, 2 * rx, 2 * ry, 90, 91);
            path.CloseFigure();
            g.DrawPath(p, path);
        }
    }
}