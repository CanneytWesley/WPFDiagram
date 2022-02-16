
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
                ItemWidth = 150,
                ItemHeight = 100,
                DistanceHorizontal = 100,
                DistanceVertical = 20,
                ArrowWidth = 10,
                ArrowHeight = 10,
            };

            maker.Create(CvDrawingBoard, DiagramItems?.ToList());

        }

        public UCDiagram()
        {
            InitializeComponent();

        }
    }
}
