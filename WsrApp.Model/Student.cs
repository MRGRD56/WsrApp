using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WsrApp.Model
{
    [Table("Students")]
    public class Student : Person
    {
        public Faculty Faculty { get; set; }

        public List<StudentSkill> Skills { get; set; } = new();
    }
}
