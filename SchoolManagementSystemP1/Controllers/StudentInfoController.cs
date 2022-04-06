using SchoolManagementSystemP1.adonetdatamodel;
using SchoolManagementSystemP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystemP1.Controllers
{
    public class StudentInfoController : Controller
    {
        SMSP1Entities db = new SMSP1Entities();
        // GET: StudentInfo
        public ActionResult Index()
        {
            List<StudentInfoVM> list = new List<StudentInfoVM>();
            var data = db.StudentInfoes.ToList();
            foreach (var item in data)
            {
                StudentInfoVM model = new StudentInfoVM()
                {
                    StudentName =item.FirstName+" " +item.MiddleName+" "+item.LastName,
                    Phone=item.Phone,
                    Email=item.Email,
                    PermannetAdd=item.Muncipality.MunicipalityName+" Ward No "+item.PWardNo + item.District.DistrictName+" "+item.Province.ProvinceName,
                     TempAdd= item.Muncipality1.MunicipalityName + " Ward No " + item.CWard + item.District1.DistrictName + " " + item.Province1.ProvinceName,
                     Id=item.Id,
                     
                    //Kathmandu Municipality ward No 1 Kathmandu Bagmati Pardesh

                };
                list.Add(model);
            }
            
            return View(list);
        }
        // Create: StudentInfo
        public ActionResult Create()
        {
            StudentInfoVM model = new StudentInfoVM();
            List<ParentDetailsVM> list = new List<ParentDetailsVM>();

            var parentList = db.ParentRelationships.ToList();
            foreach (var item in parentList)
            {
                ParentDetailsVM parent = new ParentDetailsVM();
                parent.RelatioshipId = item.RelationshipId;
                list.Add(parent);
            }
            model.ParentList = list;

            List<EducationalInfo> edulist = new List<EducationalInfo>();
            var educationlist = db.StudentLevels.ToList();
            foreach (var item in educationlist)
            {
                EducationalInfo model1 = new EducationalInfo();
                model1.Id = item.Id;
                edulist.Add(model1);
            }
            model.EducationList = edulist;

           

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(StudentInfoVM model)
         {
            try
            {
                StudentInfo student = new StudentInfo()
                {
                    CDistrictId = model.CDistrictId,
                    CMunicipalityID = model.CMunicipalityID,
                    CProvinceId = model.CProvinceId,
                    //CreatedBy=HttpContext.Cu
                    CreatedDate = DateTime.Now,
                    CWard = model.CWard,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    PDistrictId = model.PDistrictId,
                    PMunicipalityId = model.PMunicipalityId,
                    PProviceId = model.PProviceId,
                    Phone = model.Phone,
                    PWardNo = model.PWardNo,
                    Status = model.Status,
                    UpdatedDate = DateTime.Now

                };
                db.StudentInfoes.Add(student);
                
                foreach (var item in model.ParentList)
                {
                    ParentDetail parent = new ParentDetail()
                    {
                        ParentName = item.ParentName,
                        ParentPhone = item.ParentPhone,
                        Relationship = item.RelatioshipId,
                        StudentId = student.Id,
                    };
                    db.ParentDetails.Add(parent);
                     
                }
                foreach (var item in model.EducationList)
                {
                    EducationInfo edu = new EducationInfo()
                    {
                        BoardName = item.University,
                        CollegeName = item.College,
                        PassedYear = item.PassedYear,
                        Grade = item.Grade,
                        Status = true,
                        StudentId = student.Id,
                        LevelId = item.LevelId,
                    };
                    db.EducationInfoes.Add(edu);
                }
                var result = db.SaveChanges();
                if (result >= 5)
                {
                    ViewBag.SuccessMessage = "Successfully Saved.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.FailureMessage = "Failed while saving in database.";
                    return View(model);
                }
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
                return View(model);
            }
            //return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.StudentInfoes.Find(id);
            List<ParentDetailsVM> list = new List<ParentDetailsVM>();
            foreach (var item in data.ParentDetails)
            {
                ParentDetailsVM parent = new ParentDetailsVM()
                {
                    ParentId=item.ParentId,
                    ParentName=item.ParentName,
                    ParentPhone=item.ParentPhone,
                    RelatioshipId=item.Relationship
                };
                list.Add(parent);
            }
            List<EducationalInfo> listEdu = new List<EducationalInfo>();
            foreach (var item in data.EducationInfoes)
            {
                EducationalInfo edu = new EducationalInfo()
                {
                    University = item.BoardName,
                    College = item.CollegeName,
                    Grade = item.Grade,
                    LevelId = item.LevelId??0,
                    Level =item.MajorSubject,
                    PassedYear=item.PassedYear,
                };
                listEdu.Add(edu);
            }

            StudentInfoVM model = new StudentInfoVM()
            {
                CDistrictId = data.CDistrictId,
                CMunicipalityID = data.CMunicipalityID,
                CProvinceId = data.CProvinceId,
                CreatedDate = data.CreatedDate,
                CWard = data.CWard,
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName,
                MiddleName = data.MiddleName,
                PDistrictId = data.PDistrictId,
                Phone = data.Phone,
                PProviceId = data.PProviceId,
                PMunicipalityId = data.PMunicipalityId,
                PWardNo = data.PWardNo,
                ParentList = list,
                EducationList=listEdu,
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(StudentInfoVM model)
        {
            var studentdata = db.StudentInfoes.Find(model.Id);
            studentdata.FirstName = model.FirstName;
            studentdata.LastName = model.LastName;
            studentdata.MiddleName = model.MiddleName;
            studentdata.PDistrictId = model.PDistrictId;
            studentdata.PProviceId = model.PProviceId;
            studentdata.PMunicipalityId = model.PMunicipalityId;
            studentdata.CProvinceId = model.CProvinceId;
            studentdata.CDistrictId = model.CDistrictId;
            studentdata.CMunicipalityID = model.CMunicipalityID;
            studentdata.PWardNo = model.PWardNo;
            studentdata.CWard = model.CWard;
            studentdata.Phone = model.Phone;
            studentdata.Email = model.Email;
            studentdata.UpdatedDate = DateTime.Now;

            var parentdetails = db.ParentDetails.Where(x => x.StudentId == model.Id).ToList();
            db.ParentDetails.RemoveRange(parentdetails);
            foreach (var item in model.ParentList)
            {
                ParentDetail parent = new ParentDetail()
                {
                    ParentName = item.ParentName,
                    ParentPhone = item.ParentPhone,
                    Relationship = item.RelatioshipId,
                    StudentId = model.Id,
                };
                db.ParentDetails.Add(parent);

            }
            var EduDetails = db.EducationInfoes.Where(x => x.StudentId == model.Id);
            db.EducationInfoes.RemoveRange(EduDetails);
            List<EducationalInfo> listEdu = new List<EducationalInfo>();
            foreach (var item in model.EducationList)
            {
                EducationInfo edu = new EducationInfo()
                {
                    BoardName = item.University,
                    CollegeName = item.College,
                    PassedYear = item.PassedYear,
                    Grade = item.Grade,
                    Status = true,
                    StudentId = model.Id,
                    LevelId = item.LevelId,
                };
                db.EducationInfoes.Add(edu);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}