using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSActiveX
{
    class Tree:Panel
    {
        private Tree left, right, parent;
        private int data;
        private Tree node;
        private List<int> sortR = new List<int>();
        private List<Tree> nodes = new List<Tree>();
        private int x, y;
        private bool pictured = false;
        public int wh;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public bool Pictured
        {
            get { return pictured; }
            set { pictured = value; }
        }
        static int count = 0;
        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        public Tree Left
        {
            get { return left; }
            set { left = value; }
        }
        public Tree Right
        {
            get { return right; }
            set { right = value; }
        }
        public Tree Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        public Tree(int data)
        {
            this.data = data;
            left = null;
            right = null;
            parent = null;
        }
        public Tree()
        {
            left = null;
            right = null;
            parent = null;
        }

        public void Add(int data)
        {
            var node = new Tree(data);
            // Если первый пустой
            if (this.data == 0 && this.left == null && this.right == null && this.parent == null)
            {
                this.data = data;
                count++;
            }
            else
            {
                // Если уже существует первый 
                if (node.Data < this.Data)
                {
                    if (this.Left == null)
                    {
                        this.Left = node;
                        left.parent = this;
                        count++;
                    }
                    else
                    {
                        left.Add(data);
                    }
                }
                else if (node.Data > this.Data)
                {
                    if (this.Right == null)
                    {
                        this.Right = node;
                        Right.parent = this;
                        count++;
                    }
                    else
                    {
                        right.Add(data);
                    }
                }
            }


        }
        public void Delete(int data)
        {

            if (data < this.data)
            {
                this.left.Delete(data);
            }
            if (data > this.data)
            {
                this.right.Delete(data);
            }
            if (data == this.data)
            {
                // Нету детей
                if (this.right == null && this.left == null)
                {
                    if (this.parent.left != null)
                    {
                        if (this.parent.left.data == data)
                            this.parent.left = null;
                        else
                            this.parent.right = null;
                    }
                    else if (this.parent.right != null)
                    {
                        if (this.parent.right.data == data)
                            this.parent.right = null;
                        else
                            this.parent.right = null;
                    }
                    else
                    {


                    }
                }
                // Нету детей с лева
                else if (this.left == null && this.right != null)
                {
                    // тут ошибки, не правильно учтена одна сторона
                    this.parent.right = this.right;
                    this.right.parent = this.parent;
                }
                // Нету детей с права
                else if (this.right == null && this.left != null)
                {
                    // тут ошибки, не правильно учтена одна сторона
                    this.parent.left = this.left;
                    this.left.parent = this.parent;
                }
                // есть оба дитя
                else
                {
                    if (this.right.left == null && this.parent != null)
                    {
                        this.right.parent = this.parent;
                        this.left.parent = this.right;
                        this.parent.right = this.right;
                        this.right.left = this.left;
                    }
                    else if (this.parent != null)
                    {
                        this.FindMin(this.right, ref node);
                        this.data = node.data;
                        node.parent.left = null;
                        node = null;
                    }
                    else
                    {
                        this.FindMin(this.right, ref node);
                        this.data = node.data;
                        node.parent.right = null;
                        node = null;

                    }
                }
            }

        }
        private void FindMin(Tree data, ref Tree node)
        {
            var temp = data;
            if (temp.left == null)
            {
                node = temp;
            }
            else
            {
                temp.FindMin(temp.left, ref node);
            }

        }

    }
}
