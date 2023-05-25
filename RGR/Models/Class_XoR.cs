using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public class Class_XoR : Full_Elements
    {
        public override void Calculate()
        {
            Outputs[0] = 0;
            Power = 0;


            if (InElements[0] != null && InElements[1] != null)
            {
                if (InElements[0].Element.Power != 0 && InElements[1].Element.Power != 0)
                {
                    if (InElements[0].Element.Outputs[InElements[0].Index] != InElements[1].Element.Outputs[InElements[1].Index])
                    {
                        Outputs[0] = 1;
                    }
                    else
                    {
                        Outputs[0] = 0;
                    }

                    Power = 1;
                }
                else if (InElements[0].Element.Power != 0 || InElements[1].Element.Power != 0)
                {
                    Outputs[0] = 1;
                    Power = 1;
                }
            }
            else if (InElements[0] != null)
            {
                if (InElements[0].Element.Power != 0)
                {
                    Outputs[0] = 1;
                    Power = 1;
                }
            }
            else if (InElements[1] != null)
            {
                if (InElements[1].Element.Power != 0)
                {
                    Outputs[0] = 1;
                    Power = 1;
                }
            }

            System.Diagnostics.Debug.WriteLine("XOR FINAL " + Outputs[0].ToString());
        }
    }
}
