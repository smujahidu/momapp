using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOMApplication.POCOS;
using MOMApplication.Repository;
using MOMApplication.Model;


namespace MOMApplication.Services
{
    public class AdminService
    {
        #region Properties
        AdminRepository repos = null;
        #endregion

        #region Constructor
        public AdminService()
        {
            repos = new AdminRepository();
        }
        #endregion

        #region Methods

        public bool SaveUser(UserInfo user)
        {
            tblUserInfo userData = ConvertUserData(user);
            return repos.SaveUser(userData);
        }

        private tblUserInfo ConvertUserData(UserInfo userData)
        {
            tblUserInfo user = new tblUserInfo();
            //user.UserID = userData.UserID;
            user.UserName = userData.UserName;
            user.Password = userData.Password;
            user.Email = userData.Email;
            user.ProjectID = userData.ProjectID;
            user.RoleID = userData.RoleID;
            return user;
        }

        public bool SaveProject(ProjectInfo proj)
        {
            tblProjectInfo projData = ConvertProjectData(proj);
            return repos.SaveProject(projData);
        }

        private tblProjectInfo ConvertProjectData(ProjectInfo projData)
        {
            tblProjectInfo proj = new tblProjectInfo();
            proj.ProjectName = projData.ProjectName;
            proj.StartDate = projData.StartDate;
            proj.Status = projData.Status;
            return proj;
        }

        public List<RolePOCO> GetRole()
        {
            List<RolePOCO> roleList = ConvertRole(repos.GetRole());
            return roleList;
        }

        private List<RolePOCO> ConvertRole(List<tblRole> list)
        {
            List<RolePOCO> roleList = new List<RolePOCO>();
            foreach (var item in list)
            {
                RolePOCO role = new RolePOCO();
                role.RoleID = item.RoleID;
                role.RoleName = item.RoleName;
                roleList.Add(role);
            }
            return roleList;
        }
        #endregion
    }
}
