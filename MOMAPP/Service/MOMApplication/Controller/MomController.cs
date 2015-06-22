using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using webapplication;
using WebApplication5.POCO;
using WebApplication5.Services;


namespace WebApplication5.Controllers
{
    public class MomController : ApiController
    {

        MomService service = new MomService();


       
        [HttpPost]
        public IHttpActionResult Getproject()
        {
            try
            {
                return Ok<List<project>>(service.Getproject());
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
        public IHttpActionResult Getlist(HttpRequestMessage request)
        {
            Dictionary<string, int> deseralizedObject = BindModel<Dictionary<string,int>>(request);
            int result = 0;
            if (deseralizedObject != null)
                result = deseralizedObject["id"];
            return Ok<List<User>>(service.Getlist(result));

        }


        [HttpPost]
        public IHttpActionResult Getmom(HttpRequestMessage request)
        {
            Dictionary<string, DateTime> deseralizedObject = BindModel<Dictionary<string, DateTime>>(request);
            DateTime date = deseralizedObject["CreationDate"];
            return Ok<SaveMom>(service.histoty(date));

        }




        protected T BindModel<T>(HttpRequestMessage request, bool isJsonFormat = true)
        {
            try
            {
                ///Getting Json object from httprequest message       
                string content = request.Content.ReadAsStringAsync().Result;
                T serializedObject;

                if (isJsonFormat)
                {
                    ///Converting JSON object to actual model
                    serializedObject = new JavaScriptSerializer().Deserialize<T>(content);
                }
                else
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (TextReader reader = new StringReader(content))
                    {
                        serializedObject = (T)serializer.Deserialize(reader);
                    }
                }
                return serializedObject;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
