using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Models;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;

namespace KYHBPA.Controllers
{
    public class EmailBlastController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmailBlast
        public ActionResult Index()
        {
            return View(db.EmailBlasts.ToList());
        }

        // GET: EmailBlast/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailBlast emailBlast = db.EmailBlasts.Find(id);
            if (emailBlast == null)
            {
                return HttpNotFound();
            }
            return View(emailBlast);
        }

        // GET: EmailBlast/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailBlast/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmailBlast emailBlast, HttpPostedFileBase file)
        {
            var IsDebug = false;

#if DEBUG
            IsDebug = true;
#endif

            var fromEmail = "equus.web.solutions@gmail.com";
            var fromEmailPassword = "!23Password";

            //Setup credentials to login to our sender email address("UserName", "Password")
            NetworkCredential credentials = new NetworkCredential(fromEmail, fromEmailPassword);

            //Debug SMTP Settings
            var debugSmtpClient = new SmtpClient();
            debugSmtpClient.Host = "smtp.gmail.com";
            debugSmtpClient.Port = 587;
            debugSmtpClient.EnableSsl = true;
            debugSmtpClient.UseDefaultCredentials = false;
            debugSmtpClient.Credentials = credentials;

            //Release SMTP Settings
            var releaseSmtpClient = new SmtpClient();            
            releaseSmtpClient.Host = "relay-hosting.secureserver.net";
            releaseSmtpClient.Port = 25;
            releaseSmtpClient.EnableSsl = false;

            if (ModelState.IsValid)
            {

                var emails = db.Members.Select(e => e.Email).ToList();

                var toEmails = String.Join(", ", emails);

                emailBlast.To = toEmails;
                emailBlast.From = fromEmail;

                db.EmailBlasts.Add(emailBlast);
                db.SaveChanges();

                MailMessage mail = new MailMessage();
                mail.To.Add(toEmails);
                mail.From = new MailAddress(fromEmail);
                mail.Subject = emailBlast.Subject;
                mail.Body = emailBlast.Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();

                //from class
                //var image = db.Documents.FirstOrDefault();

                byte[] uploadedFile = new byte[file.InputStream.Length];
                file.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

                Attachment attachment = new Attachment(new MemoryStream(uploadedFile), file.FileName);

                mail.Attachments.Add(attachment);

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
                    return RedirectToAction("ErrorPage", "Contact");
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ErrorPage", "Contact");
            }
        }



        // GET: EmailBlast/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailBlast emailBlast = db.EmailBlasts.Find(id);
            if (emailBlast == null)
            {
                return HttpNotFound();
            }
            return View(emailBlast);
        }

        // POST: EmailBlast/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,To,From,Subject,Body")] EmailBlast emailBlast)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailBlast).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emailBlast);
        }

        // GET: EmailBlast/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailBlast emailBlast = db.EmailBlasts.Find(id);
            if (emailBlast == null)
            {
                return HttpNotFound();
            }
            return View(emailBlast);
        }

        // POST: EmailBlast/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailBlast emailBlast = db.EmailBlasts.Find(id);
            db.EmailBlasts.Remove(emailBlast);
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
