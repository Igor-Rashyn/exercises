using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using MyList;

namespace MyListUniTest
{
    [TestFixture]
    public class UnitTest1
    {
        
/// <summary>
/// Тесты с массивом
/// </summary>
        [Test]
        public void AddTestArray()
        {
            mList lst = new mList();
            lst.Add(5);
            int expected = 5;
            NUnit.Framework.Assert.AreEqual(expected, lst[0]);
        }
        [Test]
        public void CountTestArray()
        {
            mList lst = new mList();
            lst.Add(5);
            lst.Add(5);
            lst.Add(5);
            int expected = 3;
            NUnit.Framework.Assert.AreEqual(expected, lst.Count());
        }
        [Test]
        public void RemoveTestArray()
        {
            mList lst = new mList();
            lst.Add(5);
            lst.Add(5);
            lst.Add(5);
            int expected = 2;
            lst.Remove(5);
            NUnit.Framework.Assert.AreEqual(expected, lst.Count());
        }
        [Test]
        public void SortTestArray()
        {
            mList lst = new mList();
            lst.Add(5);
            lst.Add(4);
            lst.Add(3);
            lst.Add(2);
            lst.Add(1);

            mList lst2 = new mList();
            lst2.Add(1);
            lst2.Add(2);
            lst2.Add(3);
            lst2.Add(4);
            lst2.Add(5);


            lst.Sort();
            //NUnit.Framework.CollectionAssert.AreEqual(lst, lst2);

            for (int i = 0; i < 5; i++)
            {
                NUnit.Framework.Assert.AreEqual(lst[i], lst2[i]);
            }
        }
         [Test]
        public void ClearTestArray()
        {
            mList lst = new mList();
            lst.Add(5);
            lst.Add(4);
            lst.Add(3);
            lst.Add(2);
            lst.Add(1);
            int expected = 0;
            lst.Clear();
            NUnit.Framework.Assert.AreEqual(expected, lst.Count());
        }
         public void ReverseTestArray()
         {
             mList lst = new mList();
             lst.Add(5);
             lst.Add(4);
             lst.Add(3);
             lst.Add(2);
             lst.Add(1);

             mList lst2 = new mList();
             lst2.Add(1);
             lst2.Add(2);
             lst2.Add(3);
             lst2.Add(4);
             lst2.Add(5);


             lst2.Reverse();
             //NUnit.Framework.Assert.That(lst, NUnit.Framework.Is.EquivalentTo(lst2));
             //NUnit.Framework.CollectionAssert.AreEqual(lst, lst2);
         }
        [Test]
        public void DeleteTestArray ()
         {
             mList lst = new mList();
             lst.Add(1);
             lst.Add(2);
             lst.Add(3);
             lst.Add(4);
             lst.Add(5);
             lst.Delete(2);
             int expected = 4;
             NUnit.Framework.Assert.AreEqual(expected, lst[2]);
         }
        [Test]
        public void InsertTestArray()
        {
            mList lst = new mList();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);//
            lst.Add(4);
            lst.Add(5);
            lst.Insert(2,10);
            int expected = 10;
            NUnit.Framework.Assert.AreEqual(expected, lst[2]);
        }
      [Test]
        public void AddToStartTestArray()
        {
            mList lst = new mList();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.AddToStart(10);
            int expected = 10;
            NUnit.Framework.Assert.AreEqual(expected, lst[0]);
        }
        [Test]
        public void DelFirstTestArray()
      {
          mList lst = new mList();
          lst.Add(1);
          lst.Add(2);
          lst.Add(3);
          lst.DelFirst();
          int expected = 2;
          NUnit.Framework.Assert.AreEqual(expected, lst[0]);
      }
        
        
        
        
        /// <summary>
        /// Тесты для цепочки
        /// </summary>
        [Test]
        public void AddTest()
        {
            MyList.mListPrev lst = new MyList.mListPrev();
            lst.Add(5);
            int expected = 5;
            NUnit.Framework.Assert.AreEqual(expected, lst[0]);
        }
        [Test]
        public void CountTest()
        {
            MyList.mListPrev lst = new MyList.mListPrev();
            lst.Add(5);
            lst.Add(5);
            lst.Add(5);
            int expected = 3;
            NUnit.Framework.Assert.AreEqual(expected, lst.Count());
        }
        [Test]
        public void RemoveTest()
        {
            MyList.mListPrev lst = new MyList.mListPrev();
            lst.Add(5);
            lst.Add(3);
            int expected = 1;
            lst.Remove(5);
            NUnit.Framework.Assert.AreEqual(expected, lst.Count());
        }
        [Test]
        public void ClearTest()
        {
            MyList.mListPrev lst = new MyList.mListPrev();
            lst.Add(5);
            lst.Add(4);
            lst.Add(3);
            lst.Add(2);
            lst.Add(1);
            int expected = 0;
            lst.Clear();
            NUnit.Framework.Assert.AreEqual(expected, lst.Count());
        }
        [Test]
        public void DeleteTest()
        {
            MyList.mListPrev lst = new MyList.mListPrev();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.Add(4);
            lst.Add(5);
            lst.Delete(2);
            int expected = 4;
            NUnit.Framework.Assert.AreEqual(expected, lst[2]);
        }
        [Test]
        public void InsertTest()
        {
            MyList.mListPrev lst = new MyList.mListPrev();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);//
            lst.Add(4);
            lst.Add(5);
            lst.Insert(2, 10);
            int expected = 10;
            NUnit.Framework.Assert.AreEqual(expected, lst[2]);
        }
        [Test]
        public void AddToStartTest()
        {
            MyList.mListPrev lst = new MyList.mListPrev();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.AddToStart(10);
            int expected = 10;
            NUnit.Framework.Assert.AreEqual(expected, lst[0]);
        }
        [Test]
        public void DelFirstTest()
        {
            MyList.mListPrev lst = new MyList.mListPrev();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.DelFirst();
            int expected = 2;
            NUnit.Framework.Assert.AreEqual(expected, lst[0]);
        }


    }
}
