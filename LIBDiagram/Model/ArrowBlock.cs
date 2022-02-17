using System.Windows.Media;

namespace WPFDiagram.Core.Model
{
    public class ArrowBlock
    {
        public string TextAboveLine { get; set; }
        public string TextBeneathLine { get; set; }

        public Brush TextColor { get; set; } = Brushes.Black;

        public bool IsValid()
        {
            return IsBeneathValid() || IsAboveValid();
        }

        public bool IsAboveValid()
        {
            return !string.IsNullOrWhiteSpace(TextAboveLine);
        }

        public bool IsBeneathValid()
        { 
            return !string.IsNullOrWhiteSpace(TextBeneathLine); 
        }
    }
}
