﻿using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册ViewA导航并绑定上下文对象为ViewAViewModel
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}