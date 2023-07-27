using ModuleB.ViewModels;
using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //// 注册ViewB导航并绑定上下文对象为ViewBViewModel
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
        }
    }
}