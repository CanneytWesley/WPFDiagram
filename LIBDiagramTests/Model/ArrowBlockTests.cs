using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFDiagram.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDiagram.Core.Model.Tests
{
    [TestClass()]
    public class ArrowBlockTests
    {
        [TestMethod()]
        public void IsValidTest_Test1()
        {
            ArrowBlock b = new ArrowBlock();

            Assert.IsFalse(b.IsValid());
        }
        [TestMethod()]
        public void IsValidTest_Test2()
        {
            ArrowBlock b = new ArrowBlock();
            b.TextAboveLine = "";
            b.TextBeneathLine = "";

            Assert.IsFalse(b.IsValid());
        }
        [TestMethod()]
        public void IsValidTest_Test7()
        {
            ArrowBlock b = new ArrowBlock();
            b.TextAboveLine = "   ";
            b.TextBeneathLine = "       ";

            Assert.IsFalse(b.IsValid());
        }
        [TestMethod()]
        public void IsValidTest_Test3()
        {
            ArrowBlock b = new ArrowBlock();
            b.TextAboveLine = "a";
            b.TextBeneathLine = "";

            Assert.IsTrue(b.IsValid());
        }
        [TestMethod()]
        public void IsValidTest_Test4()
        {
            ArrowBlock b = new ArrowBlock();
            b.TextAboveLine = "";
            b.TextBeneathLine = "a";

            Assert.IsTrue(b.IsValid());
        }
        [TestMethod()]
        public void IsValidTest_Test5()
        {
            ArrowBlock b = new ArrowBlock();
            b.TextAboveLine = "a";
            b.TextBeneathLine = "a";

            Assert.IsTrue(b.IsValid());
        }
    }
}