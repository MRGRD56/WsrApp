using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WsrApp.Model.Other;

namespace WsrApp.ViewModels
{
    public class BaseViewModel : NotifyPropertyChanged
    {
        public Command GoBackCommand => new(_ => 
        {
            Navigation.GoBack();
        });

        public Command NavigateCommand => new(o => 
        {
            var type = (Type)o;
            Navigation.NavigateNew(type);
        });
    }
}
