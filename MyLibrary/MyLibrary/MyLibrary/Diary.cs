using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Diary
    {
        public int Id;
        public string Name;
        string line;
        Diary dr;

        public virtual string WriteXML(Diary par, int i) { return line; }
        public virtual Diary ReadXML(string line) { return dr; }
        public virtual string WriteCSV(Diary par) { return line; }
        public virtual Diary ReadCSV(string line) { return dr; }
        public virtual string WriteJSON(Diary par) { return line; }
        public virtual Diary ReadJSON(string line) { return dr;}
        public virtual string WriteYAML(Diary par, int i) { return line; }
        public virtual Diary ReadYAML(string line) { return dr; }



    }
}
