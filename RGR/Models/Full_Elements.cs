using Avalonia;
using DynamicData.Binding;
using System;

namespace RGR.Models
{
    public abstract class Full_Elements : AbstractNotifyPropertyChanged
    {
        protected Avalonia.Point main_point;
        private int input1, input2, output1, output2;

        public Avalonia.Point Main_Point
        {
            get => main_point;
            set
            {
                Point oldPoint = Main_Point;
                SetAndRaise(ref main_point, value);
                if (ChangeMainPoint != null)
                {
                    Class_CheckChanges args = new Class_CheckChanges
                    {
                        OldStartPoint = oldPoint,
                        NewStartPoint = Main_Point,
                    };
                    ChangeMainPoint(this, args);
                }

            }
        }

        public int Input1
        {
            get => input1;
            set=> SetAndRaise(ref input1, value);
        }

        public int Input2
        {
            get => input2;
            set=> SetAndRaise(ref input2, value);
        }

        public int Output1
        {
            get => output1;
            set => SetAndRaise(ref output1, value);
        }

        public int Output2
        {
            get => output2;
            set => SetAndRaise(ref output2, value);
        }

        public event EventHandler<Class_CheckChanges> ChangeMainPoint;
    }
}
