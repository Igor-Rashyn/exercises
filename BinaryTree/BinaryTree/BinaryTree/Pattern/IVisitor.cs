using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Pattern
{
    public interface IVisitor
    {
        void Visit(VTree tree);
        
    }
}
