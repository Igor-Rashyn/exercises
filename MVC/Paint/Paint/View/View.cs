﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using iTextSharp;
//using iTextSharp.text;
//using iTextSharp.text.pdf;


namespace MVC
{
    public partial class View : Form, iMVC
    {
        private Graphics g;
        private bool stratDraw = false;
        System.Drawing.Point startPoint, endPoint;
        System.Drawing.Color clr = System.Drawing.Color.Black;
        int sizePen = 1;
        Bitmap b;

        public Controller.Controller ctr=null;
        public Model.Factory model = null;
        public Bitmap bitmapModel;
       
        
        public View()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            stratDraw = false;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (stratDraw == true)
            {
                endPoint = e.Location;
                Pen p = new Pen(DefaultColorBox.BackColor, sizePen);
                 g = Graphics.FromImage(b);
                g.DrawLine(p, startPoint, endPoint);
                p.Dispose();
                g.Dispose();
                pictureBox1.Image = b;         
                pictureBox1.Invalidate();
            }
            startPoint = endPoint;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            stratDraw = true;
            startPoint = e.Location;
        }
        private void SelectColor_Click(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            clr = box.BackColor;
            DefaultColorBox.BackColor = clr;
        }
        private void ChangeSize_Click(object sender, EventArgs e)
        {
            Microsoft.VisualBasic.PowerPacks.LineShape sz = (Microsoft.VisualBasic.PowerPacks.LineShape)sender;
            sizePen = sz.BorderWidth;
        }

        private void FileLoadMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            ofp.Filter = ctr.GetFilterForLoad();

            if (ofp.ShowDialog() == DialogResult.OK)
            {
                ctr.Load(Path.GetExtension(ofp.FileName));
                b = bitmapModel;
                this.pictureBox1.Image = b;
           }
        }

        private void FileSaveMenu_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ctr.GetFilterForSave();
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                this.pictureBox1.DrawToBitmap(b, new System.Drawing.Rectangle(0, 0, this.pictureBox1.Width, this.pictureBox1.Height));
                ctr.Save(b,Path.GetExtension(sfd.FileName));
            }
       }

    }
}
