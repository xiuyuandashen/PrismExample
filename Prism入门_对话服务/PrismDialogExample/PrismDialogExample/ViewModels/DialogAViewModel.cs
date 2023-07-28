using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDialogExample.ViewModels
{
    public class DialogAViewModel : BindableBase, IDialogAware
    {
        private string title;

        public string Title
        {
            get => title; 
            set
            {
                title = value; RaisePropertyChanged();
            }
        }

        public event Action<IDialogResult> RequestClose;


        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand ConfirmCommand { get; set; }

        public DialogAViewModel()
        {
            CancelCommand = new DelegateCommand(Cancel);
            ConfirmCommand = new DelegateCommand(Confirm);
        }

        /// <summary>
        /// 确认
        /// </summary>
        private void Confirm()
        {
            OnDialogClosed();
        }


        /// <summary>
        /// 取消
        /// </summary>
        private void Cancel()
        {
            // 返回 ButtonResult.No 给回调函数
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }


        /// <summary>
        /// 是否可以关闭Dialog
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// 关闭Dialog时调用
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnDialogClosed()
        {
            // 可以传递参数出去给弹窗回调函数
            DialogParameters keys = new DialogParameters();
            keys.Add("Value", "hello world!");
            // 返回结果给回调函数
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, keys));
        }

        /// <summary>
        /// 打开对话框时调用
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            //获取入参
            Title = parameters.GetValue<string>("Title");
        }
    }
}
