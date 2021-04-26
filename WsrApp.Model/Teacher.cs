using System;
using System.Collections.Generic;
using System.Text;

namespace WsrApp.Model
{
    public class Teacher : User
    {
        public Faculty Faculty { get; set; }
    }
}
