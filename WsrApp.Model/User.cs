using System;
using System.Collections.Generic;
using System.Text;

namespace WsrApp.Model
{
    public class User
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string Login { get; set; }

        public byte[] Password { get; set; }
    }
}
