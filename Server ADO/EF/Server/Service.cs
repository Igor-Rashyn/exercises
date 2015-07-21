using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using EF.Model;

namespace Server
{
    class Service : IService
    {

        #region Get data
        public string GetData(string value)
        {
            string str = null;
            switch (value)
            {
                case "<All data>":
                    var ef = new iDS_EF();
                    var people = ef.ReadAll();
                    str = TransferToString(people);
                    break;
            }
            return str;
        }
        private string TransferToString(List<Person> people)
        {
            string str = null;

            for (int i = 0; i < people.Count; i++)
            {
                str = str + people[i].WriteCSV(people[i]) + ",";
            }
            return str;
        }
        #endregion 

        public void DeletePerson(string value)
        {
            var ef = new iDS_EF();
            ef.Delete(Convert.ToInt32(value));
        }

        public void InsertPerson(string value)
        {
            List<Person> people = new List<Person>();
            string[] strArr = value.Split(',');
                if (strArr[9].ToUpper()=="MAN")
                {
                    Man man = new Man(Convert.ToInt32(strArr[1]), strArr[2], strArr[3], Convert.ToInt32(strArr[4]), Convert.ToInt32(strArr[5]));
                    people.Add(man);
                }
                else if (strArr[9].ToUpper() == "WOMAN")
                {
                    Woman woman = new Woman(Convert.ToInt32(strArr[1]), strArr[2], Convert.ToInt32(strArr[6]), strArr[7], strArr[8]);
                    people.Add(woman);
                }
                
            var ef = new iDS_EF();
            ef.Insert(people);
        }

       public void UpdatePerson(int id, string value)
        {
            string[] strArr = value.Split(',');
            Person person = null;
            if (strArr[9].ToUpper() == "MAN")
            {
              person = new Man(Convert.ToInt32(strArr[1]), strArr[2], strArr[3], Convert.ToInt32(strArr[4]), Convert.ToInt32(strArr[5]));
            }
            else if (strArr[9].ToUpper() == "WOMAN")
            {
                person = new Woman(Convert.ToInt32(strArr[1]), strArr[2], Convert.ToInt32(strArr[6]), strArr[7], strArr[8]);
            }

            var ef = new iDS_EF();
            ef.Update(id,person);

        }


    }
}
