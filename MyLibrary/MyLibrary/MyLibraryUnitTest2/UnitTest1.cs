using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;
using NUnit.Framework;
using System.IO;


namespace MyLibraryUnitTest2
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void LoadAndSaveCSV()
        {
          string pathCSV = @"C:\Document\Programs\Net\text.csv";
          string filePathCSV = @"C:\Document\Programs\text.csv";
          var fm = new FileManager();
          var AnotherList = fm.LoadCSV(pathCSV);
          fm.SaveCSV(filePathCSV, AnotherList);
          var nList = fm.LoadCSV(filePathCSV);
          StreamReader str1 = new StreamReader(pathCSV);
          StreamReader str2 = new StreamReader(filePathCSV);
          NUnit.Framework.FileAssert.AreEqual(str1.BaseStream, str2.BaseStream);
        }


        [Test]
        public void LoadAndSaveXML()
        {
            string pathXML = @"C:\Document\Programs\Net\text.xml";
            string filePathXNL = @"C:\Document\Programs\text.xml";
            var fm = new FileManager();
            var AnotherList = fm.LoadXML(pathXML);
            fm.SaveXML(filePathXNL, AnotherList);
            var nList = fm.LoadXML(filePathXNL);
            StreamReader str1 = new StreamReader(pathXML);
            StreamReader str2 = new StreamReader(filePathXNL);
            NUnit.Framework.FileAssert.AreEqual(str1.BaseStream, str2.BaseStream);
        }


        [Test]
        public void LoadAndSaveJSON()
        {
            string pathJSON = @"C:\Document\Programs\Net\text.csv";
            string filePathJSON = @"C:\Document\Programs\text.csv";
            var fm = new FileManager();
            var AnotherList = fm.LoadJSON(pathJSON);
            fm.SaveJSON(filePathJSON, AnotherList);
            var nList = fm.LoadJSON(filePathJSON);
            StreamReader str1 = new StreamReader(pathJSON);
            StreamReader str2 = new StreamReader(filePathJSON);
            NUnit.Framework.FileAssert.AreEqual(str1.BaseStream, str2.BaseStream);
        }
    }
}
