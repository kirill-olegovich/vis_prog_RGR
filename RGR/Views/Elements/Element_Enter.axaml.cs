using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace RGR.Views.Elements
{
    public class Element_Enter : TemplatedControl
    {
        public static readonly StyledProperty<string> statusProperty = AvaloniaProperty.Register<Element_Enter, string>("status");

        public string status 
        { 
            get => GetValue(statusProperty); 
            set => SetValue(statusProperty, value); 
        }
    }
}
