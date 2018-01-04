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
    public class StaffRecord : IDALBase<T_StaffRecord>
    {
        private SmartLaboratoryContext DbContext = new SmartLaboratoryContext();
        public string Delete(T_StaffRecord entity)
        {
            try
            {
                DbContext.T_StaffRecord.Remove(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch (Exception exc)
            {
                //把错误信息写入日志
                return SystemVar.Failure;
            }
        }

        public string Insert(T_StaffRecord entity)
        {
            try
            {
                DbContext.T_StaffRecord.Add(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch
            {
                return SystemVar.Failure;
            }
        }

        public T_StaffRecord Select(T_StaffRecord entity)
        {
            T_StaffRecord Retentity = null;
            try
            {
                var temp = from staffrecord in DbContext.T_StaffRecord
                           where staffrecord.F_staffRecordID == entity.F_staffRecordID
                           select staffrecord;
                Retentity = temp.FirstOrDefault();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }

        public IEnumerable<T_StaffRecord> SelectAll()
        {
            IEnumerable<T_StaffRecord> Retentity = null;
            try
            {
                var temp = from staffrecords in DbContext.T_StaffRecord
                           select staffrecords;
                Retentity = temp.ToArray<T_StaffRecord>();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }

        public string Update(T_StaffRecord entity)
        {
            try
            {
                DbEntityEntry<T_StaffRecord> entry = DbContext.Entry<T_StaffRecord>(entity);
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
