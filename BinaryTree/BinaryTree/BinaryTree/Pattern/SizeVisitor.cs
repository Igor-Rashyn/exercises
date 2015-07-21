using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Pattern
{
    class SizeVisitor:IVisitor
    {
        public List<VTree> nodes = new List<VTree>();
        public void Visit(VTree node)
        {
            nodes.Add(node);
        }

        public int Count ()
        {
            return nodes.Count;
        }


    }
}
