using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QuickFixers.Models
{
    public class CreateSPWSModel
    {
        [Display(Name = "Service Provider ID")]
        public int SPId { get; set; }

        [Required(ErrorMessage = "Day of the Week is required.")]
        public string WeekDay { get; set; }

        [Required(ErrorMessage = "Start Time is required.")]
        public string StartT { get; set; }

        [Required(ErrorMessage = "End Time is required.")]
        public string EndT { get; set; }

        [Required(ErrorMessage = "TimeZone is required")]
        public string TZ { get; set; }
    }
}