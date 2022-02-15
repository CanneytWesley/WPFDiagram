using LIBDiagram;
using LIBDiagram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Block = LIBDiagram.Model.Block;

namespace WPFDiagram
{
    /// <summary>
    /// Interaction logic for UCDiagram.xaml
    /// </summary>
    public partial class UCDiagram : UserControl
    {
        public UCDiagram()
        {
            InitializeComponent();


                DiagramMaker maker = new DiagramMaker() {
                    ItemWidth = 150,
                ItemHeight = 100,
                DistanceHorizontal = 100,
                DistanceVertical = 20,
                ArrowWidth = 10,
                ArrowHeight = 10,
            };


            var P9 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("P9"),
                ClickAction = () => { MessageBox.Show("Wow"); }
            };
            var P7 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("T1")
            };
            var P8 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.Left,
                Header = new Block("P8"),
                Items = new List<DiagramItem>() { 
                    P9
                }
            };
            var P5 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("P5"),
                Items = new List<DiagramItem>()
                {
                    P7,
                    P8
                }
            };
            var P6 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("P6"),
            };
            var P2 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("P2"),
                Items = new List<DiagramItem>(){
                                P5,
                                P6
                            }
            };

            var P3 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block( "P3"),
            };
            var P4 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("P4"),
                Middle = new Block("Middle"),
                Footer = new Block("Footer") ,
            };

            P4.Footer.SetBackgroundBrush("#e312c4");

            var P1 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
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

            
            maker.Create(CvDrawingBoard, list);
        }

    }
}
