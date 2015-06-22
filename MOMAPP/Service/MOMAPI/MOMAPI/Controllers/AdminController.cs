using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MOMAPI.POCOS;
using MOMAPI.Servises;
using System.Xml.Serialization;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;

namespace MOMAPI.Controllers
{
    public class AdminController : BaseController
    {
         #region Properties
        AdminService servi = null;
        #endregion

        #region Constructor
        public AdminController()
        {
            servi = new AdminService();
        }
        #endregion

        #region Methods


        [HttpPost]
        public IHttpActionResult SaveUser(HttpRequestMessage request)
        {
            UserInfo user = BindModel<UserInfo>(request);
            return Ok<bool>(servi.SaveUser(user));
        } 


        [HttpPost]
        public IHttpActionResult SaveProject(HttpRequestMessage request)
        {
            ProjectInfo respose = BindModel<ProjectInfo>(request);
            return Ok<bool>(servi.SaveProject(respose));

        }

        [HttpPost]
        public IHttpActionResult GetRole()
        {
            return Ok<List<RolePOCO>>(servi.GetRole());
        }


        #endregion
    }
}
