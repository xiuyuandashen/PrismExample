using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismTest1.ViewModels
{
    class ModelAWindowViewModel : BindableBase
    {
        private string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public string Time { get => time; set => time = value; }

        public ModelAWindowViewModel() { }
    }
}
