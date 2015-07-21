using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using MyList;
using System.Collections;

namespace MyListUniTest
{
    /// <summary>
    /// Summary description for mListsTest
    /// </summary>
    [TestFixture]
    public class mListsTest
    {
        IEnumerable TestData
      {
          get
          {
              yield return new MyList.mList();
              yield return new MyList.mListPrev();
              yield return new MyList.mListCircular();
              yield return new MyList.mListiEndiStart();
              yield return new MyList.mListWithoutPrev();
          }
      }

        [Test, TestCaseSource("TestData")]
        public void AddTest(MyList.iMList list)
        {
            list.Add(5);
            int expected = 5;
            NUnit.Framework.Assert.AreEqual(expected, list[0]);
        }
        [Test, TestCaseSource("TestData")]
        public void CountTest(MyList.iMList list)
        {
            list.Add(5);
            list.Add(5);
            list.Add(5);
            int expected = 3;
            NUnit.Framework.Assert.AreEqual(expected, list.Count());
        }
        [Test, TestCaseSource("TestData")]
        public void ClearTest(MyList.iMList list)
        {
            list.Add(5);
            list.Add(4);
            list.Add(3);
            list.Add(2);
            list.Add(1);
            int expected = 0;
            list.Clear();
            NUnit.Framework.Assert.AreEqual(expected, list.Count());
        }
        [Test, TestCaseSource("TestData")]
        public void RemoveTest(MyList.iMList list)
        {
            list.Add(5);
            list.Add(3);
            int expected = 1;
            list.Remove(5);
            NUnit.Framework.Assert.AreEqual(expected, list.Count());
        }
        [Test, TestCaseSource("TestData")]
        public void DeleteTest(MyList.iMList lst)
        {
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.Add(4);
            lst.Add(5);
            lst.Delete(2);
            int expected = 4;
            NUnit.Framework.Assert.AreEqual(expected, lst[2]);
        }
        [Test, TestCaseSource("TestData")]
        public void InsertTest(MyList.iMList lst)
        {
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.Add(4);
            lst.Add(5);
            lst.Insert(2, 10);
            int expected = 10;
            NUnit.Framework.Assert.AreEqual(expected, lst[2]);
        }
        [Test, TestCaseSource("TestData")]
        public void AddToStartTest(MyList.iMList lst)
        {
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.AddToStart(10);
            int expected = 10;
            NUnit.Framework.Assert.AreEqual(expected, lst[0]);
        }
        [Test, TestCaseSource("TestData")]
        public void DelFirstTest(MyList.iMList lst)
        {
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.DelFirst();
            int expected = 2;
            NUnit.Framework.Assert.AreEqual(expected, lst[0]);
        }



    }
}
