using System;
using System.Collections.Generic;
using System.Text;

namespace WsrApp.Model
{
    public class Consultation
    {
        public int Id { get; set; }

        public bool IsAccepted { get; set; }

        public Project Project { get; set; }

        public Teacher Teacher { get; set; }

        public Student Student { get; set; }

        public string Description { get; set; }

        public bool HasDescription => !string.IsNullOrWhiteSpace(Description);

        public DateTime RequestDateTime { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime => StartDateTime.AddMinutes(Duration);

        public string TimePeriodString => $"{StartDateTime:HH\\:mm}-{EndDateTime:HH\\:mm}";

        /// <summary>
        /// Длительность в минутах.
        /// </summary>
        public int Duration { get; set; }
    }
}
