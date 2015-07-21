using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingBinaryTree
{
    public partial class Form1 : Form
    {
        Tree tree = new Tree();
        Drawer dr = new Drawer();
        public Form1()
        {
            InitializeComponent();
            //myPanel.Controls.Add(tree);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            tree.Add(Convert.ToInt16(numberTextBox.Text));
            myPictureBox.Image = dr.Drawing(tree);

          //  this.Update();
            //myPanel = tree;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            tree.Delete(Convert.ToInt16(numberTextBox.Text));
            dr.InOrder(tree);
            myPictureBox.Image = dr.DrawingAllTree(tree);
        }
    }
}
