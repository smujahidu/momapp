using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOMApplication.POCOS
{
    public class UserInfo
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<int> ProjectID { get; set; }
    }
}