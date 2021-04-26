using System;
using System.Collections.Generic;
using System.Text;

namespace WsrApp.Model
{
    public class ProjectStage
    {
        public int Id { get; set; }

        public Project Project { get; set; }

        public string Name { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
