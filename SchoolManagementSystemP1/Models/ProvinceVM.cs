using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SchoolManagementSystemP1.Models
{
    public class ProvinceVM
    {
        public int ProvinceID { get; set; }
        [DisplayName("Province Name")]
        public string ProvinceName { get; set; }
        public bool Status { get; set; }
    }
}