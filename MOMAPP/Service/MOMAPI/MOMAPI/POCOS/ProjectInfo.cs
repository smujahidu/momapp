using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOMAPI.POCOS
{
    public class ProjectInfo
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}