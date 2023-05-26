using DynamicData.Binding;
using System.Collections.ObjectModel;

namespace RGR.Models
{
    public class Class_Circuit : AbstractNotifyPropertyChanged
    {
    	private string nameCircuit;
    	private ObservableCollection<Full_Elements> elements;

        public Class_Circuit()
        {
        	NameCircuit = "Untitled";
        	Elements = new ObservableCollection<Full_Elements>();
        }

        public string NameCircuit
        {
            get => nameCircuit;
            set=> SetAndRaise(ref nameCircuit, value);
        }

        public ObservableCollection<Full_Elements> Elements
        {
            get => elements;
            set => SetAndRaise(ref elements, value);
        }
    }
}
