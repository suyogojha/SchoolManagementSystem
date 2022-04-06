using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystemP1.Models
{
    public class MuncipalityVM
    {
        public int MunicipalityId { get; set; }
        public string MuncipalityName { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public bool Status { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
    }
}