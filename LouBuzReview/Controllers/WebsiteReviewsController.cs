using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LouBuzReview.Data;
using LouBuzReview.Models;
using LouBuzReview.ViewModels;

namespace LouBuzReview.Controllers
{
    public class WebsiteReviewsController : Controller
    {
        private LouBuzReviewContext db = new LouBuzReviewContext();

        // GET: WebsiteReviews
        public ActionResult Index(string searchName)
        {
            var websiteReviews = db.WebsiteReviews.Include(r => r.WebUser).Include(r => r.Website);

            if (!String.IsNullOrEmpty(searchName))
            {
                websiteReviews = websiteReviews.Where(w =>
                    w.WebUser.FirstName.ToLower().Contains(searchName.ToLower())
                    ||
                    w.WebUser.LastName.ToLower().Contains(searchName.ToLower())
                    ||
                    w.Website.WebsiteName.ToLower().Contains(searchName.ToLower()) 
                    ||
                    w.Ratings.ToString().ToLower().Contains(searchName.ToLower()));
            }
            return View(websiteReviews.ToList());
        }

        // GET: WebsiteReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var websiteReview = db.WebsiteReviews
                .Include(r => r.WebUser)
                .Include(r => r.Website)
                .Where(r => r.ID == id)
                .FirstOrDefault();

            if (websiteReview == null)
            {
                return HttpNotFound();
            }
            return View(websiteReview);
        }

        // GET: WebsiteReviews/Create
        public ActionResult Create()
        {
            ViewBag.WebsiteID = new SelectList(db.Websites, "WebsiteID", "WebsiteUrl");
            ViewBag.UserID = new SelectList(db.WebUsers, "UserID", "FirstName");
            return View();
        }

        // POST: WebsiteReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,WebsiteID,Ratings,UserReview,CreatedDate")] WebsiteReview websiteReview)
        {
            if (ModelState.IsValid)
            {
                db.WebsiteReviews.Add(websiteReview);
                db.SaveChanges();
                TempData["Message"] = "Review was successfully added";
                return RedirectToAction("Index");
            }

            ViewBag.WebsiteID = new SelectList(db.Websites, "WebsiteID", "WebsiteUrl", websiteReview.WebsiteID);
            ViewBag.UserID = new SelectList(db.WebUsers, "UserID", "FirstName", websiteReview.UserID);
            return View(websiteReview);
        }

        // GET: WebsiteReviews/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    WebsiteReview websiteReview = db.WebsiteReviews.Find(id);
        //    //var websiteReview = db.WebsiteReviews
        //    //    .Include(r => r.WebUser)
        //    //    .Include(r => r.Website)
        //    //    .Where(r => r.ID == id) //&& r.UserID == r.WebUser.UserID && r.WebsiteID == r.Website.WebsiteID
        //    //    .FirstOrDefault();
        //    if (websiteReview == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.City = websiteReview.WebUser.City;
        //    ViewBag.State = websiteReview.WebUser.State;
        //    ViewBag.WebsiteID = new SelectList(db.Websites, "WebsiteID", "WebsiteID", websiteReview.WebsiteID);
        //    ViewBag.UserID = new SelectList(db.WebUsers, "UserID", "UserID", websiteReview.UserID);
        //    return View(websiteReview);
        //}

        //// POST: WebsiteReviews/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        ////[Bind(Include = "ID,UserID,FirstName, LastName, City, State,WebsiteID, Category, WebsiteUrl, WebsiteName ,Ratings,UserReview,CreatedDate")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit( WebsiteReview websiteReview)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(websiteReview).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.WebsiteID = new SelectList(db.Websites, "WebsiteID", "WebsiteID", websiteReview.WebsiteID);
        //    ViewBag.UserID = new SelectList(db.WebUsers, "UserID", "UserID", websiteReview.UserID);
        //    return View(websiteReview);
        //}


        // GET: WebsiteReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebsiteReview websiteReview = db.WebsiteReviews.Find(id);
            if (websiteReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.WebsiteID = new SelectList(db.Websites, "WebsiteID", "WebsiteID", websiteReview.WebsiteID);
            ViewBag.UserID = new SelectList(db.WebUsers, "UserID", "UserID", websiteReview.UserID);
            return View(websiteReview);
        }

        // POST: WebsiteReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WebsiteReview websiteReview)
        {
            db.WebsiteReviews.Add(websiteReview);
            
            if (ModelState.IsValid)
            {                
                db.Entry(websiteReview).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Edited Review was successfully Saved";
                return RedirectToAction("Index");
            }            
            return View();
        }

        // GET: WebsiteReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebsiteReview websiteReview = db.WebsiteReviews.Find(id);
            if (websiteReview == null)
            {
                return HttpNotFound();
            }
            return View(websiteReview);
        }

        // POST: WebsiteReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebsiteReview websiteReview = db.WebsiteReviews.Find(id);
            db.WebsiteReviews.Remove(websiteReview);
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
