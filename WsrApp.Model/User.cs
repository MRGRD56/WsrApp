using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WsrApp.Model
{
    [Table("Users")]
    public class User : Person
    {
        [JsonIgnore]
        public string Login { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
