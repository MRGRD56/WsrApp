using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WsrApp
{
    public static class Navigation
    {
        public static Frame Frame => App.MainWindow?.Frame;

        public static void GoBack()
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        public static void ClearBackStack()
        {
            if (Frame.BackStack == null) return;

            foreach (var _ in Frame.BackStack.Cast<object>().ToList())
            {
                Frame.RemoveBackEntry();
            }
        }

        /// <summary>
        /// Navigates to the <paramref name="page"/>.
        /// </summary>
        /// <param name="page"></param>
        public static void Navigate(object page) => Frame.Navigate(page);

        /// <summary>
        /// Navigates to a new instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void NavigateNew<T>()
        {
            var page = Activator.CreateInstance<T>();
            Navigate(page);
        }

        public static void NavigateNew(Type type)
        {
            var page = (Page)Activator.CreateInstance(type);
            Navigate(page);
        }
    }
}
