using Avalonia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public class Class_Line : Full_Elements
    {
        private Point startPoint;
        private Point endPoint;
        private Full_Elements firstElement;
        private Full_Elements secondElement;
        private string name1;
        private string name2;

        public Point StartPoint
        {
            get => startPoint;
            set => SetAndRaise(ref startPoint, value);
        }

        public Point EndPoint
        {
            get => endPoint;
            set => SetAndRaise(ref endPoint, value);
        }

        public string Name1
        {
            get => name1;
            set => SetAndRaise(ref name1, value);
        }

        public string Name2
        {
            get => name2;
            set => SetAndRaise(ref name2, value);
        }

        public Full_Elements FirstElement
        {
            get => firstElement;
            set
            {
                if (firstElement != null)
                {
                    firstElement.ChangeMainPoint -= OnFirstRectanglePositionChanged;
                }

                firstElement = value;

                if (firstElement != null)
                {
                    firstElement.ChangeMainPoint += OnFirstRectanglePositionChanged;
                }
            }
        }

        public Full_Elements SecondElement
        {
            get => secondElement;
            set
            {
                if (secondElement != null)
                {
                    secondElement.ChangeMainPoint -= OnSecondRectanglePositionChanged;
                }

                secondElement = value;

                if (secondElement != null)
                {
                    secondElement.ChangeMainPoint += OnSecondRectanglePositionChanged;
                }
            }
        }

        private void OnFirstRectanglePositionChanged(object? sender, Class_CheckChanges e)
        {
            StartPoint += e.NewStartPoint - e.OldStartPoint;
        }

        private void OnSecondRectanglePositionChanged(object? sender, Class_CheckChanges e)
        {
            EndPoint += e.NewStartPoint - e.OldStartPoint;
        }

        public void Dispose()
        {
            if (FirstElement != null)
            {
                firstElement.ChangeMainPoint -= OnFirstRectanglePositionChanged;
            }

            if (SecondElement != null)
            {
                secondElement.ChangeMainPoint -= OnSecondRectanglePositionChanged;
            }
        }

        // public void CheckLines(ObservableCollection<Full_Elements> currentcollection)
        // {
        //     for (int i = currentcollection.Count - 1; i >= 0; i--)
        //     {
        //         if (currentcollection[i] is Class_Line currentLine)
        //         {
        //             int findConection = 0;
        //             for (int j = 0; j < currentcollection.Count; j++)
        //             {
        //                 if (j == i) continue;
        //                 if (currentcollection[j] is Full_Elements currentClass)
        //                 {
        //                     if (currentClass.Name == currentLine.Name1)
        //                     {
        //                         currentLine.FirstElement = currentClass;
        //                         findConection++;
        //                     }
        //                     if (currentClass.Name == currentLine.Name2)
        //                     {
        //                         currentLine.SecondElement = currentClass;
        //                         findConection++;
        //                     }
        //                 }
        //                 if (findConection == 2) break;
        //             }
        //         }
        //     }
        // }
    }
}
