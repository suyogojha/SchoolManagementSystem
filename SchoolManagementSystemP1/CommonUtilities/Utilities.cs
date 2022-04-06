using SchoolManagementSystemP1.adonetdatamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystemP1.CommonUtilities
{
    public static class Utilities
    {
       
        public static List<SelectListItem> GetProvinceList()
        {
            using (SMSP1Entities db = new SMSP1Entities())
            {

                List<SelectListItem> list = new List<SelectListItem>();
                var data = db.Provinces.ToList();
                foreach (var item in data)
                {
                    SelectListItem itemdata = new SelectListItem() { Text = item.ProvinceName, Value = item.ProvinceId.ToString() };
                    list.Add(itemdata);
                }
                return list;
            }
        }
        public static List<SelectListItem> GetDistrictList()
        {
            using (SMSP1Entities db = new SMSP1Entities())
            {
                List<SelectListItem> list = new List<SelectListItem>();
                var data = db.Districts.ToList();
                foreach (var item in data)
                {
                    SelectListItem itemdata = new SelectListItem() { Text = item.DistrictName, Value = item.DistrictId.ToString() };
                    list.Add(itemdata);
                }
                return list;
            }
        }
        public static IEnumerable<SelectListItem> GetDistrictListNewMethod()
        {
            using (SMSP1Entities db = new SMSP1Entities())
            {
                SelectList list = new SelectList(db.Districts.ToList(), "DistrictId", "DistrictName");
                return list;
            }
        }
        public static IEnumerable<SelectListItem> GetMunicipalityList()
        {
            using (SMSP1Entities db = new SMSP1Entities())
            {
                SelectList list = new SelectList(db.Muncipalities.ToList(), "MunicipalityId", "MunicipalityName");
                return list;
            }
        }
        public static IEnumerable<SelectListItem> GetParentRelationshipList()
        {
            using (SMSP1Entities db = new SMSP1Entities())
            {
                SelectList list = new SelectList(db.ParentRelationships.ToList(), "RelationshipId", "RelationshipName");
                return list;
            }
        }
        public static IEnumerable<SelectListItem> GetEducationLevelList()
        {
            using (SMSP1Entities db = new SMSP1Entities())
            {
                SelectList list = new SelectList(db.StudentLevels.ToList(), "Id", "LevelDescription");
                return list;
            }
        }
        


    }
}