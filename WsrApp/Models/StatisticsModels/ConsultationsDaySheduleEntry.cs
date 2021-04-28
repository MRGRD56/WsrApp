using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using WsrApp.Model;
using WsrApp.Model.Other;

namespace WsrApp.Models.StatisticsModels
{
    public class ConsultationsDaySheduleEntry : NotifyPropertyChanged
    {
        private bool _isSelected;

        public Consultation Consultation { get; set; }

        //public int GridRow { get; set; }

        //public int GridRowSpan { get; set; }

        public GridLength TopStarMargin { get; set; }

        public GridLength BottomStarMargin { get; set; }

        public GridLength StarHeight { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(BackgroundBrush));
            }
        }

        public SolidColorBrush BackgroundBrush => IsSelected
            ? new SolidColorBrush(Color.FromRgb(0xcf, 0xd8, 0xdc))
            : new SolidColorBrush(Color.FromRgb(0xec, 0xef, 0xf1));
    }
}
