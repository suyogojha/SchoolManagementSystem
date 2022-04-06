using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystemP1.Models
{
    public class ParentDetailsVM
    {
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public string ParentPhone { get; set; }
        public int RelatioshipId { get; set; }
        public string Relatioship { get; set; }
    }
}