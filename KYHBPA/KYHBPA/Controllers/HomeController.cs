using KYHBPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KYHBPA.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "THE HBPA IS YOU";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DocumentManagement()
        {
            return View();
        }
        
        public ActionResult BoardOfDirectors()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadDocument(int memberId, HttpPostedFileBase file)
        {

            byte[] uploadedFile = new byte[file.InputStream.Length];
            file.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            var member = db.Members.FirstOrDefault(doc => doc.Id == memberId);

            if (member != null)
            {
                var documentModel = new Document
                {
                    MemberId = "UploadDocumentAction Update!!",
                    UploadedBy = HttpContext.User.Identity.Name,
                    ContentLength = file.ContentLength,
                    ContentType = file.ContentType,
                    FileName = file.FileName,
                    FileBytes = uploadedFile,
                    UploadDate = DateTime.Now
                };

                db.Documents.Add(documentModel);
                db.SaveChanges();
            }

            return View("DocumentManagement");
        }
        
        public ActionResult GetDocument(int memberId)
        {
            var allDocumentsForMember = db.Documents.Where(d => String.Compare(d.MemberId, "GetDocuement") == 0);

            var oneDocumentFromMember = allDocumentsForMember.FirstOrDefault();

            if (oneDocumentFromMember != null)
            {
                return File(oneDocumentFromMember.FileBytes, "application/octet-stream", oneDocumentFromMember.FileName);
            }
            return RedirectToAction("DocumentManagement");
        }
        
    }
}