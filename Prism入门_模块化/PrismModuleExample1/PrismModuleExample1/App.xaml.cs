
using Prism.Ioc;
using Prism.Modularity;
using PrismModuleExample1.Views;
using System.Windows;

namespace PrismModuleExample1
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

        //protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        //{
        //    // 添加模块
        //    moduleCatalog.AddModule<ModuleAProfile>();
        //    moduleCatalog.AddModule<ModuleBProfile>();
        //    base.ConfigureModuleCatalog(moduleCatalog);
        //}

        protected override IModuleCatalog CreateModuleCatalog()
        {
            // 读取Modules的DLL添加对应模块
            return new DirectoryModuleCatalog() { ModulePath = @"./Modules" };
        }
    }
}
