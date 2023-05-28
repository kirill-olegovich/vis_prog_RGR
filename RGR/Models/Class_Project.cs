using DynamicData.Binding;
using System.Collections.ObjectModel;

namespace RGR.Models
{
    public class Class_Project : AbstractNotifyPropertyChanged
    {
    	private string nameProject;
    	private ObservableCollection<Class_Circuit> circuits;

        public Class_Project()
        {
        	NameProject = "UntitledProject";
        	Circuits = new ObservableCollection<Class_Circuit>();
        }

        public string NameProject
        {
            get => nameProject;
            set=> SetAndRaise(ref nameProject, value);
        }

        public ObservableCollection<Class_Circuit> Circuits
        {
            get => circuits;
            set => SetAndRaise(ref circuits, value);
        }
    }
}
