using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    public interface iMList
    {
        int this[int index]
        {
            get;
            set;
        }
        void Add(int value);
        void Remove(int value);
        void Clear();
        int Count();
        void Delete(int index);
        void AddToStart(int value);
        void Insert(int index, int value);
        void Sort();
        void Reverse();
        void DelFirst();
    }
}
