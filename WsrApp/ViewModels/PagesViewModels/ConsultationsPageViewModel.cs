using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsrApp.Model;

namespace WsrApp.ViewModels.PagesViewModels
{
    public class ConsultationsPageViewModel : BaseViewModel
    {
        public ObservableCollection<Consultation> UnacceptedConsultations { get; set; } = new();

        public ConsultationsPageViewModel()
        {
            LoadConsultations();
        }

        private async void LoadConsultations()
        {
            var consultationsRaw = await App.HttpClient.GetStringAsync($"{App.ApiUrl}/api/consultations/unaccepted?token={Account.Token}");
            var consultations = JsonConvert.DeserializeObject<List<Consultation>>(consultationsRaw);
            UnacceptedConsultations.Clear();
            consultations.ForEach(UnacceptedConsultations.Add);
        }
    }
}
