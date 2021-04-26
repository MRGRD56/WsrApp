using System;
using System.Collections.Generic;
using System.Text;

namespace WsrApp.Model
{
    public class FacultySpecialty
    {
        public int Id { get; set; }

        public Faculty Faculty { get; set; }

        public Specialty Specialty { get; set; }
    }
}
