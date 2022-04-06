using SchoolManagementSystemP1.adonetdatamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystemP1.Controllers
{
    public class ParentRelationshipController : Controller
    {
        SMSP1Entities db = new SMSP1Entities();
        // GET: ParentRelationship
        public ActionResult Index()
        {
            var data = db.ParentRelationships.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ParentRelationship model)
        {
            db.ParentRelationships.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.ParentRelationships.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(ParentRelationship model)
        {
            var data = db.ParentRelationships.Find(model.RelationshipId);
            data.RelationshipName = model.RelationshipName;
            data.Status = model.Status;
            return RedirectToAction("Index");
        }
    }
}