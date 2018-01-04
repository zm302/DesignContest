using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_StaffSign
    {
        public int F_StaffSignID { get; set; }
        public string F_StaffID { get; set; }
        public string F_StaffName { get; set; }
        public System.DateTime F_SignTime { get; set; }
        public string F_ClassRoomID { get; set; }
        public string F_ClassRoomName { get; set; }
    }
}
