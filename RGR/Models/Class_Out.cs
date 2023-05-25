namespace RGR.Models
{
    public class Class_Out : Full_Elements
    {
        public Class_Out() : base()
        {
           Inputs[0] = 0;
           OUTPUT = 0;
        }

        public override void Calculate()
        {
            if (InElements[0] != null)
            {
                Inputs[0] = InElements[0].Element.Outputs[InElements[0].Index];
                Power = InElements[0].Element.Power;

                if (Power == 0)
                {
                    Inputs[0] = 0;
                }
            }
            else
            {
                Inputs[0] = 0;
                Power = 0;
            }
            
            OUTPUT = Inputs[0];
            
            System.Diagnostics.Debug.WriteLine("OUT FINAL " + Inputs[0].ToString());
        }
    }
}
