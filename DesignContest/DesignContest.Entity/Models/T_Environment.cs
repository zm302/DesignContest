using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_Environment
    {
        public string F_GUID { get; set; }
        public string F_SensorID { get; set; }
        public string F_DataType { get; set; }
        public string F_SensorType { get; set; }
        public string F_DataValue { get; set; }
        public System.DateTime F_DataDate { get; set; }
        public string F_ClassRoomID { get; set; }
        public string F_DataRemark { get; set; }
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
