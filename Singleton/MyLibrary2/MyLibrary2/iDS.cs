using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary2
{
    interface iDS
    {
        public int Id;
        public string Name;
        string line;
        iDS ds;

        public virtual string WriteXML(iDS par, int i) { return line; }
        public virtual iDS ReadXML(string line) { return ds; }
        public virtual string WriteCSV(iDS par) { return line; }
        public virtual iDS ReadCSV(string line) { return ds; }
        public virtual string WriteJSON(iDS par) { return line; }
        public virtual iDS ReadJSON(string line) { return ds; }

    }
}
