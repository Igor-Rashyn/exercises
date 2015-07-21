using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    interface iDS
    {
        void Create(List<Person> person);
        void Delete(int id);
        void Update(int id, Person pr);
        Person Read(int id);

    }
}
