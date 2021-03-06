﻿using KYHBPA.Models;
using Microsoft.AspNet.Identity;
using reCAPTCHA.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Models.ViewModels;

namespace KYHBPA.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var topPolls = db.Polls.Where(p => DateTime.Compare(DateTime.Today, p.EndDate) <= 0).OrderByDescending(p => p.StartDate).Take(3).ToList();
            var topNews = db.News.OrderByDescending(n => n.Date).Take(5).ToList();

            foreach (var n in topNews)
            {
                var picture = db.Documents.FirstOrDefault(p => p.Id == n.PictureId);
                n.Picture = picture;
            }

            var home = new HomeViewModel
            {
                Polls = topPolls,
                News = topNews
            };

            return View(home);
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

            //Setup credentials to login to our sender email address("UserName", "Password")
            NetworkCredential credentials = new NetworkCredential(toEmail, toEmailPassword);

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
                string Body = viewModel.Note;

                db.Contacts.Add(viewModel);
                db.SaveChanges();

                MailMessage mail = new MailMessage();
                mail.To.Add(toEmail);
                mail.From = new MailAddress(toEmail);
                mail.Subject = "Contact Form Submission";
                mail.Body = Body + Environment.NewLine + viewModel.Email;
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
                    return RedirectToAction("ErrorPage", "Contact");
                }
                return RedirectToAction("Sucess", "Contact");
            }
            else
            {
                return RedirectToAction("ErrorPage", "Contact");
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

        public ActionResult JockeyProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadDocument(DocumentDiscriminator discriminator, HttpPostedFileBase file)
        {
            var userId = User.Identity.GetUserName();
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var username = User.Identity.GetUserName();
            var member = db.Members.FirstOrDefault(m => String.Compare(m.Email, username) == 0);

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
                Discriminator = discriminator
            };

            db.Documents.Add(documentModel);
            db.SaveChanges();

            return View("DocumentManagement");
        }
        
        public ActionResult GetDocument(int memberId)
        {
            var allDocumentsForMember = db.Documents.Where(d => d.MemberId == 1);

            var oneDocumentFromMember = allDocumentsForMember.FirstOrDefault();

            if (oneDocumentFromMember != null)
            {
                return File(oneDocumentFromMember.FileBytes, "application/octet-stream", oneDocumentFromMember.FileName);
            }
            return RedirectToAction("DocumentManagement");
        }
        
    }
}