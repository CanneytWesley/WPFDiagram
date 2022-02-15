using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDiagram.Core.Model;
using WPFDiagram.Core;

namespace WPFDiagram.CoreTests
{
    [TestClass()]
    public class DiagramMakerTests
    {
        [TestMethod()]
        public void CalculateMeasuresTest()
        {
            var P7 = new DiagramItem()
            {
                Header = new Block("P7")
            };
            var P8 = new DiagramItem()
            {
                Header = new Block( "P8")
            };
            var P5 = new DiagramItem()
            {
                Header = new Block("P5"),
                Items = new List<DiagramItem>()
                {
                    P7,
                    P8
                }
            };
            var P6 = new DiagramItem()
            {
                Header = new Block("P6"),
            };
            var P2 = new DiagramItem()
            {
                Header = new Block("P2"),
                Items = new List<DiagramItem>(){
                                P5,
                                P6
                            }
            };

            var P3 = new DiagramItem()
            {
                Header = new Block("P3"),
            };
            var P4 = new DiagramItem()
            {
                Header = new Block("P4"),
            };

            var P1 = new DiagramItem()
            {
                Header = new Block("P1"),
                Items = new List<DiagramItem>(){
                        P2,
                        P3,
                        P4,
                    }
            };

            List<DiagramItem> list = new List<DiagramItem>()
            {
                P1
            };

            DiagramMaker maker = new DiagramMaker()
            {
                DistanceHorizontal = 100,
                DistanceVertical = 200,
                ItemHeight = 300,
                ItemWidth = 150,
            };

            var levels = maker.CalculateLevels(list);
            var result = maker.CalculateMeasures(list,levels);

            Assert.AreEqual(150, P7.Y);
            Assert.AreEqual(650, P8.Y);
            Assert.AreEqual(1150, P6.Items[0].Y);
            Assert.AreEqual(1650, P3.Items[0].Items[0].Y);
            Assert.AreEqual(2150, P4.Items[0].Items[0].Y);
            Assert.AreEqual(1650, P3.Items[0].Y);
            Assert.AreEqual(2150, P4.Items[0].Y);
            Assert.AreEqual(400, P5.Y);
            Assert.AreEqual(1150, P6.Y);
            Assert.AreEqual(775, P2.Y);
            Assert.AreEqual(1650, P3.Y);
            Assert.AreEqual(2150, P4.Y);
            Assert.AreEqual(1462.5, P1.Y);

            Assert.AreEqual(0,   P1.X);
            Assert.AreEqual(150, P1.Width);
            Assert.AreEqual(300, P1.Height);
            Assert.AreEqual(250,   P2.X);
            Assert.AreEqual(150, P2.Width);
            Assert.AreEqual(300, P2.Height);
            Assert.AreEqual(250,   P3.X);
            Assert.AreEqual(150, P3.Width);
            Assert.AreEqual(300, P3.Height);
            Assert.AreEqual(250,   P4.X);
            Assert.AreEqual(150, P4.Width);
            Assert.AreEqual(300, P4.Height);
            Assert.AreEqual(500, P5.X);
            Assert.AreEqual(150, P5.Width);
            Assert.AreEqual(300, P5.Height);
            Assert.AreEqual(500, P6.X);
            Assert.AreEqual(150, P6.Width);
            Assert.AreEqual(300, P6.Height);
            Assert.AreEqual(750, P7.X);
            Assert.AreEqual(150, P7.Width);
            Assert.AreEqual(300, P7.Height);
            Assert.AreEqual(750, P8.X);
            Assert.AreEqual(150, P8.Width);
            Assert.AreEqual(300, P8.Height);

        }

        [TestMethod()]
        public void CalculateCountLowestLevelTest()
        {
            List<DiagramItem> list = new List<DiagramItem>()
            {
                new DiagramItem(){
                    Header = new Block("P1"),
                    Items = new List<DiagramItem>(){
                        new DiagramItem(){
                            Header = new Block("P2"),
                            Items = new List<DiagramItem>(){
                                new DiagramItem(){
                                 Header = new Block("P5")
                                }
                            }
                        },
                        new DiagramItem(){
                            Header = new Block("P3"),
                            Items = new List<DiagramItem>(){
                                new DiagramItem(){
                                 Header = new Block("P6")
                                },
                                new DiagramItem(){
                                 Header = new Block("P7")
                                },
                            }
                        },
                        new DiagramItem(){
                            Header = new Block("P4"),
                            Items = new List<DiagramItem>(){
                                new DiagramItem(){
                                 Header = new Block("P8")
                                }
                            }
                        },
                    }
                },
            };

            DiagramMaker maker = new DiagramMaker()
            {
                DistanceHorizontal = 100,
                DistanceVertical = 200,
                ItemHeight = 300,
                ItemWidth = 150,
            };

            var result = maker.CalculateLevels(list);

            Assert.AreEqual(2, result.First().Level);
            Assert.AreEqual(4, result.First().Items.Count);
        }
        [TestMethod()]
        public void CalculateMaxLevelTest()
        {
            List<DiagramItem> list = new List<DiagramItem>()
            {
                new DiagramItem(){
                    Header = new Block("P1"),
                    ArrowDirection = ArrowDirection.LeftAndRight,
                    Items = new List<DiagramItem>(){
                        new DiagramItem(){
                            Header = new Block("P2"),
                            ArrowDirection = ArrowDirection.LeftAndRight,
                            Items = new List<DiagramItem>(){
                                new DiagramItem(){
                                    Header = new Block("P5"),
                                    ArrowDirection = ArrowDirection.LeftAndRight,
                                }
                            }
                        },
                        new DiagramItem(){
                            Header = new Block("P3"),
                            ArrowDirection = ArrowDirection.LeftAndRight,
                            Items = new List<DiagramItem>(){
                                new DiagramItem(){
                                 Header = new Block("P6"),
                                ArrowDirection = ArrowDirection.LeftAndRight,
                                },
                                new DiagramItem(){
                                 Header = new Block("P7"),
                                ArrowDirection = ArrowDirection.LeftAndRight,
                                },
                            }
                        },
                        new DiagramItem(){
                            Header = new Block("P4"),
                            ArrowDirection = ArrowDirection.LeftAndRight,
                            Items = new List<DiagramItem>(){
                                new DiagramItem(){
                                 Header = new Block("P8"),
                                 ArrowDirection = ArrowDirection.LeftAndRight,
                                }
                            }
                        },
                    }
                },
            };

            DiagramMaker maker = new DiagramMaker()
            {
                DistanceHorizontal = 100,
                DistanceVertical = 200,
                ItemHeight = 300,
                ItemWidth = 150,
            };

            var result = maker.CalculateMaxLevel(list);

            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void CalculateCountLowestLevel_MissendeblokkenTest()
        {
            List<DiagramItem> list = new List<DiagramItem>()
            {
                new DiagramItem(){
                    Header = new Block("P1"),
                    Items = new List<DiagramItem>(){
                        new DiagramItem(){
                            Header = new Block("P2"),
                            Items = new List<DiagramItem>(){
                                new DiagramItem(){
                                 Header = new Block("P5")
                                }
                            }
                        },
                        new DiagramItem(){
                            Header = new Block("P3"),
                            Items = new List<DiagramItem>(){
                                new DiagramItem(){
                                 Header = new Block("P6")
                                },
                                new DiagramItem(){
                                 Header = new Block("P7")
                                },
                            }
                        },
                        new DiagramItem(){
                            Header = new Block("P4"),
                        },
                    }
                },
            };

            DiagramMaker maker = new DiagramMaker()
            {
                DistanceHorizontal = 100,
                DistanceVertical = 200,
                ItemHeight = 300,
                ItemWidth = 150,
            };

            var result = maker.CalculateLevels(list);

            Assert.AreEqual(4, result.First().Items.Count);
        }

    }
}