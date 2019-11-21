using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLibera.Models
{
    public class HomeModel
    {
        public IEnumerable<Entry> first6Camp { get; set;}
        public IEnumerable<AnsweredQuestions> FAQ { get; set; }

    }
}