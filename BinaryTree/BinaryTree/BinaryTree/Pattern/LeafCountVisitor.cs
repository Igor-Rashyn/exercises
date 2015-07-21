using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Pattern
{
    class LeafCountVisitor: IVisitor
    {
        int count;
        
       public void Visit (VTree node)
        {
            LeafCount(node);
        }

        public int LeafCount (VTree node)
       {
           if (node.Left != null && node.Right != null)
           {
               count = 2;
           }
           else if (node.Left != null || node.Right != null)
           {
               count = 1;
           }
           else
               count = 0;

           return count;
       }



    }
}
