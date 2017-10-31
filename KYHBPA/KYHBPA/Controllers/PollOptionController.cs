using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Models;
using Microsoft.AspNet.Identity;

namespace KYHBPA.Controllers
{
    [Authorize]
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
        public ActionResult Create(PollOption pollOption)
        {
            if (ModelState.IsValid)
            {
                db.PollOptions.Add(pollOption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pollOption);
        }

        public ActionResult Vote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pollOption = db.PollOptions.Find(id);
            if (pollOption == null)
            {
                return HttpNotFound();
            }

            var userId = User.Identity.GetUserId();

            var voteInDb = db.Votes.FirstOrDefault(v => v.Voter == userId
                && v.PollId == pollOption.PollId);

            if (voteInDb == null)
            {
                var vote = new Vote
                {
                    Voter = userId,
                    PollId = pollOption.PollId
                };
                db.Votes.Add(vote);
                db.SaveChanges();

                pollOption.Votes++;
                db.Entry(pollOption).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("DisplayPolls", "Poll");
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
        public ActionResult Edit(PollOption pollOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pollOption).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Save", "Poll", new { id = pollOption.PollId });
            }
            return View(pollOption);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateOption(int? id, string title)
        {
            var pollOption = db.PollOptions.Find(id);
            if (pollOption == null)
            {
                pollOption.Title = title;
                db.Entry(pollOption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
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
            var pollOption = db.PollOptions.Find(id);
            if (pollOption != null)
            {
                var pollId = pollOption.PollId;

                db.PollOptions.Remove(pollOption);
                db.SaveChanges();

                return RedirectToAction("Save", "Poll", new {id = pollId});
            }
            return RedirectToAction("Index", "Poll");
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
