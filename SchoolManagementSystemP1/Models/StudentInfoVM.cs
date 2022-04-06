using SchoolManagementSystemP1.adonetdatamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystemP1.Models
{
    public class StudentInfoVM:StudentInfo
    {
        public string StudentName { get; set; }
        public string PermannetAdd { get; set; }
        public string TempAdd { get; set; }
        public List<ParentDetailsVM> ParentList { get; set; }
        public List<EducationalInfo> EducationList { get; set; }
    }
    
}