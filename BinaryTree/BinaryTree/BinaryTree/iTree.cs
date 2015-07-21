using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public interface iTree
    {
        void Add(int data);
        List<int> Sort();
        int Size();
        void Delete(int data);
        int Height();
        int Width();
        List<int> Reverse();

    }
}
