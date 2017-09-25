using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Models;
using KYHBPA.Models.ViewModels;

namespace KYHBPA.Controllers
{
    public class PollController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Poll
        public ActionResult Index()
        {
            return View(db.Polls.ToList());
        }

        // GET: Poll/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(poll);
        }

        // GET: Poll/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Poll/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Question,StartDate,EndDate")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                db.Polls.Add(poll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poll);
        }

        // GET: Poll/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(poll);
        }

        // POST: Poll/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,StartDate,EndDate")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poll);
        }

        // GET: Minutes/Save/5
        public ActionResult Save(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }
            //List<PollOption> pollOptions = db.PollOptions.Where(p => p.Poll == poll).ToList();
            List<PollOption> pollOptions = new List<PollOption>();
            //pollOptions.Add(new PollOption{Poll = poll, Votes = 0, Title = "Option 1"});
            //pollOptions.Add(new PollOption { Poll = poll, Votes = 0, Title = "Option 2" });
            //pollOptions.Add(new PollOption { Poll = poll, Votes = 0, Title = "Option 3" });
            //pollOptions.Add(new PollOption { Poll = poll, Votes = 0, Title = "Option 4" });
            var viewModel = new PollViewModel()
            {
                Poll = poll,
                PollOptions = pollOptions
            };
            return View("PollForm", viewModel);
        }
        
        // https://stackoverflow.com/questions/38513599/asp-net-mvc-how-to-dynamically-add-items-to-an-object-and-bind-it-to-the-contr
        public ActionResult AddPollOption(int PollId)
        {
            var newOption = new PollOption();
            Poll poll = db.Polls.Find(PollId);
            poll.PollOptions.Add(newOption);
            db.SaveChanges();

            return View("PollForm");
        }

        // POST: Minutes/Save/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Save(Minutes minutes)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var viewModel = new MinutesViewModel()
        //        {
        //            Id = minutes.Id,
        //            Note = minutes.Note,
        //            Date = minutes.Date,
        //            MinutesType = minutes.MinutesType
        //        };
        //        return View("MinutesFormView", viewModel);
        //    }
        //    // If the minutes Id is 0 it is a new customer
        //    if (minutes.Id == 0)
        //    {
        //        db.Minutes.Add(minutes);
        //    }
        //    else
        //    {
        //        var minuteInDb = db.Minutes.Single(m => m.Id == minutes.Id);

        //        minuteInDb.Note = minutes.Note;
        //        minuteInDb.Date = minutes.Date;
        //        minuteInDb.MinutesType = minutes.MinutesType;
        //    }

        //    db.SaveChanges();

        //    return RedirectToAction("Index", "Minutes");
        //}

        // GET: Poll/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(poll);
        }

        // POST: Poll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poll poll = db.Polls.Find(id);
            db.Polls.Remove(poll);
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
