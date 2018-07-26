using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Linq;
using LouBuzReview.Data;
using LouBuzReview.ViewModels;
using LouBuzReview.Models;
using System.Net;

namespace LouBuzReview.Controllers
{
    public class HomeController : Controller
    {
        private LouBuzReviewContext db = new LouBuzReviewContext();
        public ActionResult Index()
        {
            //following query gets last added 3 review to display in the front page as the latest review
            var webReviews = db.WebsiteReviews.Include(r => r.WebUser).Include(r => r.Website).OrderByDescending(r => r.ID).Take(3);
            return View(webReviews.ToList());
        }

        /// <summary>
        /// AddAReview is related to adding business Reviews, reviewer information and business information
        /// </summary>
        /// <returns></returns>
        public ActionResult AddAReview()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAReview(AddAWebsiteReview viewModel)
        {
            WebUser webUser = new WebUser();
            webUser.FirstName = viewModel.WebUser.FirstName;
            webUser.LastName = viewModel.WebUser.LastName;
            webUser.City = viewModel.WebUser.City;
            webUser.State = viewModel.WebUser.State;

            Website website = new Website();
            website.Category = viewModel.Website.Category;
            website.WebsiteUrl = viewModel.Website.WebsiteUrl;
            website.WebsiteName = viewModel.Website.WebsiteName;

            WebsiteReview websiteReview = new WebsiteReview();
            websiteReview.Ratings = viewModel.WebsiteReview.Ratings;
            websiteReview.UserReview = viewModel.WebsiteReview.UserReview;
            websiteReview.CreatedDate = viewModel.WebsiteReview.CreatedDate;

            db.WebUsers.Add(webUser);
            db.Websites.Add(website);
            db.WebsiteReviews.Add(websiteReview);


            db.SaveChanges();
            TempData["Message"] = "Review was successfully added";
            return RedirectToAction("Index", "WebsiteReviews");
        }

    }
}