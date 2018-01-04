using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_Devices
    {
        public string F_DeviceID { get; set; }
        public string F_DeviceTypeID { get; set; }
        public string F_DeviceName { get; set; }
        public string F_DeviceLocationID { get; set; }
        public string F_DeviceDescription { get; set; }
        public bool F_IsDelete { get; set; }
        public string F_DeviceStatus { get; set; }
        public string F_DeviceStatusCode { get; set; }
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
