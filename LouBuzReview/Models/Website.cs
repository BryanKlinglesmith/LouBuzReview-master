using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LouBuzReview.Models
{
    /// <summary>
    /// Keep enum out of class
    /// this took me two day to figure out
    /// </summary>
    public enum Category
    {
        [Display(Name = "Automobile Services")]
        AutomobileServices,
        Dealership,
        Education,
        Employers,
        Entertainment,
        [Display(Name = "Financial Services")]
        FinancialServices,
        Government,
        Health,
        [Display(Name = "Home Improvement")]
        HomeImprovement,
        Hotels,
        [Display(Name = "Non-Profit")]
        NonProfit,
        Restaurants,
        Retail,
        Sports,
        Travel
    }
    public class Website
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WebsiteID { get; set; }
        [Display(Name = "Business Category")]
        public Category? Category { get; set; }
        [Display(Name = "Business Url")]
        public string WebsiteUrl { get; set; }
        [Display(Name = "Business Name")]
        public string WebsiteName { get; set; }
        public virtual ICollection<WebsiteReview> WebsiteReview { get; set; }
    }
}