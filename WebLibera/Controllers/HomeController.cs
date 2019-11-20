using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLibera.Models;

namespace WebLibera.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Home()
        {
            IEnumerable<Entry> entries = this.GetFirst6Entries();
            return View(entries);
        }

        public IEnumerable<Entry> GetFirst6Entries()
        {
            using (LiberaModel db=new LiberaModel()) {
                IEnumerable<Entry> first6 = db.Entries.OrderByDescending(b => b.Id).Take(6).ToList();
                return first6;
            }
        }

    }
}