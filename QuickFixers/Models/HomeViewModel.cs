using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace QuickFixers.Models
{
    public class HomeViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}