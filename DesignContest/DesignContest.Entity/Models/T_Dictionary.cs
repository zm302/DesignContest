using System;
using System.Collections.Generic;

namespace DesignContest.Entity.Models
{
    public partial class T_Dictionary
    {
        public string F_GUID { get; set; }
        public string F_KEY { get; set; }
        public string F_VALUE { get; set; }
        public string F_SimpleValue { get; set; }
        public bool F_IsDelete { get; set; }
        public string F_Type { get; set; }
        public string F_Remark { get; set; }
        public string F_LastModifier { get; set; }
        public Nullable<System.DateTime> F_LastModityDate { get; set; }
    }
}
