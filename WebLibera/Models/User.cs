using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLibera.Models
{
    using System;
    using System.Collections.Generic;

    public partial class User
    {
        public User()
        {
            this.Entries = new HashSet<Entry>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Message { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}