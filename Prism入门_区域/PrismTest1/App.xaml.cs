using Prism.Ioc;
using PrismTest1.Views;
using System.Windows;

namespace PrismTest1
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
            // 注册 IOC 导航模型
            containerRegistry.RegisterForNavigation<ModelAWindow>("ModelA");
            containerRegistry.RegisterForNavigation<ModelBWindow>("ModelB");
        }
    }
}
