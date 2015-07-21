using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Pattern
{
  public  class VTree: iTree
    {
        private VTree left, right, parent, root;
        private int data;
      //  private Tree node;
        private int width;
        private List<int> sortR= new List<int>();


        static int count = 0;
        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        public VTree Left
        {
            get { return left; }
            set { left = value; }
        }
        public VTree Right
        {
            get { return right; }
            set { right = value; }
        }
        public VTree Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        public VTree Root
        {
            get { return root; }
            set { root = value; }
        }
        public VTree (int data)
        {
            this.data = data;
            left = null;
            right = null;
            parent = null;
        }
        public VTree()
        {
            left = null;
            right = null;
            parent = null;
        }


        public void Add(int data)
        {
            var node = new VTree(data);
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
        public void InOrder(VTree N, IVisitor V)
        {
            if (N == null)
            {
                return;
            }
            else
            {
                if (N.Left != null)
                {
                    InOrder(N.Left, V);
                }

                V.Visit(N);

                if (N.Right != null)
                {
                    InOrder(N.Right, V);
                }
            }
        }
        public List<int> Sort()
        {
            SortVisitor Visitor = new SortVisitor();
            InOrder(this, Visitor);
            return Visitor.nodes;
        }
        public int Size()
        {
            SizeVisitor visitor = new SizeVisitor();
            InOrder(this, visitor);
            return visitor.Count();
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
                    if (this.parent.left.data == data)
                        this.parent.left = null;
                    else
                        this.parent.right = null;
                }
                // Нету детей с лева
                else if (this.left == null && this.right != null)
                {
                    if (this.parent.left.data == data)
                        this.parent.left = this.right;
                    else
                        this.parent.right = this.right;
                }
                // Нету детей с права
                else if (this.right == null && this.left != null)
                {
                    if (this.parent.left.data == data)
                        this.parent.left = this.left;
                    else
                        this.parent.right = this.left;
                }
                // есть оба дитя
                else
                {
                    if (this.right.left == null)
                    {
                        this.left.parent = this.right;
                        if (this.parent.left.data == data)
                            this.parent.left = this.right;
                        else
                            this.parent.right = this.right;
                    }
                    else
                    {
                        // this.FindMin(this.right, ref node);
                        var node = this.FindMin(this);
                        this.data = node.data;
                        node.parent.left = null;
                        node = null;
                    }
                }
            }
            count--;
        }
        public VTree Find(int data)
        {
            VTree node = new VTree(data);
            if (this == null)
            {
                // вернуть эксепшен
            }
            else if (this.data == data)
            {
                return this;
            }
            else
            {
                if (data < this.Data)
                {
                    if (this.Left.data == data)
                    {
                        node = this.Left;
                    }
                    else
                    {
                        left.Find(data);
                    }
                }
                else if (data > this.Data)
                {
                    if (this.Right.data == data)
                    {

                        node = this.Right;
                    }
                    else
                    {
                        right.Find(data);
                    }
                }
            }
            return node;
        }
        private VTree FindMin(VTree node)
        {
            VTree Current = node;
            while (Current.Left != null)
            {
                Current = Current.Left;
            }
            return Current;
        }
        private int Height(VTree root)
        {
            if (root == null)
            {
                return 0;
            }
            int left = 1 + Height(root.left);
            int right = 1 + Height(root.right);
            return Math.Max(left, right);
        }
        public int Height()
        {
            return this.Height(this);
        }
        public int NodeSize(VTree node)
        {
            return Height(node);
        }
        private int Width(VTree root, int width)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                width++;
            }
            int left = 1 + Width(root.left, width);
            int right = 1 + Width(root.right, width);
            return Math.Max(left, right);
        }
        public int Width()
        {
            Width(this, width);
            return width;
        }
        private void Reverse(VTree node, List<int> bb)
        {
            if (bb.Count != count)
            {
                if (node.left == null && node.right == null)
                {
                    bb.Add(node.data);
                    var current = node;
                    if (bb.Count != count)
                    {
                        node.parent.right = null;
                        Reverse(current.parent, bb);
                    }
                }
                else if (node.left != null && node.right == null)
                {
                    bb.Add(node.data);
                    var current = node;
                    if (node.parent != null)
                    {
                        node.parent.right = node.left;
                    }
                    else
                    {
                        current = node.left;
                        current.parent = null;
                        Reverse(current, bb);
                    }
                    node.left.parent = node.parent;
                    Reverse(current.parent, bb);
                }
                else
                {
                    Reverse(node.right, bb);
                }
            }
        }
        public List<int> Reverse()
        {
            Reverse(this, sortR);
            return sortR;
        }




    }
}
