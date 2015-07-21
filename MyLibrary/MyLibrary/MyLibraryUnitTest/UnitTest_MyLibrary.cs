using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;
using NUnit.Framework;
using System.IO;

namespace MyLibraryUnitTest
{
    [TestFixture]
    public class UnitTest_MyLibrary
    {
        string filePathXML = @"C:\Document\Programs\text.xml";
        string filePathCSV = @"C:\Document\Programs\text.csv";

        //[Test]
        //public void WriteToCSV()
        //{
        //    var fm = new FileManager();
        //    var list = fm.CreateArr(15);
        //    fm.WriteCSV(filePathCSV,list);
        //    var nList = fm.ReadCSV(filePathCSV);
        //    NUnit.Framework.CollectionAssert.AreEquivalent(list, nList);
        //}

        //[Test]
        //public void WriteToXML()
        //{
        //    var fm = new FileManager();
        //    var list = fm.CreateArr(15);
        //    fm.WriteXML(filePathXML, list);
        //    var nList = fm.ReadXML(filePathXML);
        //   // NUnit.Framework.Assert.AreEqual(list, nList);
        //    NUnit.Framework.CollectionAssert.AreEqual(list, nList);
        //}

        //[Test]
        //public void CompareTwoCSVFile()
        //{
        //    string pathCSV = @"C:\Document\Programs\Net\text.csv";
        //    var fm = new FileManager();
        //    var AnotherList = fm.ReadCSV(pathCSV);
        //    fm.WriteCSV(filePathCSV, AnotherList);
        //    var nList = fm.ReadCSV(filePathCSV);
        //    StreamReader str1 = new StreamReader(pathCSV);
        //    StreamReader str2 = new StreamReader(filePathCSV);
        //    NUnit.Framework.FileAssert.AreEqual(str1.BaseStream, str2.BaseStream);
        //}


        //[Test]
        //public void CompareTwoXMLFile()
        //{
        //    string pathXML = @"C:\Document\Programs\Net\text.xml";
        //    var fm = new FileManager();
        //    var AnotherList = fm.ReadXML(pathXML);
        //    fm.WriteXML(filePathXML, AnotherList);
        //    var nList = fm.ReadXML(filePathXML);
        //    StreamReader str1 = new StreamReader(pathXML);
        //    StreamReader str2 = new StreamReader(filePathXML);
        //    NUnit.Framework.FileAssert.AreEqual(str1.BaseStream, str2.BaseStream);
        //}




        [Test]
        public void ReadToXML()
        {

         }


        [Test]
        public void ReadToCSV()
        {

        }




        //[Test]
        //public void CompareArr ()
        //{
        //    var fm = new FileManager();
        //    var list = fm.CreateArr(15);
        //    fm.WriteCSV(filePathCSV, list);
        //    var nList = fm.ReadCSV(filePathCSV);
        //    NUnit.Framework.Assert.AreEqual(nList.Count, list.Count);
        //}



    }
}
