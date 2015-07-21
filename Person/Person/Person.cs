using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private int id;
        private string name;
        string line;

        public int Id { set;  get; }
        public string Name { set; get; }
        public virtual string WriteCSV(Person per) { return line; }
        public virtual string WriteToHtml(Person per) { return line; }

    }
}
