using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guillotine
{
    class Field: Panel
    {
        private int page;
        private Field root;
        private Field nodeDown;
        private Field nodeRight;
        private bool used;
        private int x, y;

        public int Page
        {
            get { return page; }
            set { page = value; }
        }

        public Field(int page)
        {
            Point point = new Point(1,1);
            this.Location = point;
            this.Page = page;
            this.Name = "field" + page;
            this.Width = 400;
            this.Height = 500;
            this.BackColor = Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.root = this;
            this.used = false;
            this.x = 0;
            this.y = 0;
        }

        public Field(int x, int y, int w, int h)
        {
            this.Visible = false;
            this.Width = w;
            this.Height = h;
            this.used = false;
            this.x = x;
            this.y = y;
        }

        public Field Place (List<Element> elements)
        {
            for (int i=0; i<elements.Count; i++)
            {
                var element = elements[i];
                var node= this.findNode(this.root,element.Width,element.Height);
                if (node!=null)
                {
                    element.Page = this.Page;
                    var point = new Point(node.x,node.y);
                    element.Location=point;
                    root.Controls.Add(element);
                    node.SplitNode(node,element.Width,element.Height);
                }

            }
            return root;
        }


        private Field findNode(Field node, int w, int h)
        {
            if (node.used)
            {
             var result = this.findNode(node.nodeRight, w, h);
             return result != null ? result : this.findNode(node.nodeDown, w, h);
            }
            else if ((w <= node.Width) && (h <= node.Height))
            {
                return node;
            }
            else
                return null;
        }


        private void SplitNode (Field node, int w, int h)
        {
            node.used = true;
            node.nodeDown = new Field(node.x,node.y+h,node.Width,node.Height-h);
            node.nodeRight = new Field(node.x+w,node.y,node.Width-w,h);
        }

    }
}
