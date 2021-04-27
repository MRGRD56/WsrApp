using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WsrApp.Model;

namespace WsrApp.Models.StatisticsModels
{
    public class ConsultationsDaySheduleEntry
    {
        public Consultation Consultation { get; set; }

        //public int GridRow { get; set; }

        //public int GridRowSpan { get; set; }

        public GridLength TopStarMargin { get; set; }

        public GridLength BottomStarMargin { get; set; }

        public GridLength StarHeight { get; set; }
    }
}
