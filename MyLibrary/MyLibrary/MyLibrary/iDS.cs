using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    interface iDS
    {
        List<Diary> Load(string path);
        void Save(string path,List<Diary> dr);

    }
}
