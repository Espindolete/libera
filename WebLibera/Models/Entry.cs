using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLibera.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Entry
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public byte[] imgData { get; set; }
        

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}