using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_User
    {
        public string F_UserID { get; set; }
        public string F_UserName { get; set; }
        public string F_ShowName { get; set; }
        public string F_PassWord { get; set; }
        public string F_RoleID { get; set; }
        public Nullable<bool> F_Gender { get; set; }
        public Nullable<System.DateTime> F_Brithday { get; set; }
        public bool F_IsDelete { get; set; }
        public string F_HeadPictureURL { get; set; }
        public string F_Mobile { get; set; }
        public string F_Email { get; set; }
        public string F_Remark { get; set; }
        public Nullable<System.DateTime> F_LastLoginDatetime { get; set; }
        public string F_LastLoginIP { get; set; }
        public string F_Text1 { get; set; }
        public string F_Text2 { get; set; }
        public string F_Text3 { get; set; }
        public string F_Text4 { get; set; }
        public string F_Text5 { get; set; }
        public string F_LastModifier { get; set; }
        public Nullable<System.DateTime> F_ModfiyDate { get; set; }
    }
}
