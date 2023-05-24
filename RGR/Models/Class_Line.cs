using Avalonia;
using System;
using System.Collections.Generic;
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
    }
}
