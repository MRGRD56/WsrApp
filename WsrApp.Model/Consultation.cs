using System;
using System.Collections.Generic;
using System.Text;

namespace WsrApp.Model
{
    public class Consultation
    {
        public int Id { get; set; }

        public bool IsUnaccepted { get; set; }

        public Student Student { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        /// <summary>
        /// Длительность в минутах.
        /// </summary>
        public int Duration { get; set; }
    }
}
