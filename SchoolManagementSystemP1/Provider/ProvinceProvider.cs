using SchoolManagementSystemP1.adonetdatamodel;
using SchoolManagementSystemP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystemP1.Provider
{
    
    public interface IProvinceProvider
    {
        IEnumerable<ProvinceVM> GetAllProvince();
    }
   
    public class ProvinceProvider:IProvinceProvider
    {
         SMSP1Entities db=new SMSP1Entities();
       
        public IEnumerable<ProvinceVM> GetAllProvince()
        {
            List<Province> data = db.Provinces.ToList();
            List<ProvinceVM> list = new List<ProvinceVM>();
            foreach (var item in data)
            {
                ProvinceVM model = new ProvinceVM();
                model.ProvinceID = item.ProvinceId;
                model.ProvinceName = item.ProvinceName;
                list.Add(model);
            }
            return list;
        }
    }

    
}