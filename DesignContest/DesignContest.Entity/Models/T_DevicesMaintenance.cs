using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_DevicesMaintenance
    {
        public string F_GUID { get; set; }
        public string F_DeviceID { get; set; }
        public string F_MaintenanceType { get; set; }
        public string F_MaintenanceDetail { get; set; }
        public System.DateTime F_MaintenanceDate { get; set; }
        public string F_Maintenancer { get; set; }
        public string F_MaintenanceRemark { get; set; }
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
