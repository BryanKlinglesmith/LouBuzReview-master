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

namespace LouBuzReview.Controllers
{
    public class WebUsersController : Controller
    {
        private LouBuzReviewContext db = new LouBuzReviewContext();

        // GET: WebUsers
        public ActionResult Index(string searchName, string sortOrder)
        {
            ViewBag.NameSortParmFN = sortOrder == "NameFN" ? "nameDescFN" : "NameFN";
            ViewBag.NameSortParmLN = sortOrder == "NameLN" ? "nameDescLN" : "NameLN";
            ViewBag.NameSortParmCity = sortOrder == "NameCity" ? "nameDescCity" : "NameCity";
            ViewBag.NameSortParmState = sortOrder == "NameState" ? "nameDescState" : "NameState";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "dateDesc" : "Date";

            var users = from u in db.WebUsers
                           select u;
            if(!String.IsNullOrEmpty(searchName))
            {
                users = users.Where(u =>
                    u.FirstName.ToLower().Contains(searchName.ToLower()) 
                    || 
                    u.LastName.ToLower().Contains(searchName.ToLower())
                    ||
                    u.City.ToLower().Contains(searchName.ToLower())); 
            }

            
            switch (sortOrder)
            {
                case "nameDescFN":
                    users = users.OrderByDescending(u => u.FirstName);
                    break;
                case "NameFN":
                    users = users.OrderBy(u => u.FirstName);
                    break;
                case "nameDescLN":
                    users = users.OrderByDescending(u => u.LastName);
                    break;
                case "NameLN":
                    users = users.OrderBy(u => u.LastName);
                    break;
                case "nameDescCity":
                    users = users.OrderByDescending(u => u.City);
                    break;
                case "nameCity":
                    users = users.OrderBy(u => u.City);
                    break;
                case "nameDescState":
                    users = users.OrderByDescending(u => u.State);
                    break;
                case "nameState":
                    users = users.OrderBy(u => u.State);
                    break;                
                default:
                    break;
            }
            return View(users.ToList());
        }

        // GET: WebUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebUser webUser = db.WebUsers.Find(id);
            if (webUser == null)
            {
                return HttpNotFound();
            }
            return View(webUser);
        }

        // GET: WebUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WebUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,City,State")] WebUser webUser)
        {
            if (ModelState.IsValid)
            {
                db.WebUsers.Add(webUser);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(webUser);
        }

        // GET: WebUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebUser webUser = db.WebUsers.Find(id);
            if (webUser == null)
            {
                return HttpNotFound();
            }
            return View(webUser);
        }

        // POST: WebUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,City,State")] WebUser webUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webUser);
        }

        // GET: WebUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebUser webUser = db.WebUsers.Find(id);
            if (webUser == null)
            {
                return HttpNotFound();
            }
            return View(webUser);
        }

        // POST: WebUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebUser webUser = db.WebUsers.Find(id);
            db.WebUsers.Remove(webUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TabView(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebUser webUser = db.WebUsers.Find(id);
            if (webUser == null)
            {
                return HttpNotFound();
            }
            return View(webUser);
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
