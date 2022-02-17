using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WPFDiagram.Core.Model;

namespace WPFDiagram
{
    public class MainWindowViewModel
    {
        public ObservableCollection<DiagramItem> Items { get; set; }
        public ICommand AddItemCommand { get; set; }
        public ICommand NewListCommand { get; set; }
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<DiagramItem>();
            InitialiseList();
            AddItemCommand = new RelayCommand(AddItem);
            NewListCommand = new RelayCommand(NewList);
        }

        private void NewList()
        {
            Items.Clear();

        }

        private void AddItem()
        {
            Items.Add(new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("Added")
            }) ;
        }

        private void InitialiseList()
        {
            var P9 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("P9"),
                ClickAction = () => { MessageBox.Show("Wow"); }
            };
            var P7 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("T1")
            };
            var P8 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.Left,
                Header = new Block("P8"),
                Items = new List<DiagramItem>() {
                    P9
                },
                ArrowLeftInformation = new ArrowBlock() { TextAboveLine = "02-22", TextBeneathLine = "2020" },
                ArrowRightInformation = new ArrowBlock() { TextAboveLine = "02-22", TextColor = Brushes.Peru },
            };
            var P5 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("P5"),
                Items = new List<DiagramItem>()
                {
                    P7,
                    P8
                }
            };
            var P6 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("P6"),
                Height = 175,
                BackgroundColor = BrushCreator.Convert("#62d31b"),
                BackgroundSelectionColor = BrushCreator.Convert("#51ad17"),
            };
            var P2 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("P2"),
                Items = new List<DiagramItem>(){
                                P5,
                                P6
                            }
            };

            var P3 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("P3"),
            };
            var P4 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("P4"),
                Middle = new Block("Middle"),
                Footer = new Block("Footer"),
            };

            P4.Footer.SetBackgroundBrush("#e312c4");

            var P1 = new DiagramItem()
            {
                ArrowDirection = ArrowDirection.LeftAndRight,
                Header = new Block("P1"),
                Items = new List<DiagramItem>(){
                        P2,
                        P3,
                        P4,
                    }
            };

            Items.Add(P1);
        }
    }
}
