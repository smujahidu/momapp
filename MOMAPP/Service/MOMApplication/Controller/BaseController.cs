using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace MOMApplication.Controllers
{
    public class BaseController : ApiController
    {
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
