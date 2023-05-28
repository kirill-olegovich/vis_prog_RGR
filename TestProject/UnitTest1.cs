using RGR.Models;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void And()
        {
            Class_And element = new Class_And();
            Class_In in1 = new Class_In();
            Class_In in2 = new Class_In();

            element.InElements[0] = new Class_ArrayElement();
            element.InElements[0].Element = in1;
            element.InElements[0].Index = 0;
            element.InElements[1] = new Class_ArrayElement();
            element.InElements[1].Element = in2;
            element.InElements[1].Index = 0;
            in1.OutElements[0] = new Class_ArrayElement();
            in1.OutElements[0].Element = element;
            in1.OutElements[0].Index = 0;
            in1.Outputs[0] = 0;
            in2.OutElements[0] = new Class_ArrayElement();
            in2.OutElements[0].Element = element;
            in2.OutElements[0].Index = 1;
            in2.Outputs[0] = 1;

            element.Calculate();

            Assert.True(element.Outputs[0] == 0);
        }
        [Fact]
        public void Or()
        {
            Class_Or element = new Class_Or();
            Class_In in1 = new Class_In();
            Class_In in2 = new Class_In();

            element.InElements[0] = new Class_ArrayElement();
            element.InElements[0].Element = in1;
            element.InElements[0].Index = 0;
            element.InElements[1] = new Class_ArrayElement();
            element.InElements[1].Element = in2;
            element.InElements[1].Index = 0;
            in1.OutElements[0] = new Class_ArrayElement();
            in1.OutElements[0].Element = element;
            in1.OutElements[0].Index = 0;
            in1.Outputs[0] = 0;
            in2.OutElements[0] = new Class_ArrayElement();
            in2.OutElements[0].Element = element;
            in2.OutElements[0].Index = 1;
            in2.Outputs[0] = 1;

            element.Calculate();

            Assert.True(element.Outputs[0] == 1);
        }
        [Fact]
        public void XoR()
        {
            Class_XoR element = new Class_XoR();
            Class_In in1 = new Class_In();
            Class_In in2 = new Class_In();

            element.InElements[0] = new Class_ArrayElement();
            element.InElements[0].Element = in1;
            element.InElements[0].Index = 0;
            element.InElements[1] = new Class_ArrayElement();
            element.InElements[1].Element = in2;
            element.InElements[1].Index = 0;
            in1.OutElements[0] = new Class_ArrayElement();
            in1.OutElements[0].Element = element;
            in1.OutElements[0].Index = 0;
            in1.Outputs[0] = 1;
            in2.OutElements[0] = new Class_ArrayElement();
            in2.OutElements[0].Element = element;
            in2.OutElements[0].Index = 1;
            in2.Outputs[0] = 1;

            element.Calculate();

            Assert.True(element.Outputs[0] == 0);
        }
        [Fact]
        public void Not()
        {
            Class_Not element = new Class_Not();
            Class_In in1 = new Class_In();

            element.InElements[0] = new Class_ArrayElement();
            element.InElements[0].Element = in1;
            element.InElements[0].Index = 0;
            in1.OutElements[0] = new Class_ArrayElement();
            in1.OutElements[0].Element = element;
            in1.OutElements[0].Index = 0;
            in1.Outputs[0] = 1;

            element.Calculate();

            Assert.True(element.Outputs[0] == 0);
        }
    }
}