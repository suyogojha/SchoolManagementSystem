using SchoolManagementSystemP1.adonetdatamodel;
using SchoolManagementSystemP1.Models;
using SchoolManagementSystemP1.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystemP1.Controllers
{
    public class DistrictController : Controller
    {
        SMSP1Entities db = new SMSP1Entities();
        IDistrictProvider _district;
        // GET: District
        public ActionResult Index()//returns list of data
        {
            List<DistrictVM> listobj = new List<DistrictVM>();
            //List<District> list = db.Districts.ToList();
            //foreach (var item in list)
            //{
            //    DistrictVM model = new DistrictVM();
            //    model.DistrictId = item.DistrictId;
            //    model.DistrictName = item.DistrictName;
            //    model.ProvinceId = item.ProvinceId;
            //    model.Status = item.Status??false;
            //    model.ProvinceName = item.Province.ProvinceName;
            //    listobj.Add(model);
            //}
            _district = new DistrictProvider();
            listobj = _district.GetAllDistrict();
            return View(listobj);
        }
        // GET: District
        public ActionResult Create()//generates form
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DistrictVM model)
        {
            // Target table District
            //District obj = new District();
            //obj.DistrictId = model.DistrictId;
            //obj.DistrictName = model.DistrictName;
            //obj.ProvinceId = model.ProvinceId;
            //obj.Status = model.Status;
            //db.Districts.Add(obj);
            //db.SaveChanges();
            var result = _district.Create(model);
            return RedirectToAction("Index");
        }
        //Get: Edit District
        public ActionResult Edit(int Id)
        {
            DistrictVM model = new DistrictVM();
            var data = db.Districts.Find(Id);
            model.DistrictId = data.DistrictId;
            model.DistrictName = data.DistrictName;
            model.ProvinceId = data.ProvinceId;
            model.Status = data.Status??false;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(DistrictVM model)
        {
            District data =db.Districts.Find(model.DistrictId);
            data.ProvinceId = model.ProvinceId;
            data.DistrictName = model.DistrictName;
            data.Status = model.Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            District data = db.Districts.Find(Id);
            db.Districts.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}