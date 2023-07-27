using ModuleA;
using ModuleB;
using Prism.Ioc;
using Prism.Modularity;
using PrismNavigationExample.Views;
using System.Windows;

namespace PrismNavigationExample
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

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // 注册模块
            moduleCatalog.AddModule<ModuleAModule>();
            moduleCatalog.AddModule<ModuleBModule>();

            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
