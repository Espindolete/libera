using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebLibera.Models;

namespace WebLibera.Controllers
{
    public class EntriesController : Controller
    {
        private LiberaModel db = new LiberaModel();


        

        // GET: Entries
        public ActionResult Index()
        {
            var entries = db.Entries;
            foreach(var entry in entries)
            {
                entry.User = null;//porque si no se ve la contraseña de los usuarios si se fijan en algun lado
            }
            return View(entries.ToList());
        }



        // GET: Entries/Details/5
        //podria hacer una sobrecarga y pasarle la entry para que no tenga q conseguir de la base de datos siempre pero es muy tarde para hacerlo ahora
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailEntryModel detailEntry=new DetailEntryModel();
            detailEntry.entry= db.Entries.Find(id);
            detailEntry.entry.User = new User();
            detailEntry.otrasEntries = db.Entries
            .Where(e => e.Id != id).Take(3).ToList();
            foreach (var entry in detailEntry.otrasEntries)
            {
                entry.User = new User();//porque si no se ve la contraseña de los usuarios si se fijan en algun lado
            }
            if (detailEntry.entry == null)
            {
                return HttpNotFound();
            }
            return View(detailEntry);
        }

        // GET: Entries/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username");
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Tittle,Content,UserId")] Entry entry)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entries.Add(entry);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.UserId = new SelectList(db.Users, "Id", "Username", entry.UserId);
        //    return View(entry);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EntryCreationModel entry)
        {
            if (entry.Content!=null &&entry.Tittle!=null)
            {
                Entry entry1 = new Entry();
                entry1.Content = entry.Content;
                entry1.UserId = entry.UserId;
                entry1.Tittle = entry.Tittle;
                if(entry.File != null)
                {
                    byte[] uploadedFile = new byte[entry.File.InputStream.Length];
                    entry.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
                    entry1.imgData = uploadedFile;
                }
                db.Entries.Add(entry1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", entry.UserId);
            return View(entry);
        }

        // GET: Entries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", entry.UserId);
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tittle,Content,UserId")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", entry.UserId);
            return View(entry);
        }

        // GET: Entries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entry entry = db.Entries.Find(id);
            db.Entries.Remove(entry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
