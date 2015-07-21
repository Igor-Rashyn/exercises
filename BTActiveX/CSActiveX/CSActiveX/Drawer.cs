using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSActiveX
{
    class Drawer
    {
        Bitmap bmp;
        Graphics g;
        Pen pen;
        Size size = new Size(30, 30);
        Point point;

        public Drawer()
        {
            bmp = new Bitmap(870, 430);
            g = Graphics.FromImage(bmp);
            pen = new Pen(Color.Black, 2);
        }

        public Bitmap Drawing(Tree tree)
        {
            Draw(tree);
            return bmp;
        }

        public Bitmap DrawingAllTree(Tree tree)
        {
            bmp = new Bitmap(870, 430);
            g = Graphics.FromImage(bmp);
            DrawAllTree(tree);
            return bmp;
        }


        private void Draw(Tree tree)
        {

            if (tree.Pictured == false)
            {
                if (tree.Parent == null)
                {
                    DrawVertex(Convert.ToString(tree.Data), new Point(bmp.Size.Width / 2, 1));
                    tree.Pictured = true;
                    tree.X = bmp.Size.Width / 2;
                    tree.Y = 1;
                    tree.wh = bmp.Size.Width / 2;
                }
                else if (tree.Data > tree.Parent.Data)
                {
                    tree.wh = tree.Parent.wh / 2;
                    DrawVertex(Convert.ToString(tree.Data), new Point(tree.Parent.X + tree.wh, tree.Parent.Y + 40));
                    tree.Pictured = true;
                    tree.X = tree.Parent.X + tree.wh;
                    tree.Y = tree.Parent.Y + 40;
                    var pt1 = new Point(tree.Parent.X, tree.Parent.Y);
                    var pt2 = new Point(tree.X, tree.Y);
                    DrawArrows(pt1, pt2);
                }
                else
                {
                    tree.wh = tree.Parent.wh / 2;
                    DrawVertex(Convert.ToString(tree.Data), new Point(tree.Parent.X - tree.wh, tree.Parent.Y + 40));
                    tree.Pictured = true;
                    tree.X = tree.Parent.X - tree.wh;
                    tree.Y = tree.Parent.Y + 40;
                    var pt1 = new Point(tree.Parent.X, tree.Parent.Y);
                    var pt2 = new Point(tree.X, tree.Y);
                    DrawArrows(pt1, pt2);
                }
            }
            else
            {
                if (tree.Left != null)
                {
                    Draw(tree.Left);
                }

                if (tree.Right != null)
                {
                    Draw(tree.Right);
                }
            }

        }


        //void CheсkCoordinate ()

        public void DrawAllTree(Tree tree)
        {
            if (tree == null)
            {
                return;
            }
            else
            {
                if (tree.Parent == null)
                {
                    DrawVertex(Convert.ToString(tree.Data), new Point(bmp.Size.Width / 2, 1));
                    tree.Pictured = true;
                    tree.X = bmp.Size.Width / 2;
                    tree.Y = 1;
                    tree.wh = bmp.Size.Width / 2;
                }
                else if (tree.Data > tree.Parent.Data)
                {
                    tree.wh = tree.Parent.wh / 2;
                    DrawVertex(Convert.ToString(tree.Data), new Point(tree.Parent.X + tree.wh, tree.Parent.Y + 40));
                    tree.Pictured = true;
                    tree.X = tree.Parent.X + tree.wh;
                    tree.Y = tree.Parent.Y + 40;
                    var pt1 = new Point(tree.Parent.X, tree.Parent.Y);
                    var pt2 = new Point(tree.X, tree.Y);
                    DrawArrows(pt1, pt2);
                }
                else
                {
                    tree.wh = tree.Parent.wh / 2;
                    DrawVertex(Convert.ToString(tree.Data), new Point(tree.Parent.X - tree.wh, tree.Parent.Y + 40));
                    tree.Pictured = true;
                    tree.X = tree.Parent.X - tree.wh;
                    tree.Y = tree.Parent.Y + 40;
                    var pt1 = new Point(tree.Parent.X, tree.Parent.Y);
                    var pt2 = new Point(tree.X, tree.Y);
                    DrawArrows(pt1, pt2);
                }

                if (tree.Left != null)
                {

                    DrawAllTree(tree.Left);
                }

                if (tree.Right != null)
                {
                    DrawAllTree(tree.Right);
                }
            }

        }


        public void InOrder(Tree N)
        {
            if (N == null)
            {
                return;
            }
            else
            {
                N.Pictured = false;
                if (N.Left != null)
                {
                    InOrder(N.Left);
                }

                if (N.Right != null)
                {
                    InOrder(N.Right);
                }
            }
        }

        void DrawVertex(string text, Point pos)
        {
            /// Прямоугольник
            g.DrawRectangle(pen, new Rectangle(pos, size));
            g.DrawString(text, new Font("Tahoma", 12), Brushes.Black, new PointF(pos.X + 2, pos.Y + 2));
        }

        /// <summary>
        /// Метод прорисовки стрелок между вершинами графа
        /// </summary>
        /// <param name="pos1">Верхний левый угол вершины, из которой выходит стрелка</param>
        /// <param name="pos2">Верхний левый угол вершины, в которую приходит стрелка</param>
        void DrawArrows(Point pos1, Point pos2)
        {
            Point pt1, pt2;
            /// Положение точки на середине нижней стороны прямоугольника
            pt1 = pos1; pt1.Offset(size.Width / 2, size.Height);
            /// Положение точки на середине верхней стороны прямоугольника
            pt2 = pos2; pt2.Offset(size.Width / 2, 0);
            g.DrawLine(pen, pt1, pt2);
        }





    }
}
