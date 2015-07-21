using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Pattern
{
    class SortVisitor: IVisitor
    {
        public List<int> nodes = new List<int>();
        public void Visit(VTree node)
        {
            nodes.Add(node.Data);
        }

        public void Sort()
        {
            nodes.Sort();
        }

    }
}
