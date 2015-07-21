using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using BinaryTree;
using System.Collections;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {

        IEnumerable TestData
        {
            get
            {
                yield return new BinaryTree.Tree();
                yield return new BinaryTree.TreeWithoutRef();
                yield return new BinaryTree.Pattern.VTree();
            }
        }

        [Test, TestCaseSource("TestData")]
        public void AddTest(BinaryTree.iTree tr)
        {
            tr.Add(12);
            tr.Add(45);
            tr.Add(10);
            tr.Add(25);
            tr.Add(75);
            tr.Add(39);
            tr.Add(11);
            tr.Add(2);
            tr.Add(5);
            tr.Add(1);
            tr.Add(22);
            tr.Add(42);
            tr.Add(40);
            tr.Add(43);
            tr.Add(3);
            tr.Add(6);
            int expected = 16;
            NUnit.Framework.Assert.AreEqual(expected, tr.Size());
        }
        [Test, TestCaseSource("TestData")]
        public void DeleteTest(BinaryTree.iTree tr)
        {
            tr.Add(12);
            tr.Add(45);
            tr.Add(10);
            tr.Add(25);
            tr.Add(75);
            tr.Add(39);
            tr.Add(11);
            tr.Add(2);
            tr.Add(5);
            tr.Add(1);
            tr.Add(22);
            tr.Add(42);
            tr.Add(40);
            tr.Add(43);
            tr.Add(3);
            tr.Add(6);
            tr.Delete(6);
            int expected = 15;
            NUnit.Framework.Assert.AreEqual(expected, tr.Size());

        }
        [Test, TestCaseSource("TestData")]
        public void SizeTest(BinaryTree.iTree tr)
        {
            tr.Add(12);
            tr.Add(45);
            tr.Add(10);
            tr.Add(25);
            tr.Add(75);
            tr.Add(39);
            tr.Add(11);
            tr.Add(2);
            tr.Add(5);
            tr.Add(1);
            tr.Add(22);
            tr.Add(42);
            tr.Add(40);
            tr.Add(43);
            tr.Add(3);
            tr.Add(6);
            int expected = 16;
            NUnit.Framework.Assert.AreEqual(expected, tr.Size());

        }
        [Test, TestCaseSource("TestData")]
        public void HeightTest(BinaryTree.iTree tr)
        {
            tr.Add(12);
            tr.Add(45);
            tr.Add(10);
            tr.Add(25);
            tr.Add(75);
            tr.Add(39);
            tr.Add(11);
            tr.Add(2);
            tr.Add(5);
            tr.Add(1);
            tr.Add(22);
            tr.Add(42);
            tr.Add(40);
            tr.Add(43);
            tr.Add(3);
            tr.Add(6);
            int expected = 6;
            
            NUnit.Framework.Assert.AreEqual(expected, tr.Height());

        }
    }
}
