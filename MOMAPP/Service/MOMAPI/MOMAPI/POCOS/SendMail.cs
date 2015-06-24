using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOMAPI.POCOS
{
    public class SendMail
    {
        public Nullable<int> ProjectID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string MailTo { get; set; }
    }
}