using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintVector
{
    public partial class Field : Form
    {
        System.Drawing.Color clr = System.Drawing.Color.Black;
        Figure figure;
        int sizePen;
        string type;
        Point startP;
        List<Figure> listFigur;

        public Field()
        {
            InitializeComponent();

        }

        private void SetColor_Click(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            clr = box.BackColor;
            defaultColor.BackColor = clr;
        }

        private void Field_MouseDown(object sender, MouseEventArgs e)
        {
            startP = e.Location;
        }

        private void Field_MouseUp(object sender, MouseEventArgs e)
        {
            figure = new Figure(defaultColor.BackColor, startP, sizePen, e.X, e.Y,type);
            this.Controls.Add(figure);
        }

        private void ChangeFigure_Click(object sender, EventArgs e)
        {
            Button sz = (Button)sender;
            type = sz.Text;
        }

        private void ChangeSize_Click(object sender, EventArgs e)
        {
            Button sz = (Button)sender;
            sizePen = Convert.ToInt32(sz.Text);
        }

        private void SaveToXML_Click(object sender, EventArgs e)
        {
            List<Figure> fg = Controls.OfType<Figure>().Cast<Figure>().ToList(); // создаем массив контролов
            DS_XML file = new DS_XML();
            file.Save(@"C:\Document\Programs\Net\PaintVector\figureXML.xml", fg);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DS_XML file = new DS_XML();
            listFigur = file.Load(@"C:\Document\Programs\Net\PaintVector\figureXML.xml");
            foreach(Figure fgg in listFigur)
            {
            this.Controls.Add(fgg);
            }
        }

    }
}
