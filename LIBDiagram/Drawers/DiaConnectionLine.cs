using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using WPFDiagram.Core.Model;

namespace WPFDiagram.Core.Drawers
{
    internal class DiaConnectionLine
    {
        internal Polyline CreateLine(DiagramItem diagram, DiagramItem child, double DistanceHorizontal)
        {
            Polyline l = new Polyline();
            l.Stroke = Brushes.Black;
            l.StrokeThickness = 2;
            l.Points.Add(new Point(diagram.X + diagram.Width, diagram.Y));
            l.Points.Add(new Point(diagram.X + diagram.Width + DistanceHorizontal / 2, diagram.Y));
            l.Points.Add(new Point(diagram.X + diagram.Width + DistanceHorizontal / 2, child.Y));
            l.Points.Add(new Point(child.X, child.Y));
            return l;
        }

        internal List<Polygon> CreateArrows(DiagramItem diagram, DiagramItem child, double ArrowWidth, double ArrowHeight)
        {
            List<Polygon> polygons = new List<Polygon>();

            if (diagram.ArrowDirection == ArrowDirection.Right || diagram.ArrowDirection == ArrowDirection.LeftAndRight)
            {
                Polygon arrow1 = new Polygon();
                arrow1.Fill = Brushes.Black;
                arrow1.Points.Add(new Point(diagram.X + diagram.Width, diagram.Y));
                arrow1.Points.Add(new Point(diagram.X + ArrowWidth + diagram.Width, diagram.Y + ArrowHeight / 2));
                arrow1.Points.Add(new Point(diagram.X + ArrowWidth + diagram.Width, diagram.Y - ArrowHeight / 2));
                arrow1.Points.Add(new Point(diagram.X + diagram.Width, diagram.Y));

                polygons.Add(arrow1);
            }

            if (child.ArrowDirection == ArrowDirection.Left || child.ArrowDirection == ArrowDirection.LeftAndRight)
            {
                Polygon arrow2 = new Polygon();
                arrow2.Fill = Brushes.Black;
                arrow2.Points.Add(new Point(child.X, child.Y));
                arrow2.Points.Add(new Point(child.X - ArrowWidth, child.Y + ArrowHeight / 2));
                arrow2.Points.Add(new Point(child.X - ArrowWidth, child.Y - ArrowHeight / 2));
                arrow2.Points.Add(new Point(child.X, child.Y));

                polygons.Add(arrow2);
            }

            return polygons;
        }
    }
}
