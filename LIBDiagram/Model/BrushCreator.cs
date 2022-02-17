using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFDiagram.Core.Model
{
    public static class BrushCreator
    {
        public static Brush Convert(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex)) return Brushes.Transparent;

            return (SolidColorBrush)new BrushConverter().ConvertFrom(hex);
        }

        public static Brush ChangeColorBrightness(Brush color, float correctionFactor)
        {
            if (color is SolidColorBrush b)
            {
                float red = b.Color.R;
                float green = b.Color.G;
                float blue = b.Color.B;

                if (correctionFactor < 0)
                {
                    correctionFactor = 1 + correctionFactor;
                    red *= correctionFactor;
                    green *= correctionFactor;
                    blue *= correctionFactor;
                }
                else
                {
                    red = (255 - red) * correctionFactor + red;
                    green = (255 - green) * correctionFactor + green;
                    blue = (255 - blue) * correctionFactor + blue;
                }

                return new SolidColorBrush(Color.FromArgb(b.Color.A, (byte)red, (byte)green, (byte)blue));
            }
            else if (color is RadialGradientBrush r)
            {
                var rColor = r.GradientStops.FirstOrDefault()?.Color;

                if (rColor.HasValue) return ChangeColorBrightness(new SolidColorBrush(rColor.Value)
                    , correctionFactor);
            }

            return color;
        }
    }
}
