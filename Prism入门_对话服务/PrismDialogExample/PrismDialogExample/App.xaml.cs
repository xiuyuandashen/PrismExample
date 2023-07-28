using Prism.Ioc;
using PrismDialogExample.ViewModels;
using PrismDialogExample.Views;
using System.Windows;

namespace PrismDialogExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<DialogA, DialogAViewModel>();
        }
    }
}
