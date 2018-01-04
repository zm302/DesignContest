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
    
    public class Environment : IDALBase<T_Environment>
    {
        private SmartLaboratoryContext DbContext = new SmartLaboratoryContext();

        public string Delete(T_Environment entity)
        {
            try
            {
                DbContext.T_Environment.Remove(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch (Exception exc)
            {
                return SystemVar.Failure;
            }
        }

        public string Insert(T_Environment entity)
        {
            try
            {
                DbContext.T_Environment.Add(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch (Exception exc)
            {
                return SystemVar.Failure;
            }
        }

        public T_Environment Select(T_Environment entity)
        {
            T_Environment Retentity = null;
            try
            {
                var temp = from environment in DbContext.T_Environment
                           where (environment.F_SensorType == entity.F_SensorType)
                           select environment;

                Retentity = temp.FirstOrDefault();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }
        public IEnumerable<T_Environment> SelectPart(T_Environment entity)
        {
            IEnumerable<T_Environment> Retentity = null;
            try
            {
                var temp = from environment in DbContext.T_Environment
                           where (string.IsNullOrEmpty(entity.F_SensorID) || environment.F_SensorID.Contains(entity.F_SensorID))
                           && (string.IsNullOrEmpty(entity.F_SensorType) || environment.F_SensorType.Contains(entity.F_SensorType))
                           && (string.IsNullOrEmpty(entity.F_ClassRoomID) || environment.F_ClassRoomID == entity.F_ClassRoomID)
                           && (environment.F_DataDate.Year == DateTime.Now.Year) 
                           && (environment.F_DataDate.Month == DateTime.Now.Month)
                           && (environment.F_DataDate.Day == DateTime.Now.Day)
                           orderby environment.F_DataDate
                           select environment;

                Retentity = temp.ToArray();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }
        public IEnumerable<T_Environment> SelectAll()
        {
            IEnumerable<T_Environment> Retentity = null;
            try
            {
                var temp = from environment in DbContext.T_Environment
                           select environment;
                Retentity = temp.ToArray();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }

        public string Update(T_Environment entity)
        {
            try
            {
                DbEntityEntry<T_Environment> entry = DbContext.Entry<T_Environment>(entity);
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
