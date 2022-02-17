
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;
using WPFDiagram.Core.Model;
using BrushConverter = System.Windows.Media.BrushConverter;

namespace WPFDiagram.Core.Drawers
{
    internal class DiaRectangle
    {
        internal List<UIElement> Create(DiagramItem item)
        {
            var rec = GetRectangle(item);
            var body = GetBody(item);


            return new List<UIElement>() { rec, body };
        }


        private UIElement GetBody(DiagramItem item)
        {
            
            Grid grid = new Grid();
            grid.Width = item.Width;
            grid.Height = item.Height;

            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1,GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });

            TextBlock header = new TextBlock();
            header.IsHitTestVisible = false;
            header.Background = item.Header.Background;
            header.Text = item.Header.Text;
            header.FontWeight = FontWeights.Bold;
            header.Margin = new Thickness(5);
            header.Foreground = item.Header.Foreground;
            header.Width = item.Width;
            header.TextAlignment = TextAlignment.Center;
            header.TextTrimming = TextTrimming.CharacterEllipsis;
            grid.Children.Add(header);

            Line l = new Line();
            l.IsHitTestVisible = false;
            l.X1 = 10;
            l.Y1 = 0;
            l.X2 = item.Width-10;
            l.Y2 = 0;
            l.Stroke = BrushCreator.ChangeColorBrightness(item.BackgroundColor, -0.3f); //BrushCreator.Convert("#1a68a1");
            l.StrokeThickness = 1;
            Grid.SetRow(l, 1);
            grid.Children.Add(l);

            if (!string.IsNullOrWhiteSpace(item.Middle.Text))
            {
                TextBlock middle = new TextBlock();
                middle.IsHitTestVisible = false;
                middle.TextTrimming = TextTrimming.CharacterEllipsis;
                middle.TextWrapping = TextWrapping.Wrap;
                middle.Background = item.Middle.Background;
                middle.Text = item.Middle.Text;
                middle.VerticalAlignment = VerticalAlignment.Center;
                middle.Width = item.Width;
                middle.TextAlignment = TextAlignment.Center;
                middle.Padding = new Thickness(5);
                middle.Foreground = item.Middle.Foreground;
                Grid.SetRow(middle, 2);
                grid.Children.Add(middle);
            }

            if (!string.IsNullOrWhiteSpace(item.Footer.Text))
            {
                TextBlock footer = new TextBlock();
                footer.IsHitTestVisible = false;
                footer.TextTrimming = TextTrimming.CharacterEllipsis;
                footer.TextWrapping = TextWrapping.Wrap;
                footer.Background = item.Footer.Background;
                footer.Text = item.Footer.Text;
                footer.Width = item.Width;
                footer.TextAlignment = TextAlignment.Center;
                footer.Padding = new Thickness(5);
                footer.Foreground = item.Footer.Foreground;
                Grid.SetRow(footer, 3);
                grid.Children.Add(footer);
            }


            Canvas.SetLeft(grid, item.X);
            Canvas.SetTop(grid, item.Y - item.Height / 2);
            
            
            return grid;
        }

        private UIElement GetRectangle(DiagramItem item)
        {
            Rectangle rec = new Rectangle();
            

            var style = new Style(typeof(Rectangle));

            Trigger triggerIsMouseOver = new Trigger()
            {
                Property = Rectangle.IsMouseOverProperty,
                Value = true
            };
            triggerIsMouseOver.Setters.Add(new Setter() { Property = Rectangle.FillProperty, Value = item.BackgroundSelectionColor });
            if (item.ClickAction != null)
                triggerIsMouseOver.Setters.Add(new Setter() { Property = Rectangle.CursorProperty, Value = Cursors.Hand });

            style.Triggers.Add(triggerIsMouseOver);
            style.Setters.Add(new Setter() { Property = Rectangle.FillProperty, Value = item.BackgroundColor });

            if (item.ClickAction != null)
                rec.MouseLeftButtonUp += (s, e) => { item.ClickAction?.Invoke(); };


            rec.Style = style;

            rec.Width = item.Width;
            rec.Height = item.Height;


            Canvas.SetLeft(rec, item.X);
            Canvas.SetTop(rec, item.Y - item.Height / 2);
            return rec;
        }

    }
}
