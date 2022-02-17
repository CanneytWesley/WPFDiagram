
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFDiagram.Core;
using WPFDiagram.Core.Model;
using Block = WPFDiagram.Core.Model.Block;

namespace WPFDiagram
{
    /// <summary>
    /// Interaction logic for UCDiagram.xaml
    /// </summary>
    public partial class UCDiagram : UserControl
    {


        public ObservableCollection<DiagramItem> DiagramItems
        {
            get { return (ObservableCollection<DiagramItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("DiagramItems", typeof(ObservableCollection<DiagramItem>), typeof(UCDiagram), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, OnItemChange));


        public double DistanceHorizontal
        {
            get { return (double)GetValue(DistanceHorizontalProperty); }
            set { SetValue(DistanceHorizontalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DistanceHorizontal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DistanceHorizontalProperty =
            DependencyProperty.Register("DistanceHorizontal", typeof(double), typeof(UCDiagram), new PropertyMetadata(100d));




        public double DistanceVertical
        {
            get { return (double)GetValue(DistanceVerticalProperty); }
            set { SetValue(DistanceVerticalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DistanceVertical.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DistanceVerticalProperty =
            DependencyProperty.Register("DistanceVertical", typeof(double), typeof(UCDiagram), new PropertyMetadata(20d));




        public double ArrowWidth
        {
            get { return (double)GetValue(ArrowWidthProperty); }
            set { SetValue(ArrowWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ArrowWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ArrowWidthProperty =
            DependencyProperty.Register("ArrowWidth", typeof(double), typeof(UCDiagram), new PropertyMetadata(10d));




        public double ArrowHeight
        {
            get { return (double)GetValue(ArrowHeightProperty); }
            set { SetValue(ArrowHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ArrowHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ArrowHeightProperty =
            DependencyProperty.Register("ArrowHeight", typeof(double), typeof(UCDiagram), new PropertyMetadata(10d));



        private static void OnItemChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ucdiagram = (UCDiagram)d;

            if (ucdiagram.DiagramItems != null)
            {
                ucdiagram.DiagramItems.CollectionChanged -= ucdiagram.DiagramItems_CollectionChanged;
                ucdiagram.DiagramItems.CollectionChanged += ucdiagram.DiagramItems_CollectionChanged;
            }

            ucdiagram.MakeDiagram();
        }

        private void DiagramItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            MakeDiagram();
        }

        private void MakeDiagram()
        {
            DiagramMaker maker = new DiagramMaker()
            {
                DistanceHorizontal = DistanceHorizontal,
                DistanceVertical = DistanceVertical,
                ArrowWidth = ArrowWidth,
                ArrowHeight = ArrowHeight,
            };

            maker.Create(CvDrawingBoard, DiagramItems?.ToList());

        }

        public UCDiagram()
        {
            InitializeComponent();

        }
    }
}
