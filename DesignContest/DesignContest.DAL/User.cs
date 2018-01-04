
using DesignContest.Common.SystemVar;
using DesignContest.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignContest.DAL
{
    public class User : IDALBase<T_User>
    {
        private SmartLaboratoryContext DbContext = new SmartLaboratoryContext();
        public string Delete(T_User entity)
        {
            try
            {
                DbContext.T_User.Remove(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch(Exception exc)
            {
                //把错误信息写入日志
                return SystemVar.Failure;
            }
        }

        public string Insert(T_User entity)
        {
            try
            {
                DbContext.T_User.Add(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch
            {
                return SystemVar.Failure;
            }
        }

        public T_User Select(T_User entity)
        {
            T_User Retentity = null;
            try
            {
                var temp = from users in DbContext.T_User
                           where users.F_UserName == entity.F_UserName
                           select users;
                Retentity = temp.FirstOrDefault();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
            
        }
        
        public IEnumerable<T_User> SelectAll()
        {
            IEnumerable<T_User> Retentity = null;
            try
            {
                var temp = from users in DbContext.T_User
                           select users;
                Retentity = temp.ToArray<T_User>();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }

        public string Update(T_User entity)
        {
            try
            {
                DbEntityEntry<T_User> entry = DbContext.Entry<T_User>(entity);
                entry.State = EntityState.Modified;
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch (Exception exc)
            {
                //把错误信息写入日志
                return SystemVar.Failure;
            }
        }


        public T_User Login(T_User user, out string message)
        {
            T_User RetUser = null;
            try
            {
                var temp = from users in DbContext.T_User
                           where users.F_UserName == user.F_UserName
                           select users;

                RetUser = temp.FirstOrDefault();//有两种可能结果，null或有值
                foreach (T_User u in temp)
                {
                    RetUser = u;
                }
                message = SystemVar.Success;
                return RetUser;
            }
            catch (Exception exc)
            {
                message = SystemVar.Exception;
                return RetUser;
            }
        }
        
    }
}
