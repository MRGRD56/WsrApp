using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WsrApp.Views.Pages;

namespace WsrApp.ViewModels.PagesViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public string Login { get; set; } = "";

        public Command LoginCommand => new(async o => 
        {
            var passwordBox = (PasswordBox)o;

            var login = Login?.ToLower()?.Trim();
            var password = passwordBox.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Вход", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var tokenRequest = await App.HttpClient.GetAsync($"{App.ApiUrl}/api/accesstoken?login={login}&password={password}");
            var content = await tokenRequest.Content.ReadAsStringAsync();

            if (!tokenRequest.IsSuccessStatusCode)
            {
                MessageBox.Show(content, "Вход", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var token = JsonConvert.DeserializeObject<Guid>(content);
            //if (!Guid.TryParse(content, out var token))
            //{
            //    MessageBox.Show("Ошибка сервера: неверный токен.", "Вход", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            Account.Login(token);
            Navigation.NavigateNew<CalendarPage>();
        });
    }
}
