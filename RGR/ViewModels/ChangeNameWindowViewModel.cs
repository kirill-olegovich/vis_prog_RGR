using ReactiveUI;
using RGR.Models;
using System.Collections.ObjectModel;

namespace RGR.ViewModels
{
    public class ChangeNameWindowViewModel : ViewModelBase
    {
        private string newName = string.Empty;
        private Class_Circuit? circuit;
        private Class_Project? project;

        public ChangeNameWindowViewModel()
        {
            circuit = null;
            project = null;
        }

        public ChangeNameWindowViewModel(Class_Circuit changeElement)
        {
            circuit = changeElement;
            project = null;
        }

        public ChangeNameWindowViewModel(Class_Project changeElement)
        {
            circuit = null;
            project = changeElement;
        }

        public string NewName
        {
            get => newName;
            set => this.RaiseAndSetIfChanged(ref newName, value);
        }

        public void ButtonSave()
        {
            if (circuit != null)
            {
                if (string.IsNullOrWhiteSpace(NewName) == false)
                {
                    circuit.NameCircuit = NewName;
                }
            }
            else if (project != null)
            {
                if (string.IsNullOrWhiteSpace(NewName) == false)
                {
                    project.NameProject = NewName;
                }
            }
        }

        public void ButtonClear()
        {
            NewName = string.Empty;
        }
    }
}