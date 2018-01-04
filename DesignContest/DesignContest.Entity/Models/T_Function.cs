using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_Function
    {
        public string F_FunctionID { get; set; }
        public string F_FunctionName { get; set; }
        public Nullable<bool> F_IsPage { get; set; }
        public Nullable<bool> F_IsMenu { get; set; }
        public Nullable<bool> F_IsButton { get; set; }
        public string F_ParentID { get; set; }
        public string F_PageUrl { get; set; }
        public Nullable<int> F_OrderNum { get; set; }
        public string F_DefaultUrl { get; set; }
        public Nullable<bool> F_IsVisible { get; set; }
        public Nullable<bool> F_IsDelete { get; set; }
        public string F_Icon { get; set; }
        public string F_ApplicationID { get; set; }
        public string F_LastModifier { get; set; }
        public Nullable<System.DateTime> F_LastModifyDate { get; set; }
    }
}
