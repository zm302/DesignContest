using DesignContest.Common.SystemVar;
using DesignContest.DAL;
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
    public class Staff : IDALBase<T_Staff>
    {
        private SmartLaboratoryContext DbContext = new SmartLaboratoryContext();
        public string Delete(T_Staff entity)
        {
            try
            {
                DbContext.T_Staff.Remove(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch (Exception exc)
            {
                return SystemVar.Failure;
            }
        }

        public string Insert(T_Staff entity)
        {
            try
            {
                DbContext.T_Staff.Add(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch (Exception exc)
            {
                return SystemVar.Failure;
            }
        }

        public T_Staff Select(T_Staff entity)
        {
            T_Staff Retentity = null;
            try
            {
                var temp = from staff in DbContext.T_Staff
                           where staff.F_staffID == entity.F_staffID
                           select staff;
                Retentity = temp.FirstOrDefault();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }

        public IEnumerable<T_Staff> SelectAll()
        {
            IEnumerable<T_Staff> Retentity = null;
            try
            {
                var temp = from staffs in DbContext.T_Staff
                           select staffs;
                Retentity = temp.ToArray<T_Staff>();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }

        public string Update(T_Staff entity)
        {
            try
            {
                DbEntityEntry<T_Staff> entry = DbContext.Entry<T_Staff>(entity);
                entry.State = EntityState.Modified;
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch (Exception exc)
            {
                return SystemVar.Failure;
            }
        }
    }
}
