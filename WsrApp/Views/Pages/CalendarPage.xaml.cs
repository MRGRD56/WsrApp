using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WsrApp.ViewModels.PagesViewModels;

namespace WsrApp.Views.Pages
{
    /// <summary>
    /// Interaction logic for CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        private CalendarPageViewModel ViewModel => (CalendarPageViewModel)DataContext;

        public CalendarPage()
        {
            InitializeComponent();
        }

        private void Calendar_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //Вниз
            if (e.Delta < 0)
            {
                ViewModel.ChangeTimePage(1);
            }
            //Вверх
            else if (e.Delta > 0)
            {
                ViewModel.ChangeTimePage(-1);
            }
        }
    }
}
