using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePathXML = @"C:\Document\Programs\text.xml";
            string filePathCSV = @"C:\Document\Programs\text.csv";
            string filePathJSON = @"C:\Document\Programs\text.json";
            string filePathYAML = @"C:\Document\Programs\textYAML.yaml";
            int l = 15;
            FileManager bb = new FileManager();
            List<Diary> zz = bb.CreateArr(l);
          //  bb.SaveYAML(filePathYAML, zz);

            bb.LoadYAML(filePathYAML);


            //bb.SaveXML(filePathXML, zz);
            //bb.SaveCSV(filePathCSV, zz);
            //bb.SaveJSON(filePathJSON, zz);

            //bb.LoadXML(filePathXML);


        }
    }
}
