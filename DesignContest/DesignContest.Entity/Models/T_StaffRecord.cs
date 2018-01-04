using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_StaffRecord
    {
        public int F_staffRecordID { get; set; }
        public string F_staffID { get; set; }
        public int F_signCount { get; set; }
        public string F_recordNote { get; set; }
    }
}
