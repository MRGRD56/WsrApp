using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WsrApp.Model
{
    [Table("Users")]
    public class User : Person
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
