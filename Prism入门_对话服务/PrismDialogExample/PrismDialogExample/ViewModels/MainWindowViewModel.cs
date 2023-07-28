using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace PrismDialogExample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        // dialog服务对象
        private readonly IDialogService dialogService;

        public DelegateCommand<string> OpenCommand { get; set; }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            OpenCommand = new DelegateCommand<string>(OpenDialog);
        }

        /// <summary>
        /// 打开Dialog
        /// </summary>
        /// <param name="obj"></param>
        private void OpenDialog(string obj)
        {
            // 可传递参数
            DialogParameters keys = new DialogParameters();

            keys.Add("Title", "Dialog A");
            // 打开Dialog
            dialogService.ShowDialog(obj, keys, (callBack) =>
            {
                if(callBack.Result == ButtonResult.OK)
                {
                    // 获取参数
                    string value = callBack.Parameters.GetValue<string>("Value");
                }
            });
        }
    }
}
