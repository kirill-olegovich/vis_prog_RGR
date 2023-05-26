using Avalonia.Controls;
using RGR.Models;
using RGR.ViewModels;

namespace RGR.Views.Elements
{
    public partial class Element_ChangeName : Window
    {
        public Element_ChangeName()
        {
            InitializeComponent();
            DataContext = new ChangeNameWindowViewModel();
        }
        
        public Element_ChangeName(Class_Circuit changeElement)
        {
            InitializeComponent();
            DataContext = new ChangeNameWindowViewModel(changeElement);
        }

        public Element_ChangeName(Class_Project changeElement)
        {
            InitializeComponent();
            DataContext = new ChangeNameWindowViewModel(changeElement);
        }
    }
}
