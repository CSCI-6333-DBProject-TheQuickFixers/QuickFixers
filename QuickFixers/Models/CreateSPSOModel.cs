using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QuickFixers.Models
{
    public class CreateSPSOModel
    {
        [Display(Name = "Service Provider ID")]
        public int SPId { get; set; }

        [Required(ErrorMessage = "ServiceTypeID is required.")]
        public int ServiceTypeID { get; set; }

        [Required(ErrorMessage = "Service Fee is required.")] 
        [DataType(DataType.Currency)]
        public decimal ServiceFee { get; set; }

        public IEnumerable<SelectListItem> ServiceList
        {
            get
            {
                var list = new List<SelectListItem>();

                // placeholder
                list.Add(new SelectListItem { Text = "Choose a Service", Value = "0", Disabled = true });

                list.Add(new SelectListItem { Text = "Carpenter", Value = "1" });
                list.Add(new SelectListItem { Text = "Electrician", Value = "2" });
                list.Add(new SelectListItem { Text = "Plumbing", Value = "3" });
                list.Add(new SelectListItem { Text = "Mason", Value = "4" });
                list.Add(new SelectListItem { Text = "Painter", Value = "5" });
                list.Add(new SelectListItem { Text = "Mechanic", Value = "6" });
                list.Add(new SelectListItem { Text = "AC Repairs", Value = "7" });
                list.Add(new SelectListItem { Text = "Landscaping", Value = "8" });
                list.Add(new SelectListItem { Text = "Roofing", Value = "9" });
                list.Add(new SelectListItem { Text = "Catering", Value = "10" });
                list.Add(new SelectListItem { Text = "Home Interior", Value = "11" });

                return list;
            }
        }


    }
}