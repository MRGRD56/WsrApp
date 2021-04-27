using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WsrApp.Model;
using WsrApp.Models.StatisticsModels;

namespace WsrApp.ViewModels.PagesViewModels
{
    public class CalendarPageViewModel : BaseViewModel
    {
        private int _hoursFrom = 9;

        public ObservableCollection<Consultation> Consultations { get; set; } = new();
        public ObservableCollection<ConsultationsDay> ConsultationsDays { get; set; } = new();
        public ObservableCollection<ConsultationsDayShedule> ConsultationsDaysShedules { get; set; } = new();

        public int HoursFrom
        {
            get => _hoursFrom;
            set
            {
                if (_hoursFrom <= 0 || _hoursFrom >= 23 - HoursCount)
                _hoursFrom = value;
            }
        }
        public int HoursCount { get; set; } = 8;

        public DateTime DateFrom { get; set; } = DateTime.Today;

        public DateTime DateTo { get; set; } = DateTime.Today.AddDays(14);

        public CalendarPageViewModel()
        {
            LoadConsultations();
        }

        private async void LoadConsultations()
        {
            var url = $"{App.ApiUrl}/api/consultations?token={Account.Token}";
            var request = await App.HttpClient.GetAsync(url);
            var consultationsRaw = await request.Content.ReadAsStringAsync();
            var consultations = JsonConvert.DeserializeObject<List<Consultation>>(consultationsRaw);
            Consultations.Clear();

            var syncContext = SynchronizationContext.Current;
            consultations.ForEach(x =>
            {
                syncContext.Send(_ =>
                {
                    Consultations.Add(x);
                }, null);
            });

            ConsultationsDays.Clear();
            for (var date = DateFrom; date <= DateTo; date = date.AddDays(1))
            {
                var dateConsultations = Consultations
                    .Where(x => x.StartDateTime.Date == date.Date)
                    .OrderBy(x => x.StartDateTime)
                    .ToList();

                var consultationDay = new ConsultationsDay(date, dateConsultations);
                ConsultationsDays.Add(consultationDay);
            }

            ConsultationsDaysShedules.Clear();
            foreach (var x in ConsultationsDays)
            {
                ConsultationsDaysShedules.Add(new ConsultationsDayShedule(x, HoursFrom, HoursCount));
            }
        }
    }
}
