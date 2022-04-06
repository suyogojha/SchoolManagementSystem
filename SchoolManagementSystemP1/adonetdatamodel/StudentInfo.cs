//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManagementSystemP1.adonetdatamodel
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentInfo()
        {
            this.EducationInfoes = new HashSet<EducationInfo>();
            this.ParentDetails = new HashSet<ParentDetail>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<int> PProviceId { get; set; }
        public Nullable<int> PDistrictId { get; set; }
        public Nullable<int> PMunicipalityId { get; set; }
        public Nullable<int> PWardNo { get; set; }
        public Nullable<int> CProvinceId { get; set; }
        public Nullable<int> CDistrictId { get; set; }
        public Nullable<int> CMunicipalityID { get; set; }
        public Nullable<int> CWard { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<bool> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationInfo> EducationInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ParentDetail> ParentDetails { get; set; }
        public virtual Province Province { get; set; }
        public virtual Province Province1 { get; set; }
        public virtual District District { get; set; }
        public virtual District District1 { get; set; }
        public virtual Muncipality Muncipality { get; set; }
        public virtual Muncipality Muncipality1 { get; set; }
    }
}
