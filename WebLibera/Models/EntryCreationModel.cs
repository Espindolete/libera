using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLibera.Models
{
    public class EntryCreationModel
    {

        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}