using Avalonia.Controls;
using Avalonia.Interactivity;
using System.ComponentModel;
using RGR.ViewModels;

namespace RGR.Views
{
    public partial class MainWindow : Window
    {

        private Programm programm;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }
        public void Exit_programm(object sender, RoutedEventArgs eventArgs)
        {
            this.Close();
        }

        public void Exit_programm2(object? sender, CancelEventArgs e)
        {
            this.Close();
        }

        public void Create_Programm(object sender, RoutedEventArgs eventArgs)
        {
            programm= new Programm();
            this.Hide();
            programm.Show();
            programm.Closing += Exit_programm2;
        }

        public async void OpenSecondWindow(object sender, RoutedEventArgs eventArgs)
        {
            programm = new Programm();
            this.Hide();
            programm.Show();
            programm.Closing += Exit_programm2;

            programm.LoadFile(null, null);

        }

        public void ButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            if (DataContext is MainWindowViewModel mainWindowViewModel)
            {
                if (sender is Button button)
                {
                    mainWindowViewModel.Check_button(button.Name);
                }
            }
        }

        public Programm GetProgramm()
        {
            return programm;
        }

        //public async void SaveFile(object sender, RoutedEventArgs args)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();

        //    string? result = await saveFileDialog.ShowAsync(this);

        //    if (DataContext is MainWindowViewModel mainWindowViewModel)
        //    {
        //        if (result != null)
        //        {
        //            mainWindowViewModel.Path = string.Join(';', result);
        //        }
        //        else
        //        {
        //            mainWindowViewModel.Path = "Window was canceled";
        //        }
        //    }
        //}
    }
}
