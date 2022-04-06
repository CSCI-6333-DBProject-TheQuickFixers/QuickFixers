using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuickFixers.Models
{
    public class TestViewModel
    {
        public Boolean IsDBConnected { get; set; }
        public DataTable DbResults { get; set; }
    }
}