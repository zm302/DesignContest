using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_Role
    {
        public string F_RoleID { get; set; }
        public string F_RoleName { get; set; }
        public string F_Description { get; set; }
        public Nullable<bool> F_IsDelete { get; set; }
        public string F_Text01 { get; set; }
        public string F_Text02 { get; set; }
        public string F_Text03 { get; set; }
        public string F_Text04 { get; set; }
        public string F_Text05 { get; set; }
        public string F_LastModifier { get; set; }
        public Nullable<System.DateTime> F_LastModifyDate { get; set; }
    }
}
