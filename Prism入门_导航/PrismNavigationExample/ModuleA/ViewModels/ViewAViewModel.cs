using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase,INavigationAware
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel()
        {
            Message = "View A from your Prism Module";
        }

        /// <summary>
        /// 当导航进来时调用
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 获取入参
            if(navigationContext.Parameters.ContainsKey("Title"))
                Message = navigationContext.Parameters.GetValue<string>("Title");
        }

        /// <summary>
        /// 每次重新导航的时候，是否重用原来的实例
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // 每次导航都是新的对象
            return false;
        }

        /// <summary>
        /// 当导航离开时调用
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // 判断即将导航的页面是否为ViewB
            if (navigationContext.Uri.OriginalString.Equals("ViewB"))
            {
                Console.WriteLine("去ViewB");
            }
        }
    }
}
