using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLibera.Models
{
    public class DetailEntryModel
    {
        public Entry entry { get; set; }
        public List<Entry> otrasEntries { get; set; }
    }
}