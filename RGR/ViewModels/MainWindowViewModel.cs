using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using ReactiveUI;
using RGR.Models;
using RGR.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace RGR.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string path;
        public MainWindow mainWindow;
        private ObservableCollection<Class_Project> projectsToHistory;

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref path, value);
            }
        }

        public MainWindowViewModel(MainWindow mainWindow1)
        {
            mainWindow = mainWindow1;
            projectsToHistory = new ObservableCollection<Class_Project>();
            var colectionLoad = new YAML_Loader();
            ProjectsToHistory = new ObservableCollection<Class_Project>(colectionLoad.YAML_Load());
            //mainWindow.LoadCollection();
        }

        public void Check_button(string name)
        {
            if (name == "New_prog")
            {
                mainWindow.Create_Programm(null, null);
            }
            else if (name == "Create_prog")
            {
                mainWindow.OpenSecondWindow(null, null);
            }
        }

        public ObservableCollection<Class_Project> ProjectsToHistory
        {
            get => projectsToHistory;
            set => this.RaiseAndSetIfChanged(ref projectsToHistory, value);
        }

        public void DoubleTap()
        {
            Debug.WriteLine(ProjectsToHistory[currentIndex].Path);
            ProgrammViewModel dt = new ProgrammViewModel();
            dt.LoadCollection(ProjectsToHistory[currentIndex].Path);
            Debug.WriteLine(ProjectsToHistory[currentIndex].Path);
            
        }

        private int currentIndex;
        public int currentIndexProperties
        {
            get => currentIndex; set
            {
                this.RaiseAndSetIfChanged(ref currentIndex, value);
            }
        }

        //public void LoadCollection()
        //{

        //    //foreach (var sourcee in ProjectsToHistory)
        //    //{
        //    //    Debug.WriteLine(1);
        //    //    if (sourcee is string) Debug.WriteLine(sourcee);
        //    //}
        //    Debug.WriteLine(ProjectsToHistory[0].NameProject);
        //    Debug.WriteLine(ProjectsToHistory[0].Path);


        //    Debug.WriteLine(1);
        //    //Debug.WriteLine(ProjectsToHistory.);
        //}
    }
}
