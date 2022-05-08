using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace QuickFixers.Models
{
    public class ServiceReviewModel
    {
        public DataTable Invoice { get; set; }

        public DataTable Payment { get; set; }

        public int ServiceProviderID{get;set;}

        [Required]
        [IntegerValidator(MinValue = 1, MaxValue = 5)]
        public int Rating { get; set; }

        [MaxLength(255)]
        public string BriefReview { get; set; }

    }
}