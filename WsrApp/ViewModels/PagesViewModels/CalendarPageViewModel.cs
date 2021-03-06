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
        private Consultation _selectedConsultation;

        public ObservableCollection<Consultation> Consultations { get; set; } = new();
        public ObservableCollection<ConsultationsDay> ConsultationsDays { get; set; } = new();
        public ObservableCollection<ConsultationsDayShedule> ConsultationsDaysShedules { get; set; } = new();

        public int HoursFrom
        {
            get => _hoursFrom;
            set
            {
                if (value == 24)
                {
                    value = 0;
                }
                if (value == -1)
                {
                    value = 23;
                }
                _hoursFrom = value;
            }
        }
        public int HoursCount { get; set; } = 8;

        public ObservableCollection<TimeSpan> LeftTimes { get; set; } = new();

        public DateTime DateFrom { get; set; } = DateTime.Today;

        public DateTime DateTo { get; set; } = DateTime.Today.AddDays(14);

        public CalendarPageViewModel()
        {
            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadConsultationsAsync();
            UpdateDisplayableData();
        }

        private async Task LoadConsultationsAsync()
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
        }

        private void UpdateDisplayableData()
        {
            if (LeftTimes.Count < HoursCount)
            {
                for (var i = 0; i < HoursCount; i++)
                {
                    LeftTimes.Add(new TimeSpan());
                }
            }
            var ltIndex = 0;
            for (var hour = HoursFrom; hour < HoursFrom + HoursCount; hour++)
            {
                var realHour = hour is >= 0 and <= 23 ? hour : 24 - hour;
                //LeftTimes.Add(TimeSpan.FromHours(realHour));
                LeftTimes[ltIndex++] = TimeSpan.FromHours(realHour);
            }

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
                ConsultationsDaysShedules.Add(new ConsultationsDayShedule(x, HoursFrom, HoursCount, SelectedConsultation));
            }
        }

        public Command ChangeTimePageCommand => new(o =>
        {
            var increment = Convert.ToInt32(o);
            ChangeTimePage(increment);
        });

        public void ChangeTimePage(int increment)
        {
            HoursFrom += increment;
            UpdateDisplayableData();
        }

        public Consultation SelectedConsultation
        {
            get => _selectedConsultation;
            set
            {
                _selectedConsultation = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsConsultationSelected));
            }
        }

        public bool IsConsultationSelected => SelectedConsultation != null;

        private void UnselectAllScheduleEntries()
        {
            ConsultationsDaysShedules.ToList().ForEach(x => x.Entries.ForEach(e => e.IsSelected = false));
        }

        public Command SelectConsultationCommand => new(o =>
        {
            var parameter = (ConsultationsDaySheduleEntry)o;
            UnselectAllScheduleEntries();
            parameter.IsSelected = true;
            var consultation = parameter.Consultation;
            SelectedConsultation = consultation;
        });

        public Command UnselectConsultationCommand => new(_ => 
        {
            UnselectAllScheduleEntries();
            SelectedConsultation = null;
        });
    }
}
