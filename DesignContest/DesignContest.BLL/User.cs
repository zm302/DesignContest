using DesignContest.Common.Log;
using DesignContest.Common.SystemVar;
using DesignContest.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignContest.BLL
{
    public class User
    {
        private DAL.User dalUser = new DAL.User();

        public string Login(string username, string password)
        {
            string message = SystemVar.Exception;
            try
            {
                T_User user = dalUser.Login(new T_User { F_UserName = username }, out message);
                if (user == null)
                {
                    if (message.Equals(SystemVar.Success))
                    {
                        return SystemVar.NoData;
                    }
                    else
                    {
                        return SystemVar.Exception;
                    }
                }
                else
                {
                    user = dalUser.Select(user);
                    if (user.F_PassWord.Equals(password))
                    {
                        return SystemVar.Success;
                    }
                    else
                    {
                        return SystemVar.Failure;
                    }
                }
            }
            catch (Exception exc)
            {
                LogHelper.log.Fatal("DAL层"+this.GetType().ToString()+ "Login方法异常，异常信息为："+exc.Message);//异常，致命错误
                return SystemVar.Failure;
            }
        }

    }
}
