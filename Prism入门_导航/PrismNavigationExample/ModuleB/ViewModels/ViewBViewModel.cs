using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModuleB.ViewModels
{
    public class ViewBViewModel : BindableBase,IConfirmNavigationRequest
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewBViewModel()
        {
            Message = "View B from your Prism Module";
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 获取入参
            if (navigationContext.Parameters.ContainsKey("Title"))
                Message = navigationContext.Parameters.GetValue<string>("Title");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        /// <summary>
        /// 离开导航时调用（拦截），可取消导航，需要实现IConfirmNavigationRequest接口，该接口继承自INavigationAware
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <param name="continuationCallback"></param>
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;

            // 弹窗确认是否导航至其他页面
            if(MessageBox.Show($"确认是否导航至{navigationContext.Uri.OriginalString}?","温馨提示",MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                // 取消导航
                result = false;
            }

            // 回传结果，是否允许导航到其他页面
            continuationCallback(result);
        }
    }
}
