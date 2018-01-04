using DesignContest.Common.Log;
using DesignContest.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignContest.BLL
{
    public class StaffSign
    {

        private DAL.StaffSign dalStaffSign = new DAL.StaffSign();

        public string Add(T_StaffSign entity)
        {
            try
            {
                return dalStaffSign.Insert(entity);
            }
            catch(Exception exc)
            {
                LogHelper.log.Fatal(GetType().ToString()+"Exception:"+exc.Message);
                return Common.SystemVar.SystemVar.Exception;
            }
        }

        public IEnumerable<T_StaffSign> GetList(out string message)
        {
            try
            {
                message = Common.SystemVar.SystemVar.Success;
                return dalStaffSign.SelectAll();
            }
            catch
            {
                message = Common.SystemVar.SystemVar.Exception;
                return null;
            }
        }

    }
}
