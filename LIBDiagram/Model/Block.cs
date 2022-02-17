using System.Windows.Media;

namespace WPFDiagram.Core.Model
{
    public class Block
    {
        public string Text { get; set; }
        public Brush Background { get; set; }

        public Brush Foreground { get; set; }

        public Block()
        {
            Background = Brushes.Transparent;
            Foreground = Brushes.White;
        }

        public Block(string text) : this()
        {
            Text = text;
        }

        public void SetBackgroundBrush(string hex)
        {
            Background = GetBrush(hex);
        }
        public void SetForegroundBrush(string hex)
        {
            Foreground = GetBrush(hex);
        }

        private Brush GetBrush(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex)) return Brushes.Transparent;

            return (SolidColorBrush)new BrushConverter().ConvertFrom(hex);
        }
    }
}
