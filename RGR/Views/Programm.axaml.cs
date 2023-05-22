using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using System.Linq;
using RGR.Models;
using RGR.ViewModels;
using System.Collections.ObjectModel;

namespace RGR.Views
{
    public partial class Programm : Window
    {
        public Point pointPointerPressed;
        public Point pointerPositionIntoElement;

        public Programm()
        {
            InitializeComponent();
            DataContext = new ProgrammViewModel();
        }
        
        public void ButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            if (DataContext is ProgrammViewModel programmViewModel)
            {
                if(sender is Button button)
                {
                    programmViewModel.Take_Button_Name(button.Name); 
                }
            }
        }

        public void PointerPressedOnCanvas(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            pointPointerPressed = pointerPressedEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());

            if(this.DataContext is ProgrammViewModel programm)
            {
                if(programm.Button_Number == 1) 
                {
                    programm.All_Elements.Add(new Class_And { Main_Point = pointPointerPressed });

                    //this.PointerMoved += PointerMoveDrawAnd;
                    //this.PointerReleased += PointerPressedReleasedDrawAnd;
                    //programm.Button_Number = 1;
                }
                else if (programm.Button_Number == 2)
                {
                    programm.All_Elements.Add(new Class_Or { Main_Point = pointPointerPressed });
                }
                else if (programm.Button_Number == 3)
                {
                    programm.All_Elements.Add(new Class_Not { Main_Point = pointPointerPressed });
                }
                else if (programm.Button_Number == 4)
                {
                    programm.All_Elements.Add(new Class_XoR { Main_Point = pointPointerPressed });
                }
                else if (programm.Button_Number == 5)
                {
                    programm.All_Elements.Add(new Class_Enter { Main_Point = pointPointerPressed });
                }
                else if (programm.Button_Number == 6)
                {
                    programm.All_Elements.Add(new Class_Out { Main_Point = pointPointerPressed });
                }
                else if (programm.Button_Number == 7)
                {
                    programm.All_Elements.Add(new Class_HalfSum { Main_Point = pointPointerPressed });
                }
                else if(programm.Button_Number == 0)
                {
                    if (pointerPressedEventArgs.Source is Shape shape)
                    {
                        if(shape.DataContext is Full_Elements myElement)
                        {
                            programm.SelectedElement = myElement;
                        }
                        pointerPositionIntoElement = pointerPressedEventArgs.GetPosition(shape);
                        this.PointerMoved += PointerMoveDragElement;
                        this.PointerReleased += PointerPressedReleasedDragElement;
                    }
                }
            }
        }

        //public void PointerMoveDrawAnd(object? sender, PointerEventArgs pointerEventArgs)
        //{
        //    if(this.DataContext is ProgrammViewModel programm)
        //    {
        //        Class_And editAnd = new Class_And { Main_Point = pointPointerPressed };
        //        programm.all_elements.Add((Class_And)editAnd);
        //        Point currentPointPosition = pointerEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());
        //    }
        //}

        public void PointerMoveDragElement(object? sender, PointerEventArgs pointerEventArgs)
        {
            if(pointerEventArgs.Source is Shape shape) 
            {
                Point currentPointPosition = pointerEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());

                if(shape.DataContext is Full_Elements myElement)
                {
                    myElement.Main_Point = new Point(
                        currentPointPosition.X - pointerPositionIntoElement.X,
                        currentPointPosition.Y - pointerPositionIntoElement.Y
                        );
                }
            }
        }

        public void PointerPressedReleasedDragElement(object? sender, PointerReleasedEventArgs poiterEventArgs)
        {
            this.PointerMoved -= PointerMoveDragElement;
            this.PointerReleased -= PointerPressedReleasedDragElement;
        }


        //public void PointerPressedReleasedDrawAnd(object? sender, PointerReleasedEventArgs poiterEventArgs)
        //{
        //    this.PointerMoved -= PointerMoveDrawAnd;
        //    this.PointerReleased -= PointerPressedReleasedDrawAnd;
        //}

        public void Exit_programm(object sender, RoutedEventArgs eventArgs)
        {
            this.Close();
        }
    }
}
