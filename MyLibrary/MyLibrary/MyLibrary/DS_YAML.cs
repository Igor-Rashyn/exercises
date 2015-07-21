using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class DS_YAML : iDS
    {
        List<Diary> iDS.Load(string path)
        {
            string line;
            string[] strArr;
            char charArr = ':';
           var dr = new List<Diary>();
            int j = 0;
            string str = "", type = "";

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    strArr = line.Split(charArr);


                    if (line != "---")
                    {
                        for (int i = 0; i < strArr.Length; i++)
                        {
                            if (line != "Diary:")
                            {
                                str = str + ";" + strArr[i];
                            }
                            if (strArr[i] == "MyLibrary.Phone" || strArr[i] == "MyLibrary.Card")
                            {
                                type = strArr[i];
                            }
                        }
                    }


                    if (line == "" && type == "MyLibrary.Card")
                    {
                        dr.Add(new Card().ReadYAML(str));
                        j++;
                        str = "";
                    }
                    else if (line == "" && type == "MyLibrary.Phone")
                    {
                        dr.Add(new Phone().ReadYAML(str));
                        j++;
                        str = "";
                    }
                }
            }
            return dr;           
        }

        void iDS.Save(string path, List<Diary> dr)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("---");
                sw.WriteLine("Diary:");
                for (int i = 0; i < dr.Count; i++)
                {
                    sw.WriteLine(dr[i].WriteYAML(dr[i], i));
                }
                sw.WriteLine("---");
            }

        }





    }
}
