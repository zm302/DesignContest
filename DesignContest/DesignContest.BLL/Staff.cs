using DesignContest.Common.Log;
using DesignContest.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignContest.BLL
{
    public class Staff
    {

        private DAL.Staff dalStaff = new DAL.Staff();

        
        public string Add(T_Staff entity)
        {
            try
            {
                return dalStaff.Insert(entity);  
            }
            catch(Exception exc)
            {
                LogHelper.log.Fatal("类："+this.GetType().ToString()+"，方法：Add发生异常，异常信息为："+exc.Message);
                return Common.SystemVar.SystemVar.Exception;
            }
        }



        public T_Staff Get(T_Staff entity,out string message)
        {
            try
            {
                message = Common.SystemVar.SystemVar.Success;
                return dalStaff.Select(entity);
            }
            catch(Exception exc)
            {
                message = Common.SystemVar.SystemVar.Exception;
                return null;

            }
        }

        public IEnumerable<T_Staff> GetList(out string message)
        {
            try
            {
                message = Common.SystemVar.SystemVar.Success;
                return dalStaff.SelectAll();
            }
            catch(Exception exc)
            {
                message = Common.SystemVar.SystemVar.Exception;
                return null;
            }
        }
        public List<T_Staff> getAllStaffInfo()
        {
            List<T_Staff> staff = new List<T_Staff>();
            staff = dalStaff.SelectAll().ToList();
            return staff;
        }
        public string[] getStaffInfo(string T_StaffID)
        {
            string[] info = new string[10];
            T_Staff staff = new T_Staff();
            staff.F_staffID = T_StaffID;
            staff = dalStaff.Select(staff);
            info[0] = staff.F_staffName;
            info[1] = staff.F_sex;
            info[2] = staff.F_age.ToString();
            info[3] = staff.F_phone;
            return info;
        }
        public void addStaff(string[] info)
        {
            T_Staff staff = new T_Staff();
            staff.F_staffID = info[0];
            staff.F_staffName = info[1];
            staff.F_sex = info[2];

            staff.F_age = 0;
            staff.F_phone = info[4];
            staff.F_startWorkTime = DateTime.Now;
            staff.F_address = info[5];
            string message = dalStaff.Insert(staff);
        }
    }
}
