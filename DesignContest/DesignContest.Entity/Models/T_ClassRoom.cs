using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_ClassRoom
    {
        public string F_ClassRoomID { get; set; }
        public string F_ClassRoomName { get; set; }
        public string F_ClassTypeCode { get; set; }
        public string F_ClassFunction { get; set; }
        public bool F_IsDelete { get; set; }
        public string F_ClassRoomLocation { get; set; }
        public string F_ClassDescription { get; set; }
        public string F_ClassRoomRemark { get; set; }
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
