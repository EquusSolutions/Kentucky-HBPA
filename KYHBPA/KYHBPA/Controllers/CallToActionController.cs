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
    public class CallToActionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CallToAction
        public ActionResult Index()
        {
            return View(db.CallToActions.ToList());
        }

        // GET: CallToAction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallToAction callToAction = db.CallToActions.Find(id);
            if (callToAction == null)
            {
                return HttpNotFound();
            }
            return View(callToAction);
        }

        // GET: CallToAction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CallToAction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CallToAction callToAction, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserName();
                if (userId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var username = User.Identity.GetUserName();
                var member = db.Members.FirstOrDefault(m => m.Email == username);

                if (member == null)
                {
                    return HttpNotFound();
                }

                byte[] uploadedFile = new byte[file.InputStream.Length];
                file.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

                var documentModel = new Document
                {
                    MemberId = member.Id,
                    UploadedBy = HttpContext.User.Identity.Name,
                    ContentLength = file.ContentLength,
                    ContentType = file.ContentType,
                    FileName = file.FileName,
                    FileBytes = uploadedFile,
                    UploadDate = DateTime.Now,
                    Discriminator = DocumentDiscriminator.Image
                };

                db.Documents.Add(documentModel);
                db.SaveChanges();
                
                callToAction.Image = documentModel;
                callToAction.ImageId = documentModel.Id;
                callToAction.Date = DateTime.Now;

                db.CallToActions.Add(callToAction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(callToAction);
        }

        // GET: CallToAction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallToAction callToAction = db.CallToActions.Find(id);
            if (callToAction == null)
            {
                return HttpNotFound();
            }
            return View(callToAction);
        }

        // POST: CallToAction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CallToAction callToAction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(callToAction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(callToAction);
        }

        // GET: CallToAction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallToAction callToAction = db.CallToActions.Find(id);
            if (callToAction == null)
            {
                return HttpNotFound();
            }
            return View(callToAction);
        }

        // POST: CallToAction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CallToAction callToAction = db.CallToActions.Find(id);
            db.CallToActions.Remove(callToAction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CallToActionGallery()
        {
            var callToAction = db.CallToActions.ToList();
            var images = db.Documents.Where(d => d.Discriminator == DocumentDiscriminator.Image);
            foreach (var image in images)
            {
                for (int i = 0; i < callToAction.Count; i++)
                {
                    if (image.Id == callToAction[i].ImageId)
                    {
                        callToAction[i].Image = image;
                        break;
                    }
                }
            }
            return View(callToAction);
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
