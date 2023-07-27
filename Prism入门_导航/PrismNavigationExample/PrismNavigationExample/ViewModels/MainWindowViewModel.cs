using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Linq;

namespace PrismNavigationExample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        // 区域名称
        private string regionName = "ContentRegion";
        private readonly IRegionManager regionManager;

        // 导航命令
        public DelegateCommand<string> OpenCommand { get; set; }

        // 返回上一步命令
        public DelegateCommand BackCommand { get; set; }

        // 返回下一步命令
        public DelegateCommand ForwardCommand { get; set; } 


        // 导航日志
        private IRegionNavigationJournal journal;

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
            BackCommand = new DelegateCommand(Back);
            ForwardCommand = new DelegateCommand(Forward);
        }

        /// <summary>
        /// 返回下一步
        /// </summary>
        private void Forward()
        {
            // 允许返回下一步
            if (journal.CanGoForward)
            {
                journal.GoForward();
            }
        }

        /// <summary>
        /// 返回上一步
        /// </summary>
        private void Back()
        {
            // 允许返回上一步
            if (journal.CanGoBack)
            {
                journal.GoBack();
            }
        }

        private void Open(string obj)
        {
            // 首先通过IRegionManager接口获取到全局定义的可用区域
            // 往这个区域动态设置内容
            // 动态设置的内容就是通过依赖注入的形式
            // obj 就是在App中注入的导航视图的名称


            // 传递参数给视图模型
            NavigationParameters parameters = new NavigationParameters();

            parameters.Add("Title", $"我是视图{obj}");

            // 添加导航回调
            regionManager.Regions[RegionName].RequestNavigate(obj, (navigationCallbackResult) =>
            {
                // 如果导航成功
                if ((bool)navigationCallbackResult.Result)
                {
                    // 给导航日志赋值
                    journal = navigationCallbackResult.Context.NavigationService.Journal;
                }

            },parameters);
        }

    }
}
