﻿using KYHBPA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KYHBPA.Models.ViewModels;

namespace KYHBPA.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog
        public ActionResult Index()
        {
            return View("List", db.Posts.ToList());
        }

        // GET: Blog/Blog
        public ActionResult Blog()
        {
            return View(db.Posts.ToList());
        }

        // GET: Blog/Post
        public ActionResult Post(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = db.Posts.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            var comments = db.Comments.Where(c => c.PostId == post.Id).ToList();

            var viewModel = new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                ShortDescription = post.ShortDescription,
                Description = post.Description,
                Published = post.Published,
                Posted = post.Posted,
                Modified = post.Modified,
                PostType = post.PostType,
                Comments = comments,
                Comment = new Comment()
            };

            return View(viewModel);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Poll/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Posted = DateTime.Now;
                post.Modified = DateTime.Now;                
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Poll/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = db.Posts.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            var comments = db.Comments.Where(c => c.PostId == post.Id).ToList();

            post.Comments = comments;

            return View(post);
        }

        // POST: Poll/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Modified = DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Poll/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Poll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var post = db.Posts.Find(id);
            if (post != null)
            {
                var comments = db.Comments.Where(c => c.PostId == id).ToList();

                foreach (var comment in comments)
                {
                    db.Comments.Remove(comment);
                }

                db.Posts.Remove(post);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: Blog/DeleteComment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int? id)
        {
            var comment = db.Comments.Find(id);
            if (comment != null)
            {
                db.Comments.Remove(comment);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment()
        {
            return RedirectToAction("Index");
        }

        // POST: Blog/AddComment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Route("blog/addcomment/{id}/{comment}")]
        public ActionResult AddComment(int? id, int s)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            //if (comment != null)
            //{
            //    comment.Posted = DateTime.Now;
            //    db.Comments.Add(comment);
            //    db.SaveChanges();
            //}

            return RedirectToAction("Post", id);
        }

    }
}