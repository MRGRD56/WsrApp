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

        public DateTime CreationTime { get; set; }

        public ApiToken(User user)
        {
            Token = Guid.NewGuid();
            User = user;
            CreationTime = DateTime.Now;
        }

        public ApiToken()
        {
            Token = Guid.NewGuid();
            CreationTime = DateTime.Now;
        }
    }
}
