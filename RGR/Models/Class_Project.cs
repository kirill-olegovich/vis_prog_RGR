using DynamicData.Binding;
using System.Collections.ObjectModel;
using YamlDotNet.Serialization;

namespace RGR.Models
{
    public class Class_Project : AbstractNotifyPropertyChanged
    {
    	private string nameProject;
        private string path;
        private ObservableCollection<Class_Circuit> circuits;

        public virtual void SetOptions(string name, string source) { }

        public Class_Project()
        {
        	NameProject = "Untitled";
            Path = "Untitled";
            Circuits = new ObservableCollection<Class_Circuit>();
        }

        [YamlMember(typeof(string))]
        public string NameProject
        {
            get => nameProject;
            set=> SetAndRaise(ref nameProject, value);
        }

        [YamlMember(typeof(string))]
        public string Path
        {
            get => path;
            set => SetAndRaise(ref path, value);
        }

        public ObservableCollection<Class_Circuit> Circuits
        {
            get => circuits;
            set => SetAndRaise(ref circuits, value);
        }
    }
}
