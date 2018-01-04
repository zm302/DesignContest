using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_Notice
    {
        public string F_GUID { get; set; }
        public string F_NoticeID { get; set; }
        public string F_NotiveType { get; set; }
        public string F_NoticeTitle { get; set; }
        public string F_NoticeText { get; set; }
        public string F_NoticeRemark { get; set; }
        public string F_NoticeCreater { get; set; }
        public System.DateTime F_NoticeDateTime { get; set; }
        public Nullable<System.DateTime> F_NoticeTermOfValidity { get; set; }
        public string F_NoticeCreaterIP { get; set; }
        public bool F_IsDelete { get; set; }
        public bool F_IsVisible { get; set; }
        public bool F_IsReviewed { get; set; }
        public string F_Reviewer { get; set; }
        public string F_NoticeState { get; set; }
        public bool F_IsAttached { get; set; }
        public string F_AttachUrl { get; set; }
        public Nullable<System.DateTime> F_AttachTermOfValidity { get; set; }
        public string F_Text1 { get; set; }
        public string F_Text2 { get; set; }
        public string F_Text3 { get; set; }
        public string F_Text4 { get; set; }
        public string F_Text5 { get; set; }
        public string F_LastModify { get; set; }
        public Nullable<System.DateTime> F_LastModifyDate { get; set; }
    }
}
