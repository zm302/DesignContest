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
    public class StaffSign : IDALBase<T_StaffSign>
    {
        private SmartLaboratoryContext DbContext = new SmartLaboratoryContext();
        public string Delete(T_StaffSign entity)
        {
            try
            {
                DbContext.T_StaffSign.Remove(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch (Exception exc)
            {
                //把错误信息写入日志
                return SystemVar.Failure;
            }
        }

        public string Insert(T_StaffSign entity)
        {
            try
            {
                DbContext.T_StaffSign.Add(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch(Exception exc)
            {
                return SystemVar.Failure;
            }
        }

        public T_StaffSign Select(T_StaffSign entity)
        {
            T_StaffSign Retentity = null;
            try
            {
                var temp = from staffsign in DbContext.T_StaffSign
                           where staffsign.F_StaffID == entity.F_StaffID
                           select staffsign;
                Retentity = temp.FirstOrDefault();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }

        public IEnumerable<T_StaffSign> SelectAll()
        {
            IEnumerable<T_StaffSign> Retentity = null;
            try
            {
                var temp = from staffsigns in DbContext.T_StaffSign
                           orderby staffsigns.F_SignTime descending
                           select staffsigns;
                Retentity = temp.ToArray<T_StaffSign>();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }

        public string Update(T_StaffSign entity)
        {
            try
            {
                DbEntityEntry<T_StaffSign> entry = DbContext.Entry<T_StaffSign>(entity);
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
    }
}
