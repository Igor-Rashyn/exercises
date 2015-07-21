using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class DS_XML: iDS
    {

         List<Diary> iDS.Load(string path)
        {
            string line;
            string[] strArr;
            char[] charArr = { '<', '>', '/', '"' };
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
                        if (strArr[i] != "" && line != "<?xml version=\"1.0\" encoding=\"utf-8\"?>")
                            if (line != "<Diary>" && line != "</Diary>")
                            {
                                str = str + ";" + strArr[i];
                            }
                        if (strArr[i] == "MyLibrary.Phone" || strArr[i] == "MyLibrary.Card")
                        {
                            type = strArr[i];
                        }
                    }

                    if (Convert.ToString(strArr[2]) == "Element" && type == "MyLibrary.Card")
                    {
                        dr.Add(new Card().ReadXML(str));
                        j++;
                        str = "";
                    }
                    else if (Convert.ToString(strArr[2]) == "Element" && type == "MyLibrary.Phone")
                    {
                        dr.Add(new Phone().ReadXML(str));
                        j++;
                        str = "";
                    }
                }
                return dr;
            }
        }

         void iDS.Save(string path, List<Diary> dr)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sw.WriteLine("<Diary>");
                for (int i = 0; i < dr.Count; i++)
                {
                    sw.WriteLine(dr[i].WriteXML(dr[i], i));
                }
                sw.WriteLine("</Diary>");
            }

        }

    }
}
