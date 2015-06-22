using MOMApplication.Controllers;
using MOMApplication.POCOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using WebApplication5.POCO;
using WebApplication5.Services;


namespace WebApplication5.Controllers
{
    public class MomController : BaseController
    {

        MomService service = new MomService();


       
        [HttpPost]
        public IHttpActionResult Getproject()
        {
            try
            {
                return Ok<List<ProjectInfo>>(service.Getproject());
            }
           
            catch (Exception)
            {
                throw;
            }
        }



        [HttpPost]
        public IHttpActionResult Savemom(HttpRequestMessage request)
        {
            SaveMom response = BindModel<SaveMom>(request);
            return Ok<bool>(service.savemom(response));
        }


        [HttpPost]
        public IHttpActionResult Getlist(int id)
        {
            //Dictionary<string, int> deseralizedObject = BindModel<Dictionary<string,int>>(request);
            // int result = 0;
            //if (deseralizedObject != null)
            //    result = deseralizedObject["id"];

            return Ok<List<UserInfo>>(service.Getlist(id));

        }


        [HttpPost]
        public IHttpActionResult Getmom(HttpRequestMessage request)
        {
            Dictionary<string, DateTime> deseralizedObject = BindModel<Dictionary<string, DateTime>>(request);
            DateTime date = deseralizedObject["CreationDate"];
            return Ok<SaveMom>(service.histoty(date));

        }




      
        
    }
}
