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
    [Authorize]
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

            List<PollOption> pollOptions = db.PollOptions.Where(p => p.Poll.Id == poll.Id).ToList();

            var viewModel = new PollViewModel
            {
                Id = poll.Id,
                Name = poll.Name,
                Question = poll.Question,
                StartDate = poll.StartDate,
                EndDate = poll.EndDate,
                PollOptions = pollOptions
            };

            return View(viewModel);
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
        public ActionResult Create(Poll poll)
        {
            if (ModelState.IsValid)
            {
                db.Polls.Add(poll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poll);
        }

        // GET: Poll/Save/5
        public ActionResult Save(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("PollForm", new PollViewModel());
            }
            Poll poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();                
            }

            List<PollOption> pollOptions = db.PollOptions.Where(p => p.Poll.Id == poll.Id).ToList();

            var viewModel = new PollViewModel
            {
                Id = poll.Id,
                Name = poll.Name,
                Question = poll.Question,
                StartDate = poll.StartDate,
                EndDate = poll.EndDate,
                PollOptions = pollOptions
            };
            return View("PollForm", viewModel);
        }
        
        // https://stackoverflow.com/questions/38513599/asp-net-mvc-how-to-dynamically-add-items-to-an-object-and-bind-it-to-the-contr
        public ActionResult AddPollOption(Poll poll)
        {
            /* 
             ToDo - Check if poll has not been saved to db already
                    if it has not been saved save it
                    if it has works
            */
            var newOption = new PollOption();

            if (poll.Id == 0 && ModelState.IsValid)
            {               
                db.Polls.Add(poll);
                db.SaveChanges();
            }
            else
            {
                RedirectToAction("Save", "Poll", new {poll.Id});
            }
     
            var pollInDb = db.Polls.Find(poll.Id);

            if (pollInDb != null)
            {
                var pollOptionsDb = db.PollOptions.Where(p => p.Poll.Id == poll.Id).ToList();

                pollInDb.PollOptions = pollOptionsDb;

                newOption.Poll = pollInDb;
                newOption.Title = "Enter Poll Option";

                pollInDb.PollOptions.Add(newOption);
                db.SaveChanges();

                return RedirectToAction("Save", "Poll", new {pollInDb.Id});
            }
            return RedirectToAction("Index");
        }

        // POST: Minutes/Save/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PollViewModel pollViewModel)
        {
            // If the poll Id is 0 it is a new poll
            if (pollViewModel.Id == 0)
            {
                var poll = new Poll()
                {
                    Name = pollViewModel.Name,
                    Question = pollViewModel.Question,
                    StartDate = pollViewModel.StartDate,
                    EndDate = pollViewModel.EndDate,
                    PollOptions = pollViewModel.PollOptions
                };
                db.Polls.Add(poll);
            }
            else
            {
                var pollInDb = db.Polls.Single(p => p.Id == pollViewModel.Id);
                var pollOptionsDb = db.PollOptions.Where(p => p.Poll.Id == pollViewModel.Id).ToList();
                
                pollInDb.Name = pollViewModel.Name;
                pollInDb.Question = pollViewModel.Question;
                pollInDb.StartDate = pollViewModel.StartDate;
                pollInDb.EndDate = pollViewModel.EndDate;
                pollInDb.PollOptions = pollOptionsDb;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Poll");
        }

        [AllowAnonymous]
        public ActionResult DisplayPolls()
        {
            return View("PollGallery", db.Polls.Where(p => DateTime.Compare(DateTime.Today,p.EndDate) <= 0).ToList());
        }

        [AllowAnonymous]
        public ActionResult DisplayPoll(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }

            var pollOptions = db.PollOptions.Where(p => p.Poll.Id == poll.Id).ToList();

            var viewModel = new PollViewModel
            {
                Id = poll.Id,
                Name = poll.Name,
                Question = poll.Question,
                StartDate = poll.StartDate,
                EndDate = poll.EndDate,
                PollOptions = pollOptions
            };
            return PartialView("_PollWidget", viewModel);
        }

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
            if (poll != null)
            {
                var pollOptions = db.PollOptions.Where(p => p.PollId == id).ToList();

                foreach (var option in pollOptions)
                {
                    db.PollOptions.Remove(option);
                }

                db.Polls.Remove(poll);
                db.SaveChanges();
            }
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
