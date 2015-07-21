using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class FactoryChain
    {
        static iDS current = null;

        static public iDS GetIDS(string type)
        {
            Add(new DS_Standard());
            Add(new DS_RAW());
            Add(new DS_PDF());
            Add(new DS_PSD());
            return current.IsReady(type);
        }

       static void Add(iDS ds)
        {
            ds.Next = current;
            current = ds;
        } 


    }
}
