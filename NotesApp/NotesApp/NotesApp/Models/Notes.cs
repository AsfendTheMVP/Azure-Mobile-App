using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Models
{
    public class Notes
    {
        public bool deleted { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime createdAt { get; set; }
        public string version { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
    }
}
