using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WsrApp.Model;
using WsrApp.Model.Other;

namespace WsrApp
{
    public static class Account
    {
        public static Guid? Token { get; set; }
        public static User User { get; set; }
        public static string Photo { get; set; }

        public static async void Login(Guid token)
        {
            Token = token;
            var httpClient = new HttpClient();
            var userRaw = await httpClient.GetStringAsync($"{App.ApiUrl}/api/profile?token={Token}");
            var user = JsonConvert.DeserializeObject<Teacher>(userRaw);
            User = user;
            Photo = $"{App.ApiUrl}/api/images/1?token={Token}";
            LoggedIn?.Invoke();
        }

        public static void Logout()
        {
            Token = null;
            User = null;
            Photo = null;
            LoggedOut?.Invoke();
        }

        public static event Action LoggedIn;
        public static event Action LoggedOut;
    }
}
