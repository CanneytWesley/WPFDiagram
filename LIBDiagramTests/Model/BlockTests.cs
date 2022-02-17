using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFDiagram.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFDiagram.Core.Model.Tests
{
    [TestClass()]
    public class BlockTests
    {
        [TestMethod()]
        public void BlockTest_Constructor1()
        {
            Block b = new Block();

            Assert.AreEqual(Brushes.White, b.Foreground);
            Assert.AreEqual(Brushes.Transparent, b.Background);
        }
        [TestMethod()]
        public void BlockTest_Constructor2()
        {
            Block b = new Block("");

            Assert.AreEqual(Brushes.White, b.Foreground);
            Assert.AreEqual(Brushes.Transparent, b.Background);
        }
    }
}