using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_LoginCertificate
    {
        public string F_UserID { get; set; }
        public string F_Token { get; set; }
        public System.DateTime F_CreateTime { get; set; }
        public System.DateTime F_LastOperateTime { get; set; }
        public Nullable<System.DateTime> F_TokenExpiryDate { get; set; }
        public string F_Remark { get; set; }
        public string F_Text1 { get; set; }
        public string F_Text2 { get; set; }
        public string F_Text3 { get; set; }
        public string F_Text4 { get; set; }
        public string F_Text5 { get; set; }
        public string F_LastModifier { get; set; }
        public Nullable<System.DateTime> F_LastModifyTime { get; set; }
    }
}
