using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuickFixers.Models
{
    public class CreateSPSOModel
    {
        [Display(Name = "Service Provider ID")]
        public int SPId { get; set; }

        [Required(ErrorMessage = "ServiceTypeID is required.")]
        public int ServiceTypeID { get; set; }

        [Required(ErrorMessage = "Service Fee is required.")]
        public int ServiceFee { get; set; }

    }
}