using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WsrApp.Model
{
    public class ApiToken
    {
        [Key]
        public Guid Token { get; set; }

        public User User { get; set; }
    }
}
