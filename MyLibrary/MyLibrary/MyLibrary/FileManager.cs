using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyLibrary
{
    public class FileManager
    {
        List<Diary> par;


        public void SaveXML(string path, List<Diary> par)
        {
            iDS ds = new DS_XML();
            ds.Save(path,par);
        }
        public void SaveCSV(string path, List<Diary> par)
        {
            iDS ds = new DS_CSV();
            ds.Save(path, par);
        }
        public void SaveJSON(string path, List<Diary> par)
        {
            iDS ds = new DS_JSON();
            ds.Save(path, par);
        }
        public void SaveYAML(string path, List<Diary> par)
        {
            iDS ds = new DS_YAML();
            ds.Save(path, par);
        }

        public List<Diary> LoadXML(string path)
        {
            iDS ds = new DS_XML();
           var list = ds.Load(path);
            return list;
        }
        public List<Diary> LoadCSV(string path)
        {
            iDS ds = new DS_CSV();
           var list= ds.Load(path);
            return list;
        }
        public List<Diary> LoadJSON(string path)
        {
            iDS ds = new DS_JSON();
            var list = ds.Load(path);
            return list;
        }
        public List<Diary> LoadYAML(string path)
        {
            iDS ds = new DS_YAML();
            var list = ds.Load(path);
            return list;
        }


        //public void WriteXML(string path, List<Diary> par)
        //{
        //    using (StreamWriter sw = new StreamWriter(path))
        //    {
        //        sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        //        sw.WriteLine("<Diary>");
        //        for (int i = 0; i < par.Count; i++)
        //        {
        //            sw.WriteLine(par[i].WriteXML(par[i], i));
        //        }
        //        sw.WriteLine("</Diary>");
        //    }
        //}
        //public List<Diary> ReadXML(string path)
        //{
        //    string line;
        //    string[] strArr;
        //    char[] charArr = { '<', '>', '/', '"' };
        //    par = new List<Diary>();
        //    int j = 0;
        //    string str = "", type = "";

        //    using (StreamReader sr = new StreamReader(path))
        //    {
        //        while (!sr.EndOfStream)
        //        {
        //            line = sr.ReadLine();
        //            strArr = line.Split(charArr);

        //            for (int i = 0; i < strArr.Length; i++)
        //            {
        //                if (strArr[i] != "" && line != "<?xml version=\"1.0\" encoding=\"utf-8\"?>")
        //                    if (line != "<Diary>" && line != "</Diary>")
        //                    {
        //                        str = str + ";" + strArr[i];
        //                    }
        //                if (strArr[i] == "MyLibrary.Phone" || strArr[i] == "MyLibrary.Card")
        //                {
        //                    type = strArr[i];
        //                }
        //            }

        //            if (Convert.ToString(strArr[2]) == "Element" && type == "MyLibrary.Card")
        //            {
        //                par.Add(new Card().ReadXML(str));
        //                j++;
        //                str = "";
        //            }
        //            else if (Convert.ToString(strArr[2]) == "Element" && type == "MyLibrary.Phone")
        //            {
        //                par.Add(new Phone().ReadXML(str));
        //                j++;
        //                str = "";
        //            }
        //        }
        //    }

        //    return par;
        //}
        //public void WriteCSV( string path, List<Diary> par)
        //{
        //    using (StreamWriter sw = new StreamWriter(path))
        //    {
        //        for (int i = 0; i < par.Count; i++)
        //        {
        //            sw.WriteLine(par[i].WriteCSV(par[i]));
        //        }
        //    }
             
        //}
        //public List<Diary>  ReadCSV(string path)
        //{
        //    string line;
        //    string[] strArr;
        //    char charArr = ',';
        //    par = new List<Diary>();
        //    int j = 0;

        //    using (StreamReader sr = new StreamReader(path))
        //    {
        //        while (!sr.EndOfStream)
        //        {
        //            line = sr.ReadLine();
        //            strArr = line.Split(charArr);

        //            if (Convert.ToString(strArr[0]) == "MyLibrary.Card")
        //            {
        //                par.Add(new Card().ReadCSV(line));
        //            }
        //            else
        //            {
        //                par.Add(new Phone().ReadCSV(line));
        //            }
        //            j++;
        //        }
        //    }

        //    return par;
        //}
        //public void WriteJSON(string path, List<Diary> par)
        //{
        //    using (StreamWriter sw = new StreamWriter(path))
        //    {
        //        sw.WriteLine("{");
        //        sw.WriteLine("\"Diary\":");
        //        sw.WriteLine("[");
        //        for (int i = 0; i < par.Count; i++)
        //        {
        //            sw.WriteLine("{");
        //            sw.WriteLine(par[i].WriteJSON(par[i]));
        //            sw.WriteLine("},");
        //        }
        //        sw.WriteLine("]");
        //        sw.WriteLine("}");
        //    }
        //}
        //public List<Diary> ReadJSON(string path)
        //{
        //    string line;
        //    string[] strArr;
        //    char charArr = '"';
        //    par = new List<Diary>();
        //    int j = 0;
        //    string str = "", type = "";

        //    using (StreamReader sr = new StreamReader(path))
        //    {
        //        while (!sr.EndOfStream)
        //        {
        //            line = sr.ReadLine();
        //            strArr = line.Split(charArr);


        //            for (int i = 0; i < strArr.Length; i++)
        //            {
        //                if (line != "\"\"" && line != "{" && line != "[" && line != "\"Diary\":")
        //                {
        //                    str = str + ";" + strArr[i];
        //                }
        //                if (strArr[i] == "MyLibrary.Phone" || strArr[i] == "MyLibrary.Card")
        //                {
        //                    type = strArr[i];
        //                }
        //            }

        //            if (Convert.ToString(strArr[0]) == "}," && type == "MyLibrary.Card")
        //            {
        //                par.Add(new Card().ReadJSON(str));
        //                j++;
        //                str = "";
        //            }
        //            else if (Convert.ToString(strArr[0]) == "}," && type == "MyLibrary.Phone")
        //            {
        //                par.Add(new Phone().ReadJSON(str));
        //                j++;
        //                str = "";
        //            }
        //        }
        //    }
        //    return par;
        //}





        public List<Diary> Sorting(List<Diary> par)
        {

            par.Sort((a, b) => a.Id.CompareTo(b.Id));

            return par;
        }
        public List<Diary> CreateArr(int length)
        {
           par = new List<Diary>();
           Random rd = new Random();
           int rClass = 0;

           for (int i = 0; i < length; i++)
           {
               rClass = rd.Next(0, 2);
               if (rClass==1)
               {
                   par.Add(new Card());
                   ((Card)par[i]).NameCard = "NameCard_" + Convert.ToString(i);
                   ((Card)par[i]).NumberCard = rd.Next(1, 99999999);
                   par[i].Id = i;
                   par[i].Name = "TestCard_" + Convert.ToString(i);

               }

               else 
               {
                   par.Add(new Phone());
                   ((Phone)par[i]).PhoneNumber = rd.Next(1, 99999999);
                   ((Phone)par[i]).PhoneType = "PhoneType_" + Convert.ToString(i);
                   par[i].Id = i;
                   par[i].Name = "TestPhone_" + Convert.ToString(i);

               }
           }

            return par;

        }
    }

}
