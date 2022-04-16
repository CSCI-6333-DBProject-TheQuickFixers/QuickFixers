﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Models
{
   public class Clients
    {
        public int ClientID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
    }
}
