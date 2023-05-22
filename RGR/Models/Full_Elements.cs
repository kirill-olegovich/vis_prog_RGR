using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public class Full_Elements : AbstractNotifyPropertyChanged
    {
        protected Avalonia.Point main_point;

        public Avalonia.Point Main_Point
        {
            get => main_point;
            set => SetAndRaise(ref main_point, value);
        }
        public int output1, output2;

        public int Output1
        {
            get => output1;
            set=> SetAndRaise(ref output1, value);
        }
        public int Output2
        {
            get => output2;
            set => SetAndRaise(ref output2, value);
        }


    }
}
