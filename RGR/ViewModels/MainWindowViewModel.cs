using Avalonia.Interactivity;
using ReactiveUI;
using RGR.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace RGR.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string path;
        public MainWindow mainWindow;

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
    }
}
