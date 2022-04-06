using SchoolManagementSystemP1.adonetdatamodel;
using SchoolManagementSystemP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystemP1.Provider
{
    public interface IDistrictProvider
    {
        List<DistrictVM> GetAllDistrict();
        int Create(DistrictVM model);
    }
    public class DistrictProvider: IDistrictProvider
    {
        SMSP1Entities db = new SMSP1Entities();
        public List<DistrictVM> GetAllDistrict()
        {
            List<DistrictVM> listobj = new List<DistrictVM>();
            List<District> list = db.Districts.ToList();
            foreach (var item in list)
            {
                DistrictVM model = new DistrictVM();
                model.DistrictId = item.DistrictId;
                model.DistrictName = item.DistrictName;
                model.ProvinceId = item.ProvinceId;
                model.Status = item.Status ?? false;
                model.ProvinceName = item.Province.ProvinceName;
                listobj.Add(model);
            }
            return listobj;
        }
        public int Create(DistrictVM model)
        {
            District obj = new District();
            obj.DistrictId = model.DistrictId;
            obj.DistrictName = model.DistrictName;
            obj.ProvinceId = model.ProvinceId;
            obj.Status = model.Status;
            db.Districts.Add(obj);
            var result=db.SaveChanges();
            return result;
        }
    }
}