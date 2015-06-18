using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MOMApplication.POCOS;
using MOMApplication.Model;

namespace MOMApplication.Repository
{
    public class LoginRepository
    {
        #region Properties
        MOMEntities mom = null;
        #endregion

        #region Constructor
        public LoginRepository()
        {
            mom = new MOMEntities();
        }
        #endregion

        #region Methods

        public tblUserInfo Login(UserInfo user)
        {
            tblUserInfo userData = mom.tblUserInfoes.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
            return userData;
        }

        #endregion
    }
}