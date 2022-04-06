using SchoolManagementSystemP1.adonetdatamodel;
using SchoolManagementSystemP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystemP1.Controllers
{
    public class MuncipalityController : Controller
    {
        SMSP1Entities db = new SMSP1Entities();
        // GET: Muncipality
        public ActionResult Index()
        {
            var data = db.Muncipalities.ToList();
            List<MuncipalityVM> list = new List<MuncipalityVM>();
            foreach (var item in data)
            {
                MuncipalityVM model = new MuncipalityVM();
                model.MunicipalityId = item.MunicipalityId;
                model.ProvinceId = item.ProvinceId;
                model.DistrictId = item.DistrictId;
                model.MuncipalityName = item.MunicipalityName;
                model.DistrictName = item.District.DistrictName;
                model.ProvinceName = item.Province.ProvinceName;
                model.Status = item.Status??false;
                list.Add(model);
            }
            return View(list);
        }
        
        //Create Municipality Method
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MuncipalityVM model)
        {
            Muncipality obj = new Muncipality();
            obj.MunicipalityId = model.MunicipalityId;
            obj.DistrictId = model.DistrictId;
            obj.ProvinceId = model.ProvinceId;
            obj.MunicipalityName = model.MuncipalityName;
            obj.Status = model.Status;
            db.Muncipalities.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var data = db.Muncipalities.Find(id);
            MuncipalityVM model = new MuncipalityVM()
            {
                DistrictId = data.DistrictId,
                MunicipalityId = data.MunicipalityId,
                ProvinceId = data.ProvinceId,
                MuncipalityName=data.MunicipalityName,
                Status = data.Status??false
            };
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(MuncipalityVM model)
        {
            Muncipality olddata = db.Muncipalities.Find(model.MunicipalityId);
            olddata.MunicipalityName = model.MuncipalityName;
            olddata.DistrictId = model.DistrictId;
            olddata.ProvinceId = model.ProvinceId;
            olddata.Status = model.Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var obj = db.Muncipalities.Find(id);
            db.Muncipalities.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}