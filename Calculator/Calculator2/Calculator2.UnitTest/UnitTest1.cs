using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Calculator2;

namespace Calculator2.UnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestDivision()
        {
            var op = new Calculator2.calOperations();
            var res = op.Action(6, 3, "/");
            NUnit.Framework.Assert.AreEqual("2", res);
        }

        [Test]
        public void TestMultiplication()
        {
            var op = new Calculator2.calOperations();
            var res = op.Action(8, 3, "*");
            NUnit.Framework.Assert.AreEqual("24", res);
        }

        [Test]
        public void TestAddition()
        {
            var op = new Calculator2.calOperations();
            var res = op.Action(3, 5, "+");
            NUnit.Framework.Assert.AreEqual("8", res);
        }

        [Test]
        public void TestSubtraction()
        {
            var op = new Calculator2.calOperations();
            var res = op.Action(6, 2, "-");
            NUnit.Framework.Assert.AreEqual("4", res);
        }

        [Test]
        public void TestDivisionByZero()
        {
            var op = new Calculator2.calOperations();
            var res = op.Action(6, 0, "/");
            NUnit.Framework.Assert.AreEqual("Деление на ноль", res);
        }


    }
}
