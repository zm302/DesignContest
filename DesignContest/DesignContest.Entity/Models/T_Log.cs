using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_Log
    {
        public string F_LogID { get; set; }
        public string F_LogType { get; set; }
        public string F_LogTitle { get; set; }
        public string F_LogName { get; set; }
        public string F_LogContent { get; set; }
        public System.DateTime F_LogDate { get; set; }
        public string F_LogRemark { get; set; }
        public string F_Remark { get; set; }
        public string F_Text1 { get; set; }
        public string F_Text2 { get; set; }
        public string F_Text3 { get; set; }
        public string F_Text4 { get; set; }
        public string F_LastModifier { get; set; }
        public Nullable<System.DateTime> F_LastModifyDate { get; set; }
    }
}
