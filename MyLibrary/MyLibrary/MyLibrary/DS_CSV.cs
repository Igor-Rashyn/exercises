using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class DS_CSV: iDS
    {
         List<Diary> iDS.Load(string path)
        {
            string line;
            string[] strArr;
            char charArr = ',';
            var dr = new List<Diary>();
            int j = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    strArr = line.Split(charArr);

                    if (Convert.ToString(strArr[0]) == "MyLibrary.Card")
                    {
                        dr.Add(new Card().ReadCSV(line));
                    }
                    else
                    {
                        dr.Add(new Phone().ReadCSV(line));
                    }
                    j++;
                }
                return dr;
            }
        }

         void iDS.Save(string path, List<Diary> dr)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < dr.Count; i++)
                {
                    sw.WriteLine(dr[i].WriteCSV(dr[i]));
                }
            }

        }
    }
}
