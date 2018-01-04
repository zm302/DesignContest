using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_Sign
    {
        public string F_GUID { get; set; }
        public string F_UserID { get; set; }
        public System.DateTime F_SignTime { get; set; }
        public string F_SignType { get; set; }
        public string F_Remark { get; set; }
        public string F_Text1 { get; set; }
        public string F_Text2 { get; set; }
        public string F_Text3 { get; set; }
        public string F_Text4 { get; set; }
        public string F_Text5 { get; set; }
        public string F_LastModifier { get; set; }
        public Nullable<System.DateTime> F_LastModifyDate { get; set; }
    }
}
