using MOMApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace MOMApplication.Repository
{
    public class MomRepository 
    {
        MOMEntities db = new MOMEntities();

        //getting project
        public List<tblProjectInfo> GetProject()
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
        public bool SaveMom(tblMom mom)
        {
           
            db.tblMoms.Add(mom);
          var result= db.SaveChanges();
          if (result > 0)
              return true;
          else
              return false;
        }
       


        //getting list
        public List<tblUserInfo> GetList(int id)
        {

            List<tblUserInfo> obj1 = new List<tblUserInfo>();
            var list = db.tblUserInfoes.Where(a=>a.ProjectID==id).ToList();
            foreach (var item in list)
            {
                tblUserInfo obj = new tblUserInfo();
                obj.UserName = item.UserName;
                obj1.Add(obj);
            }
            return obj1;
        }


        //getting mom

        public tblMom GetMom(DateTime date)
        {

            var history = db.tblMoms.Where(a => a.CreationDate == date).FirstOrDefault();

            tblMom mom = new tblMom();

            mom.Subject = history.Subject;
            mom.Description = history.Description;

           return mom;

        }

    }
}