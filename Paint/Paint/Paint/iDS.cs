using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    interface iDS
    {
        void Save(Bitmap b, string fileName); // в файл
        Bitmap Load(string fileName);// из файла в пэйнт
        iDS Get(string fileName);



    }
}
