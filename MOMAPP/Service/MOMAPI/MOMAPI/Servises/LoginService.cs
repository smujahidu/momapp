using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOMAPI.POCOS;
using MOMAPI.Repositry;
using MOMAPI.Models;

namespace MOMAPI.Servises
{
    public class LoginService
    {
        #region Properties
        LoginRepository repo = null;
        #endregion

        #region Constructor
        public LoginService()
        {
            repo = new LoginRepository();
        }
        #endregion

        #region Methods

        public UserInfo Login(UserInfo user)
        {
            UserInfo userInfo = new UserInfo();
            tblUserInfo userData = repo.Login(user);
            if (userData != null)
            {
                 userInfo = ConvertUserData(userData);
            }
            return userInfo;
        }

        private UserInfo ConvertUserData(tblUserInfo userData)
        {
            UserInfo user = new UserInfo();
            user.UserID = userData.UserID;
            user.UserName = userData.UserName;
            user.Password = userData.Password;
            user.Email = userData.Email;
            user.ProjectID = userData.ProjectID;
            user.RoleID = userData.RoleID;
            return user;
        }

        #endregion
    }
}