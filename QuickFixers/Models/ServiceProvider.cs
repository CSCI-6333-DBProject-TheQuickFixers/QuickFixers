﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace QuickFixers.Models
{
    public class ServiceProvider
    {
        public Boolean IsDBConnected { get; set; }
        public DataTable DbResults { get; set; }
    }
}