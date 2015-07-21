using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guillotine
{
    class Element : Panel
    {
        private int page;

        public int Page
        {
            get { return page; }
            set { page = value; }
        }

        public Element (int width, int height)
        {
            this.Width = width;
            this.Height = height;
            //Random rnd = new Random(DateTime.Now.Millisecond);
            //this.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            //var brush = new SolidBrush(Color.FromArgb(r.Next(254), r.Next(254), r.Next(254)));
           // var pen = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), 1);
            var pen = new Pen(Color.Black, 1);
            e.Graphics.DrawRectangle(pen, 0, 0, this.Width-2, this.Height-2);
        }

       
    }
}
