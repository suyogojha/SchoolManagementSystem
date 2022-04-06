using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagementSystemP1.adonetdatamodel;
using SchoolManagementSystemP1.Models;

namespace SchoolManagementSystemP1.Controllers
{
    public class StudentInfoesController : Controller
    {
        private SMSP1Entities db = new SMSP1Entities();
        //Created database
        //Project Create
        // Added ado.net datamodel
        //Added controller

        // GET: StudentInfoes
        public ActionResult StudentList()
        {
            List<StudentInfo> list = db.StudentInfoes.ToList();
            return View(list);
        }

        public ActionResult ListInt()
        {
            List<int> intlist = new List<int>();
            intlist.Add(0);
            intlist.Add(1);
            intlist.Add(2);
            intlist.Add(3);
            intlist.Add(4);
            intlist.Add(5);
            intlist.Add(6);
            intlist.Add(7);
            intlist.Add(8);
            //To post data from controller to view
            //ViewData
            ViewData["intlist1"] = intlist;
            //ViewBag
            ViewBag.intlist = intlist;
            //Model
            return View(intlist);
        }
        public ActionResult ListProvince()
        {
            List<ProvinceVM> list = new List<ProvinceVM>();
            ProvinceVM obj1 = new ProvinceVM();
            obj1.ProvinceID = 1;
            obj1.ProvinceName = "Province One";
            list.Add(obj1);
            ProvinceVM obj2 = new ProvinceVM();
            obj2.ProvinceID = 2;
            obj2.ProvinceName = "Madhesh";
            list.Add(obj2);
            ProvinceVM obj3 = new ProvinceVM();
            obj3.ProvinceID = 3;
            obj3.ProvinceName = "Bagmati";

            return View(list);
        }

        public ActionResult Index()
        {
            var a = db.StudentInfoes.ToList();// linq query
            //select * from StudentInfo;
            return View();
        }
        
        // GET: StudentInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo studentInfo = db.StudentInfoes.Find(id);
            if (studentInfo == null)
            {
                return HttpNotFound();
            }
            return View(studentInfo);
        }

        // GET: StudentInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,Phone,Email,PProviceId,PDistrictId,PMunicipalityId,PWardNo,CProvinceId,CDistrictId,CMunicipalityID,CWard,CreatedBy,CreatedDate,UpdatedDate,UpdatedBy,Status")] StudentInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                db.StudentInfoes.Add(studentInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentInfo);
        }

        // GET: StudentInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo studentInfo = db.StudentInfoes.Find(id);
            if (studentInfo == null)
            {
                return HttpNotFound();
            }
            return View(studentInfo);
        }

        // POST: StudentInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,Phone,Email,PProviceId,PDistrictId,PMunicipalityId,PWardNo,CProvinceId,CDistrictId,CMunicipalityID,CWard,CreatedBy,CreatedDate,UpdatedDate,UpdatedBy,Status")] StudentInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentInfo);
        }

        // GET: StudentInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo studentInfo = db.StudentInfoes.Find(id);
            if (studentInfo == null)
            {
                return HttpNotFound();
            }
            return View(studentInfo);
        }

        // POST: StudentInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentInfo studentInfo = db.StudentInfoes.Find(id);
            db.StudentInfoes.Remove(studentInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
