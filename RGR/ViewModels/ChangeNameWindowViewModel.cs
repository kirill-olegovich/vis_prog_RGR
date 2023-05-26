using ReactiveUI;
using RGR.Models;
using System.Collections.ObjectModel;

namespace RGR.ViewModels
{
    public class ChangeNameWindowViewModel : ViewModelBase
    {
        private string nameCircuit = string.Empty;
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

        public string NameCircuit
        {
            get => nameCircuit;
            set => this.RaiseAndSetIfChanged(ref nameCircuit, value);
        }

        public void ButtonSave()
        {
            if (circuit != null)
            {
                if (string.IsNullOrWhiteSpace(NameCircuit) == false)
                {
                    circuit.NameCircuit = NameCircuit;
                }
            }
            else if (project != null)
            {
                if (string.IsNullOrWhiteSpace(NameCircuit))
                {
                    project.NameProject = NameCircuit;
                }
            }
        }

        public void ButtonClear()
        {
            NameCircuit = string.Empty;
        }
    }
}