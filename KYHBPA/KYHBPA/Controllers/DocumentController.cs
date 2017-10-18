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
    public class DocumentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Document
        public ActionResult Index() 
        {
            return View(db.Documents.ToList());
        }

        // GET: Document/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Document/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Document/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberId,FileBytes,ContentLength,ContentType,FileName,UploadedBy")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(document);
        }

        // GET: Document/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Document/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberId,FileBytes,ContentLength,ContentType,FileName,UploadedBy,Discriminator,UploadDate")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(document);
        }

        public ActionResult Fetch(Document document)
        {

            return View("Index");
        }

        public ActionResult UploadMemberCard()
        {
            return View("UploadMemberCard");
        }

        [HttpPost]
        public ActionResult UploadMemberCard(int? memberId, HttpPostedFileBase file)
        {
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
                UploadedBy = member.FirstName + " " + member.LastName,
                ContentLength = file.ContentLength,
                ContentType = file.ContentType,
                FileName = file.FileName,
                FileBytes = uploadedFile,
                UploadDate = DateTime.Now,
                Discriminator = DocumentDiscriminator.MemberCard                
            };

            db.Documents.Add(documentModel);
            db.SaveChanges();

            return RedirectToAction("MyProfile","Member");
        }

        public ActionResult PhotoGallery()
        {
            var photos = db.Documents.Where(i => i.Discriminator == DocumentDiscriminator.Image).ToList();

                return View(photos);
        }

        public ActionResult DownloadMemberCard()
        {
            //var memberCards = db.Documents.Where(d => d.Discriminator == DocumentDiscriminator.MemberCard && string.Compare(d.FileName, "Member Card.pdf") == 0);
            var memberCard = db.Documents.FirstOrDefault(d => d.Discriminator == DocumentDiscriminator.MemberCard && string.Compare(d.FileName.ToLower(), "member card.pdf") == 0);

            if (memberCard != null)
            {
                return File(memberCard.FileBytes, "application/octet-stream", memberCard.FileName);
            }

            return RedirectToAction("Index","Home");
        }

        public ActionResult MemberCard()
        {
            var userId = User.Identity.GetUserName();
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var username = User.Identity.GetUserName();
            var member = db.Members.FirstOrDefault(m => String.Compare(m.Email, username) == 0);

            var memberCards = db.Documents.Where(d => d.Discriminator == DocumentDiscriminator.MemberCard && 
                        string.Compare(d.FileName, "Member Card.pdf") != 0 &&
                        d.MemberId == member.Id);
            var memberCard = memberCards.FirstOrDefault();
            if (memberCard != null)
                return PartialView("_MemberCard", memberCard);

            return PartialView("_UploadMemberCard");

        }

        public ActionResult NewsLetter()
        {
            var newsletter = db.Documents.Where(d => d.Discriminator == DocumentDiscriminator.Newsletter);
            var oneNewsletter = newsletter.FirstOrDefault();

            return View("Newsletter", oneNewsletter);
        }

        public ActionResult GetNewsletter()
        {
            var newsletter = db.Documents.Where(d => d.Discriminator == DocumentDiscriminator.Newsletter);
            var oneNewsletter = newsletter.FirstOrDefault();

            if (oneNewsletter != null)
            {
                return File(oneNewsletter.FileBytes, "application/octet-stream", oneNewsletter.FileName);
            }
    
            return RedirectToAction("Index","Home");
        }

        // GET: Document/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Document/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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