using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallWorker
{
    public partial class Form1 : Form
    {
        BackgroundWorker bw = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            var b = new Ball(e.X, e.Y);
            this.Controls.Add(b);

            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
         while (true)
                {
                    foreach (Ball balls in this.Controls.OfType<Ball>())
                    {
                        balls.Move();
                    }

                    Thread.Sleep(60);
                }
        }
    }
}
