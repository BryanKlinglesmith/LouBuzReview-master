using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LouBuzReview.Models
{
    public enum Ratings
    {
        [Display(Name = "1 Star")]
        OneStar = 1,
        [Display(Name = "2 Stars")]
        TwoStars = 2,
        [Display(Name = "3 Stars")]
        ThreeStars = 3,
        [Display(Name = "4 Stars")]
        FourStars = 4,
        [Display(Name = "5 Stars")]
        FiveStars = 5
    }
    public class WebsiteReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "User ID")]
        public int UserID { get; set; }
        [Display(Name = "Website ID")]
        public int WebsiteID { get; set; }
        [Display(Name = "User Ratings")]
        public Ratings? Ratings { get; set; }
        [Display(Name = "User Review")]
        public string UserReview { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime CreatedDate { get; set; }

        public virtual WebUser WebUser { get; set; }
        public virtual Website Website { get; set; }

        //See following article how to set Navigation properties
        //https://msdn.microsoft.com/en-us/library/jj713564(v=vs.113).aspx
    }
}