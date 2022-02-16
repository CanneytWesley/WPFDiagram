using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WPFDiagram
{
    public class CanvasAutoSize : Canvas
    {
        protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint)
        {
            if (Children.Count == 0) return new Size(50, 50);

            base.MeasureOverride(constraint);

            var elements = base
                .InternalChildren
                .OfType<UIElement>().ToList();

            double width = elements.Max(i => i.DesiredSize.Width + (double)i.GetValue(Canvas.LeftProperty));

            double height = elements.Max(i => i.DesiredSize.Height + (double)i.GetValue(Canvas.TopProperty));

            return new Size(width, height);
        }
    }
}
