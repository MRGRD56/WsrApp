using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using WsrApp.Views.Windows;

namespace WsrApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static MainWindow MainWindow => (MainWindow)Current.MainWindow;

        public const string ApiUrl = "http://192.168.102.137:1234";

        public static readonly HttpClient HttpClient = new();
    }
}
