using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public class Class_And : Full_Elements
    {
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
