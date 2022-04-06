using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystemP1.Models
{
    public class EducationalInfo
    {
        public int Id { get; set; }
        public string College { get; set; }
        public string University { get; set; }
        public string Grade { get; set; }
        public string Level { get; set; }
        public string PassedYear { get; set; }
        public int LevelId { get; set; }
    }
}