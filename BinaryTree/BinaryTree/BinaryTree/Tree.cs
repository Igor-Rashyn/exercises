using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
       public class Tree : iTree
    {
        private Tree left, right, parent;
        private int data;
        private Tree node;
        private int width;
        private List<int> sortR= new List<int>();
        private List<Tree> nodes = new List<Tree>();

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
        public Tree (int data)
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
        
        public void Add (int data)
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
        public Tree Find(int data)
        {
            Tree node = new Tree(data);
            if (this==null)
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

                       node= this.Right;
                    }
                    else
                    {
                        right.Find(data);
                    }
                }
            }


            return node;

        }
        public int Size()
        {
            return count;
        }
        
        public void Delete(int data)
        {
            if (data<this.data)
            {
                this.left.Delete(data);
            }
            if (data>this.data)
            {
                this.right.Delete(data);
            }
            if (data==this.data)
            {
                // Нету детей
                if(this.right==null && this.left==null)
                {
                    if (this.parent.left.data == data)
                        this.parent.left = null;
                    else
                        this.parent.right = null;
                    count--;
                }
                // Нету детей с лева
                else if (this.left==null && this.right!=null)
                {
                    if (this.parent.left.data == data)
                        this.parent.left = this.right;
                    else
                        this.parent.right = this.right;
                    count--;
                }
                // Нету детей с права
                else if (this.right == null && this.left != null)
                {
                    if (this.parent.left.data == data)
                        this.parent.left = this.left;
                    else
                        this.parent.right = this.left;
                    count--;
                }
                // есть оба дитя
                else
                {
                    if (this.right.left==null)
                    {
                        this.left.parent = this.right;
                        if (this.parent.left.data == data)
                            this.parent.left = this.right;
                        else
                            this.parent.right = this.right;
                    }
                    else 
                    {
                        this.FindMin(this.right, ref node);
                        this.data = node.data;
                        node.parent.left = null;
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
       public int LeafsCount(Tree data)
        {
            if (data.left != null && data.right != null)
            {
                return 2;
            }
            else if (data.left != null || data.right != null)
            {
                return 1;
            }
            else
                return 0;   
        }
       private int Height(Tree root)
        {
           if (root==null)
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
       public int NodeSize(Tree node)
        {
            return Height(node);
        }
       private int Width(Tree root, ref int width)
       {
           if (root == null)
           {
               return 0;
           }
           if (root.left==null && root.right==null)
           {
               width++;
           }
           int left = 1 + Width(root.left, ref width);
           int right = 1 + Width(root.right, ref width);
           return Math.Max(left, right);
       }
       public int Width()
       {
           Width(this,ref width);
           return width;
       }
       private void Sort(Tree node, ref List<int> bb)
       {
           if (bb.Count != count)
           {
               if (node.left == null && node.right == null)
               {
                   bb.Add(node.data);
                   var current = node;
                   if (bb.Count != count)
                   {
                       node.parent.left = null;
                       Sort(current.parent, ref bb);
                   }
               }
               else if (node.left == null && node.right != null)
               {
                   bb.Add(node.data);
                   var current = node;
                   if (node.parent != null)
                   {
                       node.parent.left = node.right;
                   }
                   else
                   {
                       current = node.right;
                       current.parent = null;
                       Sort(current, ref bb);
                   }
                   node.right.parent = node.parent;
                   Sort(current.parent, ref bb);
               }
               else
               {
                   Sort(node.left,ref bb);
               }
           }
       }
       public List<int> Sort()
       {
           Sort(this, ref sortR);
           return sortR;
       }


       private void Reverse(Tree node, ref List<int> bb)
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
                       Reverse(current.parent, ref bb);
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
                       Reverse(current, ref bb);
                   }
                   node.left.parent = node.parent;
                   Reverse(current.parent, ref bb);
               }
               else
               {
                   Reverse(node.right, ref bb);
               }
           }
       }
       public List<int> Reverse()
       {
           Reverse(this, ref sortR);
           return sortR;
       }



    }
}
