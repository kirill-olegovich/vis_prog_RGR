using Avalonia;
using DynamicData.Binding;
using System;

namespace RGR.Models
{
    public abstract class Full_Elements : AbstractNotifyPropertyChanged
    {
        protected Avalonia.Point main_point;
        private int[] inputs = new int[8];
        private int[] outputs = new int[8];
        private int power;
        private int output;
        private Class_ArrayElement[] inElements = new Class_ArrayElement[8];
        private Class_ArrayElement[] outElements = new Class_ArrayElement[8];
        public event EventHandler<Class_CheckChanges> ChangeMainPoint;
        public virtual void Calculate() { }
        private string name;

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

        public int Power
        {
            get => power;
            set=> SetAndRaise(ref power, value);
        }

        public string Name
        {
            get => name;
            set => SetAndRaise(ref name, value);
        }

        public int OUTPUT
        {
            get => output;
            set=> SetAndRaise(ref output, value);
        }

        public Class_ArrayElement[] InElements
        {
            get => inElements;
        }

        public Class_ArrayElement[] OutElements
        {
            get => outElements;
        }
        
        public int[] Inputs
        {
            get => inputs;
        }

        public int[] Outputs
        {
            get => outputs;
        }
    }
}
