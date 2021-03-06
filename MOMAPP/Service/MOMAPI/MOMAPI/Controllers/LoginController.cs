﻿using System;
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
    public class LoginController : BaseController
    {
        #region Properties
        LoginService servi = null;
        #endregion

        #region Constructor
        public LoginController()
        {
            servi = new LoginService();
        }
        #endregion

        #region Methods
        [HttpPost]
        public IHttpActionResult Login(HttpRequestMessage request)
        {
            UserInfo user = BindModel<UserInfo>(request);
            return Ok<UserInfo>(servi.Login(user));
        }

        #endregion
        
    }
}
