using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapplication;
using WebApplication5.POCO;
using WebApplication5.Repositories;



namespace WebApplication5.Services
{
    public class MomService : MomRepository
    {

        MomRepository repository = new MomRepository();

        public List<project> Getproject()
        {
            List<project> poco = new List<project>();
           //List<tblProjectInfo> dbmodel = repository.Getproject();
           var dbmodel = repository.Getproject();
            foreach (var item in dbmodel)
            {
                project pomodel = new project();
                pomodel.ProjectID=item.ProjectID;
                pomodel.ProjectName = item.ProjectName;
                poco.Add(pomodel);
            }

            return poco;
      
        }

        public bool savemom(SaveMom mom)
        {
            tblMom model = new tblMom();
           model= converttomom(mom);
           return repository.savemom(model);
        }

        public tblMom converttomom(SaveMom momform)
        {
            tblMom dbmodel = new tblMom();
            dbmodel.Subject = momform.Subject;
            dbmodel.Description = momform.Description;
            return dbmodel;
           
        }


        public List<User> Getlist(int id)
        {
            List<User> poco = new List<User>();
           
                List<tblUserInfo> dbmodel1 = repository.GetList(id);
            foreach (var item in dbmodel1)
            {
                User pocomodel = new User();
                pocomodel.UserName = item.UserName;
                poco.Add(pocomodel);
            }
            return poco;
        }


        public SaveMom histoty(DateTime date)
        {
            SaveMom poco = new SaveMom();
            tblMom dbmodel = repository.Getmom(date);
            poco.Subject = dbmodel.Subject;
            poco.Description = dbmodel.Description;
            return poco;
        }


    }
}