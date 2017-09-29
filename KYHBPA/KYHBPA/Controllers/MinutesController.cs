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
    public class MinutesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Minutes
        public ActionResult Index()
        {
            var minutes = db.Minutes.Select(m => new MinutesViewModel()
            {
                Id = m.Id,
                Date = m.Date,
                MinutesType = m.MinutesType,
                Note = m.Note
            });

            return View(minutes);
            //return View(db.Minutes.ToList());
        }

        // GET: Minutes/BoardMinutes
        public ActionResult BoardMinutes()
        {
            var viewModels = db.Minutes.Where(m => m.MinutesType == MinutesType.Board).Select(m => new MinutesViewModel()
            {
                Id = m.Id,
                Date = m.Date,
                MinutesType = m.MinutesType,
                Note = m.Note
            });

            if (User.IsInRole(RoleName.Administrator) || User.IsInRole(RoleName.Staff))           
                return View("Index", viewModels);

            return View("MinutesView", viewModels);
        }

        // GET: Minutes/Community
        public ActionResult CommunityMinutes()
        {
            var viewModels = db.Minutes.Where(m => m.MinutesType == MinutesType.Community).Select(m => new MinutesViewModel()
            {
                Id = m.Id,
                Date = m.Date,
                MinutesType = m.MinutesType,
                Note = m.Note
            });
            if (User.IsInRole(RoleName.Administrator) || User.IsInRole(RoleName.Staff))
                return View("Index", viewModels);

            return View("MinutesView", viewModels);
        }

        // GET: Minutes/Other
        public ActionResult OtherMinutes()
        {
            var viewModels = db.Minutes.Where(m => m.MinutesType == MinutesType.Other).Select(m => new MinutesViewModel()
            {
                Id = m.Id,
                Date = m.Date,
                MinutesType = m.MinutesType,
                Note = m.Note
            });
            if (User.IsInRole(RoleName.Administrator) || User.IsInRole(RoleName.Staff))
                return View("Index", viewModels);

            return View("MinutesView", viewModels);
        }

        // GET: Minutes/Details/5
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.Staff)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Minutes minutes = db.Minutes.Find(id);
            if (minutes == null)
            {
                return HttpNotFound();
            }
            return View(minutes);
        }

        // GET: Minutes/Create
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.Staff)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Minutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.Staff)]
        public ActionResult Create([Bind(Include = "Id,Note,Date,MinutesType")] Minutes minutes)
        {
            if (ModelState.IsValid)
            {
                db.Minutes.Add(minutes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(minutes);
        }

        // GET: Minutes/Edit/5
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.Staff)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Minutes minutes = db.Minutes.Find(id);
            if (minutes == null)
            {
                return HttpNotFound();
            }
            return View(minutes);
        }

        // POST: Minutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.Staff)]
        public ActionResult Edit([Bind(Include = "Id,Note,Date,MinutesType")] Minutes minutes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(minutes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(minutes);
        }

        // GET: Minutes/Delete/5
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.Staff)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Minutes minutes = db.Minutes.Find(id);
            if (minutes == null)
            {
                return HttpNotFound();
            }
            return View(minutes);
        }

        // POST: Minutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.Staff)]
        public ActionResult DeleteConfirmed(int id)
        {
            Minutes minutes = db.Minutes.Find(id);
            db.Minutes.Remove(minutes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Minutes/Save/5
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.Staff)]
        public ActionResult Save(int? id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Minutes minutes = db.Minutes.Find(id);
            if (minutes == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MinutesViewModel()
            {
                Id = minutes.Id,
                Note = minutes.Note,
                Date = minutes.Date,
                MinutesType = minutes.MinutesType
            };
            return View("MinutesFormView", viewModel);
        }

        // POST: Minutes/Save/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.Staff)]
        public ActionResult Save(Minutes minutes)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MinutesViewModel()
                {
                    Id = minutes.Id,
                    Note = minutes.Note,
                    Date = minutes.Date,
                    MinutesType = minutes.MinutesType
                };
                return View("MinutesFormView", viewModel);
            }
            // If the minutes Id is 0 it is a new customer
            if (minutes.Id == 0)
            {
                db.Minutes.Add(minutes);
            }
            else
            {
                var minuteInDb = db.Minutes.Single(m => m.Id == minutes.Id);

                minuteInDb.Note = minutes.Note;
                minuteInDb.Date = minutes.Date;
                minuteInDb.MinutesType = minutes.MinutesType;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Minutes");
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
