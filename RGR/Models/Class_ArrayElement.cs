using DynamicData.Binding;

namespace RGR.Models
{
    public class Class_ArrayElement : AbstractNotifyPropertyChanged
    {
    	private Full_Elements element;
    	private int index;

        // public Class_ArrayElement()
        // {
        // 	Element = null;
        // 	Index = null;
        // }

        public Full_Elements Element
        {
            get => element;
            set=> SetAndRaise(ref element, value);
        }

        public int Index
        {
            get => index;
            set=> SetAndRaise(ref index, value);
        }
    }
}
