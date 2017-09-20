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
            ViewBag.Message = "Your application description page.";

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
                    MemberId = member.Id,
                    UploadedBy = HttpContext.User.Identity.Name,
                    ContentLength = file.ContentLength,
                    ContentType = file.ContentType,
                    FileName = file.FileName,
                    FileBytes = uploadedFile
                };

                db.Documents.Add(documentModel);
                db.SaveChanges();
            }

            return View("DocumentManagement");
        }
        /*
        public ActionResult GetDocument(int studentId)
        {
            var allDocumentsForStudent = _db.Documents.Where(d => d.StudentId == studentId);

            var oneDocumentFromStudent = allDocumentsForStudent.FirstOrDefault();

            if (oneDocumentFromStudent != null)
            {
                return File(oneDocumentFromStudent.FileBytes, "application/octet-stream", oneDocumentFromStudent.FileName);
            }
            return RedirectToAction("DocumentManagement");
        }
        */
    }
}