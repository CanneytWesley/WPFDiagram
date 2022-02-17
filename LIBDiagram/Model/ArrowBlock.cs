namespace WPFDiagram.Core.Model
{
    public class ArrowBlock
    {
        public string TextAboveLine { get; set; }
        public string TextBeneathLine { get; set; }

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
