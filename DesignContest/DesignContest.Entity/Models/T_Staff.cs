using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_Staff
    {
        public string F_staffID { get; set; }
        public string F_staffName { get; set; }
        public string F_sex { get; set; }
        public Nullable<int> F_age { get; set; }
        public string F_phone { get; set; }
        public Nullable<System.DateTime> F_startWorkTime { get; set; }
        public string F_address { get; set; }
    }
}
