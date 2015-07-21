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

namespace BallThread
{
    public partial class Field : Form
    {
        public Field()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

      private void Field_MouseDown(object sender, MouseEventArgs e)
        {

            var b = new Ball(e.X, e.Y);
            this.Controls.Add(b);
            var tr = new Thread(b.Move);
            tr.Start();
        }


    }
}
