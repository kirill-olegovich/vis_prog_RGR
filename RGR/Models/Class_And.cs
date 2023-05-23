using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public class Class_And : Full_Elements
    {
        public int input1, input2;

        public int Input1
        {
            get => input1;
            set => SetAndRaise(ref input1, value);
        }
        public int Input2
        {
            get => input2;
            set => SetAndRaise(ref input2, value);
        }

        public void Value_And()
        {
            if (Input1 == 0 && Input2 == 0)
            {
                Output1 = 0;
            }
            else if (Input1 == 1 && Input2 == 0)
            {
                Output1 = 0;
            }
            else if (Input1 == 0 && Input2 == 1)
            {
                Output1 = 0;
            }
            else if (Input1 == 1 && Input2 == 1)
            {
                Output1 = 1;
            }
        }
    }
}
