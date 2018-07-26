using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LouBuzReview.Models;

namespace LouBuzReview.ViewModels
{
    public class AddAWebsiteReview
    {
        public WebsiteReview WebsiteReview { get; set; }
        public Website Website { get; set; }
        public WebUser WebUser { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Required]
        [Display(Name = "Business Category")]
        public Category? Category { get; set; }

        [Required]
        [Display(Name = "Website Url")]
        public string WebsiteUrl { get; set; }
        [Required]
        [Display(Name = "Website Name")]
        public string WebsiteName { get; set; }

        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "User Ratings")]
        public Ratings? Ratings { get; set; }

        [Required]
        [Display(Name = "User Review")]
        public string UserReview { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime CreatedDate { get; set; }
    }
}