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
    public class ProvinceController : Controller
    {
        SMSP1Entities db = new SMSP1Entities();
        private readonly IProvinceProvider _provinceProvider;
        public ProvinceController()
        {
            this._provinceProvider = new ProvinceProvider();
        }
        // GET: Province
        [HttpGet]
        public ActionResult ListProvince()
        {
            var list=_provinceProvider.GetAllProvince();
            //List<Province> data = db.Provinces.ToList();
            //List<ProvinceVM> list = new List<ProvinceVM>();
            //foreach (var item in data)
            //{
            //    ProvinceVM model = new ProvinceVM();
            //    model.ProvinceID = item.ProvinceId;
            //    model.ProvinceName = item.ProvinceName;
            //    list.Add(model);
            //}
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProvinceVM model)
        {
            //Db table class
            Province data = new Province();
            //mapping view model to model 
            data.ProvinceName = model.ProvinceName;
            data.Status = model.Status;
            //data.ProvinceId = model.ProvinceID;
            //Adding model data into Local Entities
            db.Provinces.Add(data);
            //Permanent Changes into database
            var result = db.SaveChanges();
            return View();
        }
        //Index=>data list
        //Create(HttpGet)=> Render Form
        //Create(HttpPost)
        public ActionResult Edit(int Id)
        {
            ProvinceVM model = new ProvinceVM();
            Province obj = db.Provinces.Find(Id);
            model.ProvinceID = obj.ProvinceId;
            model.ProvinceName = obj.ProvinceName;
            model.Status = obj.Status??false;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProvinceVM model)
        {
            Province obj = db.Provinces.Find(model.ProvinceID);
            obj.ProvinceName = model.ProvinceName;
            obj.Status = model.Status;
            var result = db.SaveChanges();
            return View();
        }

        //[HttpPost]
        public ActionResult Delete(int Id)
        {
            Province obj = db.Provinces.Find(Id);
            db.Provinces.Remove(obj);
            var result = db.SaveChanges();
            return RedirectToAction("ListProvince");
        }


    }
}