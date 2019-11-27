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

        public ActionResult Home(string asd=" ")
        {
            ViewBag.Position = asd;
            HomeModel hm = new HomeModel();
            hm.FAQ = null;
            hm.first6Camp = null;
            using (LiberaModel db = new LiberaModel())
            {
                
                
                    hm.first6Camp = db.Entries.OrderByDescending(b => b.Id).Take(6).ToList();
                    
              
            }
            return View(hm);
        }

        public ActionResult Donar()
        {
            return View();
        }
       

    }
}