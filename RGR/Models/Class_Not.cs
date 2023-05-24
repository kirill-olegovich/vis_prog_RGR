using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public class Class_Not : Full_Elements
    {
        public override void Calculate()
        {
            if (InElements[0] != null)
            {
                Inputs[0] = InElements[0].Element.Outputs[InElements[0].Index];
                Power = InElements[0].Element.Power;

                if (Power != 0)
                {
                    if (Inputs[0] == 0)
                    {
                        Outputs[0] = 1;
                    }
                    else if (Inputs[0] == 1)
                    {
                        Outputs[0] = 0;
                    }
                }
                else
                {
                    Outputs[0] = 0;
                }
            }
            else
            {
                Outputs[0] = 0;
                Power = 0;
            }
            
            System.Diagnostics.Debug.WriteLine("NOT FINAL " + Outputs[0].ToString());
        }
    }
}
