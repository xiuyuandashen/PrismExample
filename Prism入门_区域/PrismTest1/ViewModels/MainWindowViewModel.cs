using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using static ImTools.ImMap;

namespace PrismTest1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        // 区域名称
        private string regionName = "ContentRegion";
        private readonly IRegionManager regionManager;

        // 导航命令
        public DelegateCommand<string> OpenCommand { get; set; }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string RegionName
        {
            get => regionName; set
            {
                SetProperty(ref regionName, value);
            }
        }


        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            OpenCommand = new DelegateCommand<string>(Open);
        }

        private void Open(string obj)
        {
            // 首先通过IRegionManager接口获取到全局定义的可用区域
            // 往这个区域动态设置内容
            // 动态设置的内容就是通过依赖注入的形式
            // obj 就是在App中注入的导航视图的名称
            regionManager.Regions[RegionName].RequestNavigate(obj);
        }
    }
}
