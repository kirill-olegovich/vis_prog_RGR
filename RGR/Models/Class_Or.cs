using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public class Class_Or : Full_Elements
    {
        public override void Calculate()
        {
            Outputs[0] = 0;
            Power = 0;

            for (int i = 0; i < 8; i++)
            {
                if (InElements[i] != null)
                {
                    if (InElements[i].Element.Power != 0)
                    {
                        System.Diagnostics.Debug.WriteLine("OR " + i + " = " + InElements[i].Element.Outputs[InElements[i].Index].ToString());
                        Outputs[0] |= InElements[i].Element.Outputs[InElements[i].Index];
                        Power = 1;
                    }
                }
            }

            if (Power == 0)
            {
                Outputs[0] = 0;
            }

            System.Diagnostics.Debug.WriteLine("OR FINAL " + Outputs[0].ToString());
        }
    }
}
