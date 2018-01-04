using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_UserRole
    {
        public string F_GUID { get; set; }
        public string F_RoleID { get; set; }
        public string F_UserID { get; set; }
        public string F_LastModifier { get; set; }
        public Nullable<System.DateTime> F_LastModifyDate { get; set; }
    }
}
