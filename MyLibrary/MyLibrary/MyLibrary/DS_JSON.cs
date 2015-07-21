using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class DS_JSON: iDS
    {

         List<Diary> iDS.Load(string path)
        {
            string line;
            string[] strArr;
            char charArr = '"';
           var dr = new List<Diary>();
            int j = 0;
            string str = "", type = "";

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    strArr = line.Split(charArr);


                    for (int i = 0; i < strArr.Length; i++)
                    {
                        if (line != "\"\"" && line != "{" && line != "[" && line != "\"Diary\":")
                        {
                            str = str + ";" + strArr[i];
                        }
                        if (strArr[i] == "MyLibrary.Phone" || strArr[i] == "MyLibrary.Card")
                        {
                            type = strArr[i];
                        }
                    }

                    if (Convert.ToString(strArr[0]) == "}," && type == "MyLibrary.Card")
                    {
                        dr.Add(new Card().ReadJSON(str));
                        j++;
                        str = "";
                    }
                    else if (Convert.ToString(strArr[0]) == "}," && type == "MyLibrary.Phone")
                    {
                        dr.Add(new Phone().ReadJSON(str));
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
                sw.WriteLine("{");
                sw.WriteLine("\"Diary\":");
                sw.WriteLine("[");
                for (int i = 0; i < dr.Count; i++)
                {
                    sw.WriteLine("{");
                    sw.WriteLine(dr[i].WriteJSON(dr[i]));
                    sw.WriteLine("},");
                }
                sw.WriteLine("]");
                sw.WriteLine("}");
            }

        }


    }
}
