using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models
{
    public class Class_CD : Full_Elements
    {
        public override void Calculate()
        {
    		for (int i = 0; i < 8; i++)
    		{
    			Outputs[i] = 0;
    		}

    		Power = 0;

        	if (InElements[0] != null && InElements[1] != null && InElements[2] != null && InElements[3] != null)
        	{
        		if (InElements[0].Element.Outputs[InElements[0].Index] == 1 && InElements[1].Element.Outputs[InElements[1].Index] == 0 && InElements[2].Element.Outputs[InElements[2].Index] == 0 && InElements[3].Element.Outputs[InElements[3].Index] == 0)
        		{
                    Power = 1;
        		}
        		else if (InElements[0].Element.Outputs[InElements[0].Index] == 0 && InElements[1].Element.Outputs[InElements[1].Index] == 1 && InElements[2].Element.Outputs[InElements[2].Index] == 0 && InElements[3].Element.Outputs[InElements[3].Index] == 0)
        		{
        			Outputs[1] = 1;
                    Power = 1;
        		}
        		else if (InElements[0].Element.Outputs[InElements[0].Index] == 0 && InElements[1].Element.Outputs[InElements[1].Index] == 0 && InElements[2].Element.Outputs[InElements[2].Index] == 1 && InElements[3].Element.Outputs[InElements[3].Index] == 0)
        		{
        			Outputs[0] = 1;
                    Power = 1;
        		}
        		else if (InElements[0].Element.Outputs[InElements[0].Index] == 0 && InElements[1].Element.Outputs[InElements[1].Index] == 0 && InElements[2].Element.Outputs[InElements[2].Index] == 0 && InElements[3].Element.Outputs[InElements[3].Index] == 1)
        		{
                    Outputs[0] = 1;
                    Outputs[1] = 1;
                    Power = 1;
        		}
        	}
            
            System.Diagnostics.Debug.WriteLine("CD");
        }
    }
}
