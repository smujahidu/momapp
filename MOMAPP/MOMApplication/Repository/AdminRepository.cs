using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOMApplication.POCOS;
using MOMApplication.Model;

namespace MOMApplication.Repository
{
    public class AdminRepository
    {
        #region Properties
        MOMEntities mom = null;
        #endregion

        #region Constructor
        public AdminRepository()
        {
            mom = new MOMEntities();
        }
        #endregion

        #region Methods

        public bool SaveUser(tblUserInfo user)
        {
            mom.tblUserInfoes.Add(user);
            var result = mom.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool SaveProject(tblProjectInfo proj)
        {
            mom.tblProjectInfoes.Add(proj);
            var result = mom.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;
        }

        public List<tblRole> GetRole()
        {
            return mom.tblRoles.ToList();
        }
        #endregion
    }
}