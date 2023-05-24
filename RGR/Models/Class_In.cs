namespace RGR.Models
{
    public class Class_In : Full_Elements
    {
        public Class_In() : base()
        {
           Outputs[0] = 0;
           Power = 1;
           OUTPUT = 0;
        }
        
        public override void Calculate()
        {
            System.Diagnostics.Debug.WriteLine("IN FINAL " + Outputs[0].ToString());
        }
    }
}
