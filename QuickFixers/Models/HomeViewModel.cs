using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace QuickFixers.Models
{
    /// <summary>
    /// Model used directly with the view. 
    /// Here we set what's required/length/etc for input fields.
    /// Database calls are only directly with QuickFixers.Data.
    /// </summary>
    public class HomeViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}