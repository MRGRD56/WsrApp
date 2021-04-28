using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WsrApp.Model;

namespace WsrApp.Models.StatisticsModels
{
    public class ConsultationsDayShedule
    {
        public ConsultationsDay ConsultationsDay { get; }

        public List<ConsultationsDaySheduleEntry> Entries { get; } = new();

        private readonly int _hourFrom;
        private readonly int _hoursCount;
        private readonly Consultation _selectedConsultation;

        public ConsultationsDayShedule(ConsultationsDay consultationsDay, int hourFrom, int hoursCount, Consultation selectedConsultation)
        {
            ConsultationsDay = consultationsDay;
            _hourFrom = hourFrom;
            _hoursCount = hoursCount;
            _selectedConsultation = selectedConsultation;
            CalculateEntries();
        }

        private void CalculateEntries()
        {
            var rangeConsultations = ConsultationsDay.Consultations
                .Where(x =>
                {
                    //return x.StartDateTime.Hour >= _hourFrom
                    //                    && x.StartDateTime.Hour <= _hourFrom + _hoursCount - 1
                    //                    && x.EndDateTime.Hour >= _hourFrom
                    //                    && x.EndDateTime.Hour <= _hourFrom + _hoursCount;
                    return x.EndDateTime.TimeOfDay > TimeSpan.FromHours(_hourFrom)
                        && x.StartDateTime.TimeOfDay < TimeSpan.FromHours(_hourFrom + _hoursCount);
                })
                .ToList();

            rangeConsultations.ForEach(x => 
            {
                ////Часы, в пределах которых проводится консультация.
                ////Если время 12:40-13:10, тот totalHours - с 12 по 14.
                //var totalHoursCount = x.EndDateTime.Hour - x.StartDateTime.Hour + 1;
                //if (x.Duration % 60 == 0)
                //{
                //    totalHoursCount--;
                //}
                //var totalHoursSeconds = totalHoursCount * 60 * 60;
                //var totalHoursStart = x.StartDateTime.Hour;
                //var totalHoursEnd = totalHoursStart + totalHoursCount;

                var totalSeconds = _hoursCount * 60 * 60;
                var consultationStartSeconds = x.StartDateTime.TimeOfDay.Add(TimeSpan.FromHours(-_hourFrom)).TotalSeconds;
                var consultationEndSeconds = x.EndDateTime.TimeOfDay.Add(TimeSpan.FromHours(-_hourFrom)).TotalSeconds;
                if (consultationStartSeconds < 0)
                {
                    consultationStartSeconds = 0;
                }
                if (consultationEndSeconds > totalSeconds)
                {
                    consultationEndSeconds = totalSeconds;
                }
                var consultationSeconds = consultationEndSeconds - consultationStartSeconds;

                var topMargin = consultationStartSeconds / totalSeconds;
                var height = consultationSeconds / totalSeconds;
                var bottomMargin = (totalSeconds - consultationEndSeconds) / totalSeconds;

                var isSelected = _selectedConsultation != null && _selectedConsultation.Id == x.Id;

                Entries.Add(new ConsultationsDaySheduleEntry
                {
                    Consultation = x,
                    TopStarMargin = new GridLength(topMargin, GridUnitType.Star),
                    StarHeight = new GridLength(height, GridUnitType.Star),
                    BottomStarMargin = new GridLength(bottomMargin, GridUnitType.Star),
                    IsSelected = isSelected
                });
            });
        }
    }
}
