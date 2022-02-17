using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPFDiagram.Core.Model
{

    public class DiagramItem
    {
        internal bool PlaceHolder { get; set; } = false;
        public List<DiagramItem> Items { get; set; }

        internal DiagramItem HoofdItem;

        public Block Header { get; set; }

        public Block Middle { get; set; }

        public Block Footer { get; set; }

        internal double X;

        internal double Y;

        public double Height { get; set; } = 100;

        public double Width { get; set; } = 150;

        public ArrowDirection ArrowDirection { get; set; }

        public ArrowBlock ArrowRightInformation { get; set; }
        public ArrowBlock ArrowLeftInformation { get; set; }

        public Action ClickAction { get; set; }

        public Brush BackgroundColor { get; set; }
        public Brush BackgroundSelectionColor { get; set; }

        public DiagramItem()
        {
            Items = new List<DiagramItem>();
            Header = new Block();
            Footer = new Block();
            Middle = new Block();
            ArrowRightInformation = new ArrowBlock();
            ArrowLeftInformation = new ArrowBlock();

            BackgroundColor = new RadialGradientBrush()
            {
                Center = new Point(0.5, 0.5),
                GradientOrigin = new Point(0.5, 0.5),
                GradientStops = new GradientStopCollection() {
                        new GradientStop(){
                            Color = (Color)ColorConverter.ConvertFromString("#1483d2"),
                            Offset = 0,
                        },
                        new GradientStop(){
                            Color = (Color)ColorConverter.ConvertFromString("#258ad4"),
                            Offset = 1,
                        },
                    }
            };

            BackgroundSelectionColor = BrushCreator.Convert("#1374ba");

        }

        
    }
}
