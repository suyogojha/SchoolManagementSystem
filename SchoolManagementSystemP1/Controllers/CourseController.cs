using SchoolManagementSystemP1.adonetdatamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystemP1.Controllers
{
    public class CourseController : Controller
    {
        SMSP1Entities db = new SMSP1Entities();
        // GET: Course
        public ActionResult Index()
        {
            return View(db.CourseDetails.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CourseDetail model)
        {
            db.CourseDetails.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}