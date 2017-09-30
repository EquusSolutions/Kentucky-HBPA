﻿using System;
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

            byte[] uploadedFile = new byte[file.InputStream.Length];
            file.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            var member = db.Members.FirstOrDefault();

            if (member != null)
            {
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
            }

            return RedirectToAction("Profile","Member");
        }

        public ActionResult MemberCard()
        {
            var memberCards = db.Documents.Where(d => d.Discriminator == DocumentDiscriminator.MemberCard);
            var memberCard = memberCards.FirstOrDefault();

            return PartialView("_MemberCard", memberCard);
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
