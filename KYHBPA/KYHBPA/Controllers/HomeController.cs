using KYHBPA.Models;
using reCAPTCHA.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

    
        [HttpPost]
        [CaptchaValidator(
           PrivateKey = "6LetNjMUAAAAAD59qvyXAymsz6rL7gaJeha99xwb",
           ErrorMessage = "Invalid input captcha.",
           RequiredMessage = "The captcha field is required.")]
        public ActionResult Contact(Contact viewModel)
        {

            var IsDebug = false;

#if DEBUG
            IsDebug = true;
#endif

            var toEmail = "equus.web.solutions@gmail.com";
            var toEmailPassword = "!23Password";

            //Debug SMTP Settings
            var debugSmtpClient = new SmtpClient();
            debugSmtpClient.Host = "smtp.gmail.com";
            debugSmtpClient.Port = 587;
            debugSmtpClient.EnableSsl = true;
            //Setup credentials to login to our sender email address("UserName", "Password")
            NetworkCredential credentials = new NetworkCredential(toEmail, toEmailPassword);
            debugSmtpClient.UseDefaultCredentials = false;
            debugSmtpClient.Credentials = credentials;

            //Release SMTP Settings
            var releaseSmtpClient = new SmtpClient();
            releaseSmtpClient.EnableSsl = false;
            releaseSmtpClient.Host = "relay-hosting.secureserver.net";
            releaseSmtpClient.Port = 25;


            if (ModelState.IsValid || (ModelState.IsValid == false && IsDebug))
            {
                string Body = viewModel.Note;

                MailMessage mail = new MailMessage();
                mail.To.Add(toEmail);
                mail.From = new MailAddress(viewModel.Email);
                mail.Subject = "Contact Form Submission";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
#if DEBUG
                smtp = debugSmtpClient;
#else
                smtp = releaseSmtpClient;
#endif
                try
                {
                    smtp.Send(mail);
                }
                catch (SmtpException)
                {
                    return View("EmailError");
                }
                return View("Index");
            }
            else
            {
                return View("Index", viewModel);
            }
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
                    MemberId = member.Id,
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
            var allDocumentsForMember = db.Documents.Where(d => d.MemberId == memberId);

            var oneDocumentFromMember = allDocumentsForMember.FirstOrDefault();

            if (oneDocumentFromMember != null)
            {
                return File(oneDocumentFromMember.FileBytes, "application/octet-stream", oneDocumentFromMember.FileName);
            }
            return RedirectToAction("DocumentManagement");
        }
        
    }
}