using System;
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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;



namespace Paint
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private bool stratDraw = false;
        System.Drawing.Point startPoint, endPoint;
        System.Drawing.Color clr = System.Drawing.Color.Black;
        int sizePen = 1;
        Bitmap b;
        string formatFile;
        iDS ds;
        
        
        public Form1()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);// создаем рисунок
            //pictureBox1.Image = b;
           // pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height); // новое что-то

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
                 //b = new Bitmap(pictureBox1.Width, pictureBox1.Height); // создаем рисунок, на котором будем рисовать
                 g = Graphics.FromImage(b); // получаем из рисунка график
                  //g = this.pictureBox1.CreateGraphics();
                //pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                //g = Graphics.FromImage(pictureBox1.Image); // новое что-то
                g.DrawLine(p, startPoint, endPoint);
                p.Dispose();
                g.Dispose(); // новое что-то

                pictureBox1.Image = b; // отображаем что мы нарисовали в контроле
                  
                pictureBox1.Invalidate();// новое что-то
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
        //private void ChangeSize_Click(object sender, EventArgs e)
        //{
        //    Microsoft.VisualBasic.PowerPacks.LineShape sz = (Microsoft.VisualBasic.PowerPacks.LineShape)sender;
        //    sizePen = sz.BorderWidth;
        //}

        private void FileLoadMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            ofp.Filter = Factory.GetFilterForLoad();
            
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                var ff = Factory.Get(Path.GetExtension(ofp.FileName));
                b = ff.Load(ofp.FileName);
                this.pictureBox1.Image = b;
           }
        }

        private void FileSaveMenu_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //string filt = "JPG (*.jpg)|*.jpg;| BMP (*.bmp)|*.bmp;| PNG (*.png)|*.png;| PDF (*.pdf)|*.pdf | RAW (*.raw)|*.raw | PSD(*.psd)|*.psd;";
            sfd.Filter = Factory.GetFilterForSave();
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                this.pictureBox1.DrawToBitmap(b, new System.Drawing.Rectangle(0, 0, this.pictureBox1.Width, this.pictureBox1.Height));// отрисовывает все из пиктурбокса. Метод контрола
                var ff = Factory.Get(Path.GetExtension(sfd.FileName));
                ff.Save(b,sfd.FileName);
            }

       }

    }
}
