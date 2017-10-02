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
    public class PhotoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Photo
        public ActionResult Index()
        {
            return View(db.Documents.ToList());
        }

        // GET: Photo/Details/5
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

        // GET: Photo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Photo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberId,FileBytes,ContentLength,ContentType,FileName,UploadedBy,Discriminator,UploadDate")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(document);
        }

        // GET: Photo/Edit/5
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

        // POST: Photo/Edit/5
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

        public ActionResult Fetch(Document Photo)
        {
            return View("Index");
        }

        public ActionResult UploadPhoto()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult UploadPhoto(int? photoId, HttpPostedFileBase file)
        {
            byte[] uploadedFile = new byte[file.InputStream.Length];
            file.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            var member = db.Members.FirstOrDefault();

            if(member != null)
            {
                var documentModel = new Document
                {
                    MemberId = member.Id
                    , UploadedBy = member.FirstName + " " + member.LastName
                    , ContentLength = file.ContentLength
                    , ContentType = file.ContentType
                    , FileName = file.FileName
                    , FileBytes = uploadedFile
                    , UploadDate = DateTime.Now
                    , Discriminator = DocumentDiscriminator.Image
                };
                db.Documents.Add(documentModel);
                db.SaveChanges();
            }
            //Not sure what I am suppose to put here
            return RedirectToAction("Profile", "Member");
        }

        public ActionResult Image()
        {
            var image = db.Documents.Where(d => d.Discriminator == DocumentDiscriminator.Image);
            var oneImage = image.FirstOrDefault();

            return View("Image");
        }

        public ActionResult GetImage()
        {
            var image = db.Documents.Where(d => d.Discriminator == DocumentDiscriminator.Image);
            var oneImage = image.FirstOrDefault();

            if(oneImage != null)
            {
                return File(oneImage.FileBytes, "application/octet-stream", oneImage.FileName);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Photo/Delete/5
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

        // POST: Photo/Delete/5
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