using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using Avalonia.VisualTree;
using System.Xml.Linq;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            var buttonCreate = mainWindow.GetVisualDescendants().OfType<Button>().First(x => x.Name == "Create");
            var buttonEvent = new RoutedEventArgs(Button.ClickEvent);

            buttonCreate.RaiseEvent(buttonEvent);

            var program = mainWindow.GetProgramm();
            var programViewModel = program.GetProgrammViewModel();

            programViewModel.Take_Button_Name("button1");
            Assert.True(programViewModel.Button_Number == 1);
            programViewModel.Take_Button_Name("button2");
            Assert.True(programViewModel.Button_Number == 2);
            programViewModel.Take_Button_Name("button3");
            Assert.True(programViewModel.Button_Number == 3);
        }
    }
}