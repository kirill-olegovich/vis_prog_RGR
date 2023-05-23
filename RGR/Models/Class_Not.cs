using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public class Class_Not : Full_Elements
    {
        public int input1;

        public int Input1
        {
            get => input1;
            set => SetAndRaise(ref input1, value);
        }

        public void Value_Not()
        {
            if (Input1 == 0)
            {
                Output1 = 1;
            }
            else if (Input1 == 1)
            {
                Output1 = 0;
            }
        }
    }
}
