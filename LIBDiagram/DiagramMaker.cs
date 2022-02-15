using LIBDiagram.Drawers;
using LIBDiagram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

[assembly: InternalsVisibleTo("LIBDiagramTests")]
namespace LIBDiagram
{
    public class DiagramMaker
    {
        public Canvas Canvas { get; private set; }
        public List<DiagramItem> Items { get; private set; }

        public double DistanceHorizontal { get; init; }

        public double DistanceVertical { get; init; }

        public double ItemWidth { get; init; }

        public double ItemHeight { get; init; }

        public double ArrowWidth { get; init; }
        public double ArrowHeight { get; init; }

        internal DiaRectangle DiaRectangle { get; set; }
        internal DiaConnectionLine DiaConnectionLine { get; set; }

        public DiagramMaker()
        {
            DiaRectangle = new DiaRectangle();
            DiaConnectionLine = new DiaConnectionLine();
        }

        public void Create(Canvas canvas, DiagramItem item)
        { 
            Create(canvas, new List<DiagramItem>(){ item });
        }

        public void Create(Canvas canvas, List<DiagramItem> items)
        {
            Canvas = canvas;
            Items = items;

            items = SetHoofdItems(items);

            var levels = CalculateLevels(items);

            CalculateMeasures(items,levels);

            DrawDiagram(Items);

            DrawLines(Items);
        }

        private void DrawLines(List<DiagramItem> items)
        {
            foreach (var diagram in items)
            {
                if (diagram.PlaceHolder) continue;

                foreach (var child in diagram.Items)
                {
                    if (child.PlaceHolder) continue;

                    var arrows = DiaConnectionLine.CreateArrows(diagram, child, ArrowWidth
                        , ArrowHeight);

                    arrows.ForEach(p => Canvas.Children.Add(p));


                    Canvas.Children.Add(DiaConnectionLine.CreateLine(diagram, child, DistanceHorizontal));
                }

                DrawLines(diagram.Items);
            }
        }

        private void DrawDiagram(List<DiagramItem> items)
        {
            foreach (var diagram in items)
            {
                if (diagram.PlaceHolder) continue;

                var rec = DiaRectangle.Create(diagram);
                rec.ForEach(p =>  Canvas.Children.Add(p));

                DrawDiagram(diagram.Items);
            }
        }

        private List<DiagramItem> SetHoofdItems(List<DiagramItem> items, DiagramItem hoofd = null)
        {
            foreach (var item in items)
            {
                item.HoofdItem = null;
                SetHoofdItems(item.Items, item);
            }

            return items;
        }

        internal List<DiagramItem> CalculateMeasures(List<DiagramItem> items, List<LevelCount> levels)
        {
            double y = ItemHeight/2;
            foreach (var part in levels.First().Items)
            {
                part.Y = y;
                part.Height = ItemHeight;
                part.Width = ItemWidth;
                part.X = levels.First().Level * ItemWidth + levels.First().Level * DistanceHorizontal;
                y += ItemHeight + DistanceVertical;
            }

            for (int i = 1; i < levels.Count;i++)
{
                foreach (var part in levels[i].Items)
                {
                    var partY = part.Items.Min(p => p.Y) +( part.Items.Max(p => p.Y) - part.Items.Min(p => p.Y))/2;
                    part.Height = ItemHeight;
                    part.Width = ItemWidth;
                    part.X = levels[i].Level * ItemWidth + levels[i].Level * DistanceHorizontal;

                    part.Y = partY;
                }
            }
                
            return items;
        }

        internal List<LevelCount> CalculateLevels(List<DiagramItem> items)
        {
            var maxlevel = CalculateMaxLevel(items);
            var levels = CalculateLevels(items, null, 0, maxlevel);


            return levels;
        }

        internal int CalculateMaxLevel(List<DiagramItem> items, List<int> levels = null, int level = 0)
        {
            if (levels == null) levels = new List<int>() { 0};

            foreach (var item in items)
            {
                CalculateMaxLevel(item.Items, levels, level + 1);
                if (!levels.Contains(level)) levels.Add(level);
            }

            return levels.Max();
        }

        internal List<LevelCount> CalculateLevels(List<DiagramItem> items, List<LevelCount> lijst, int level, int maxlevel)
        {
            if (lijst == null) lijst = new List<LevelCount>();

            var result = lijst.FirstOrDefault(p => p.Level == level);
            if (result == null)
            {
                result = new LevelCount(level);
                lijst.Add(result);
            }

            result.Items.AddRange(items);

            foreach (var item in items)
            {
                if (item.Items.Count == 0 && level < maxlevel)
                    item.Items.Add(new DiagramItem() { PlaceHolder = true });

                CalculateLevels(item.Items, lijst, level + 1, maxlevel);
                
            }

            return lijst.Where(p => p.Items.Count != 0).ToList().OrderByDescending(p => p.Level).ToList();
        }
    }

    internal class LevelCount
    {
        public LevelCount(int level)
        {
            Level = level;
            Items = new List<DiagramItem>();
        }

        internal int Level { get; set; }
        internal List<DiagramItem> Items { get; set; }
    }


}
