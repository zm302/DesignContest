using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_DevicesFixRecord
    {
        public string F_FixID { get; set; }
        public string F_FixName { get; set; }
        public string F_FixerName { get; set; }
        public string F_FixerCode { get; set; }
        public string F_FixedStatusCode { get; set; }
        public string F_FixDeviceID { get; set; }
        public string F_FixReporter { get; set; }
        public string F_FixCause { get; set; }
        public string F_FixDetails { get; set; }
        public string F_FixMaterial { get; set; }
        public string F_FixImageURL { get; set; }
        public string F_FixedImageURL { get; set; }
        public decimal F_FixCost { get; set; }
        public string F_FixRemark { get; set; }
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
