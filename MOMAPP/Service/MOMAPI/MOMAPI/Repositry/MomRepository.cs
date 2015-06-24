using MOMAPI.Models;
using MOMAPI.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOMAPI.Repositry
{

    public class MomRepository
    {


        MOMEntities db = new MOMEntities();

        //getting project
        public List<tblProjectInfo> Getproject()
        {
            try
            {
                List<tblProjectInfo> obj1 = new List<tblProjectInfo>();
                var list = db.tblProjectInfoes.ToList();
                foreach (var item in list)
                {
                    tblProjectInfo obj = new tblProjectInfo();
                    obj.ProjectID = item.ProjectID;
                    obj.ProjectName = item.ProjectName;
                    obj1.Add(obj);
                }
                return obj1;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }




        //save mom form
        public bool savemom(tblMom mom)
        {

            db.tblMoms.Add(mom);
            var result = db.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;
        }



        //getting list
        public List<tblUserInfo> GetList(int id)
        {

            List<tblUserInfo> obj1 = new List<tblUserInfo>();
            var list = db.tblUserInfoes.Where(a => a.ProjectID == id).ToList();
            foreach (var item in list)
            {
                tblUserInfo obj = new tblUserInfo();
                obj.UserName = item.UserName;
                obj1.Add(obj);
            }
            return obj1;
        }


        //getting mom

        public tblMom Getmom(SaveMom data)
        {

            //var history = db.tblMoms.Where(a => a.ProjectID.Equals(data.ProjectID) && a.CreationDate.Equals(data.CreationDate)).SingleOrDefault();
            var history = db.tblMoms.Where(a => a.ProjectID == data.ProjectID && a.CreationDate == data.CreationDate).SingleOrDefault();

            tblMom mom = new tblMom();

            mom.Subject = history.Subject;
            mom.Description = history.Description;

            return mom;

        }

    }
}