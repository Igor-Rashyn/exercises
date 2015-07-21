using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallTimer
{
    public partial class Field : Form
    {

        Graphics g;

        public Field()
        {
            InitializeComponent();
            timer1.Start();  
        }
       
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Controls.Add(new Ball(e.X, e.Y));
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            foreach (Ball ball in this.Controls.OfType<Ball>())
            {
                ball.Move();
            }
            Invalidate();
        }
    }
}
