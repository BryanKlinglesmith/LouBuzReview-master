using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LouBuzReview.Models;

namespace LouBuzReview.Data
{
    public class LouBuzReviewContext : DbContext
    {
        //Constructor inherit from DbContext base 
        public LouBuzReviewContext() : base("LouBuzReviewContext.")
        { }
        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<Website> Websites { get; set; }
        public DbSet<WebsiteReview> WebsiteReviews { get; set; }

        //public System.Data.Entity.DbSet<LouBuzReview.ViewModels.AddAWebsiteReview> AddAWebsiteReviews { get; set; }
    }
}