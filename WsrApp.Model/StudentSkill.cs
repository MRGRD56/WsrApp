using System;
using System.Collections.Generic;
using System.Text;

namespace WsrApp.Model
{
    public class StudentSkill
    {
        public int Id { get; set; }

        public Student Student { get; set; }

        public string Skill { get; set; }
    }
}
