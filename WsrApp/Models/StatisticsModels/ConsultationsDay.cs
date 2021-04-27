using System;
using System.Collections.Generic;
using System.Text;
using WsrApp.Model;

namespace WsrApp.Models.StatisticsModels
{
    public class ConsultationsDay
    {
        public DateTime Date { get; set; }

        public string WeekDay => Date.DayOfWeek switch
        {
            DayOfWeek.Monday => "ПН",
            DayOfWeek.Tuesday => "ВТ",
            DayOfWeek.Wednesday => "СР",
            DayOfWeek.Thursday => "ЧТ",
            DayOfWeek.Friday => "ПТ",
            DayOfWeek.Saturday => "СБ",
            DayOfWeek.Sunday => "ВС",
            _ => ""
        };

        public List<Consultation> Consultations { get; set; }

        public ConsultationsDay(DateTime date, List<Consultation> consultations)
        {
            Date = date;
            Consultations = consultations;
        }
    }
}
