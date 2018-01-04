using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_RoleFunction
    {
        public string F_GUID { get; set; }
        public string F_RoleID { get; set; }
        public string F_FunctionID { get; set; }
        public string F_LastModifier { get; set; }
        public Nullable<System.DateTime> F_LastModifyDate { get; set; }
    }
}
