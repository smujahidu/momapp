﻿ using MOMAPI.Models;
using MOMAPI.POCOS;
using MOMAPI.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;



namespace MOMAPI.Servises
{
    public class MomService
    {

        MomRepository repository = new MomRepository();

        public List<ProjectInfo> Getproject()
        {
            List<ProjectInfo> poco = new List<ProjectInfo>();
            //List<tblProjectInfo> dbmodel = repository.Getproject();
            var dbmodel = repository.Getproject();
            foreach (var item in dbmodel)
            {
                ProjectInfo pomodel = new ProjectInfo();
                pomodel.ProjectID = item.ProjectID;
                pomodel.ProjectName = item.ProjectName;
                poco.Add(pomodel);
            }

            return poco;

        }

        public bool savemom(SaveMom mom)
        {
            tblMom model = new tblMom();
            model = converttomom(mom);
            return repository.savemom(model);
        }

        public tblMom converttomom(SaveMom momform)
        {
            tblMom dbmodel = new tblMom();
            dbmodel.ProjectID = momform.ProjectID;
            dbmodel.Subject = momform.Subject;
            dbmodel.Description = momform.Description;
            dbmodel.CreationDate = momform.CreationDate;
            return dbmodel;

        }


        public List<UserInfo> Getlist(int id)
        {
            List<UserInfo> poco = new List<UserInfo>();

            List<tblUserInfo> dbmodel1 = repository.GetList(id);
            foreach (var item in dbmodel1)
            {
                UserInfo pocomodel = new UserInfo();
                pocomodel.UserName = item.UserName;
                poco.Add(pocomodel);
            }
            return poco;
        }


        public SaveMom histoty(SaveMom getdata)
        {
            SaveMom poco = new SaveMom();
            tblMom dbmodel = repository.Getmom(getdata);
            poco.Subject = dbmodel.Subject;
            poco.Description = dbmodel.Description;
            return poco;



        }


      
        
    }
}
    
