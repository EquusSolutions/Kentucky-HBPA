using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Models;

namespace KYHBPA.Controllers
{
    public class MinutesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Minutes
        public ActionResult Index()
        {
            return View(db.Minutes.ToList());
        }

        // GET: Minutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Minute minute = db.Minutes.Find(id);
            if (minute == null)
            {
                return HttpNotFound();
            }
            return View(minute);
        }

        // GET: Minutes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Minutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Note,Date,MinuteType")] Minute minute)
        {
            if (ModelState.IsValid)
            {
                db.Minutes.Add(minute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(minute);
        }

        // GET: Minutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Minute minute = db.Minutes.Find(id);
            if (minute == null)
            {
                return HttpNotFound();
            }
            return View(minute);
        }

        // POST: Minutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Note,Date,MinuteType")] Minute minute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(minute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(minute);
        }

        // GET: Minutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Minute minute = db.Minutes.Find(id);
            if (minute == null)
            {
                return HttpNotFound();
            }
            return View(minute);
        }

        // POST: Minutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Minute minute = db.Minutes.Find(id);
            db.Minutes.Remove(minute);
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
