using System;
using System.Collections.Generic;
using System.Text;

namespace WsrApp.Model
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProjectStage> Stages { get; set; } = new();
    }
}
