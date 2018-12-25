using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace NotesBackend.DataObjects
{
    public class Notes : EntityData
    {
        public string Title { get; set; }
        public string Description { get; set; } 
    }
}