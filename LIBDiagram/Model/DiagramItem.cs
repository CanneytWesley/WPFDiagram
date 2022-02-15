using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        internal double Height;

        internal double Width;

        public ArrowDirection ArrowDirection { get; set; }

        public Action ClickAction { get; set; }

        public DiagramItem()
        {
            Items = new List<DiagramItem>();
            Header = new Block();
            Footer = new Block();
            Middle = new Block();
        }

        
    }
}
