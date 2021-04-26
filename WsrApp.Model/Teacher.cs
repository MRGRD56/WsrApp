using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WsrApp.Model
{
    [Table("Teachers")]
    public class Teacher : User
    {
        public Faculty Faculty { get; set; }
    }
}
