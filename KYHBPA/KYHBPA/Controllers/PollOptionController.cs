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
    public class PollOptionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PollOption
        public ActionResult Index()
        {
            return View(db.PollOptions.ToList());
        }

        // GET: PollOption/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PollOption pollOption = db.PollOptions.Find(id);
            if (pollOption == null)
            {
                return HttpNotFound();
            }
            return View(pollOption);
        }

        // GET: PollOption/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PollOption/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Votes,Title")] PollOption pollOption)
        {
            if (ModelState.IsValid)
            {
                db.PollOptions.Add(pollOption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pollOption);
        }

        // GET: PollOption/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PollOption pollOption = db.PollOptions.Find(id);
            if (pollOption == null)
            {
                return HttpNotFound();
            }
            return View(pollOption);
        }

        // POST: PollOption/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Votes,Title")] PollOption pollOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pollOption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pollOption);
        }

        // GET: PollOption/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PollOption pollOption = db.PollOptions.Find(id);
            if (pollOption == null)
            {
                return HttpNotFound();
            }
            return View(pollOption);
        }

        // POST: PollOption/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PollOption pollOption = db.PollOptions.Find(id);
            db.PollOptions.Remove(pollOption);
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
