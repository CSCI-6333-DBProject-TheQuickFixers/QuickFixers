using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Net.Mail;
using QuickFixers.Data.Models;

namespace QuickFixers.Models
{
    /// <summary>
    /// Holds the values to register/login a new user.
    /// Fields hold validation, required, maxLength, etc as .NET properties.
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        [StringLength(255)]
        [EmailAddress()]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength:255, ErrorMessage ="Valid Password Required")]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        [IntegerValidator(MinValue = 0 , MaxValue = 999999999) ]
        public int ZipCode { get; set; }

        [IntegerValidator(MinValue=1, MaxValue = 2)]
        public int UserTypeID { get; set; }
        
        /// <summary>
        /// This populates are user types to a drop down. 
        /// </summary>
        public List<UserType> UserTypesSelect
        {
            get
            {
                return UserType.GetUserTypeIDs();
            }                
        }

        [DefaultValue(0.0)]
        public decimal PreferredDistance { get; set; }
    }
}