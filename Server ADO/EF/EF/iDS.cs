using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Model;

namespace EF
{
    interface iDS
    {
        void Insert(List<Person> person);
        void Delete(int id);
        void Update(int id, Person pr);
        Person Read(int id);
    }
}
