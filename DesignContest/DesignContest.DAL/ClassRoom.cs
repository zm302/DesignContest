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
    public class ClassRoom : IDALBase<T_ClassRoom>
    {
        private SmartLaboratoryContext DbContext = new SmartLaboratoryContext();
        public string Delete(T_ClassRoom entity)
        {
            try
            {
                DbContext.T_ClassRoom.Remove(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch (Exception exc)
            {
                return SystemVar.Failure;
            }
        }

        public string Insert(T_ClassRoom entity)
        {
            try
            {
                DbContext.T_ClassRoom.Add(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch (Exception exc)
            {
                return SystemVar.Failure;
            }
        }

        public T_ClassRoom Select(T_ClassRoom entity)
        {
            T_ClassRoom Retentity = null;
            try
            {
                var temp = from classroom in DbContext.T_ClassRoom
                           where (classroom.F_ClassRoomID == entity.F_ClassRoomID)
                           
                           select classroom;
                
                Retentity = temp.FirstOrDefault();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }
        public IEnumerable<T_ClassRoom> SelectPart(T_ClassRoom entity)
        {
            IEnumerable<T_ClassRoom> Retentity = null;
            try
            {
                var temp = from classroom in DbContext.T_ClassRoom
                           where (string.IsNullOrEmpty(entity.F_ClassRoomID) || classroom.F_ClassRoomID.Contains(entity.F_ClassRoomID))
                           && (string.IsNullOrEmpty(entity.F_ClassRoomName) || classroom.F_ClassRoomName.Contains(entity.F_ClassRoomName))
                           select classroom;

                Retentity = temp.ToArray();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }
        public IEnumerable<T_ClassRoom> SelectAll()
        {
            IEnumerable<T_ClassRoom> Retentity = null;
            try
            {
                var temp = from classroom in DbContext.T_ClassRoom
                           select classroom;
                Retentity = temp.ToArray();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }

        public string Update(T_ClassRoom entity)
        {

            try
            {
                DbEntityEntry<T_ClassRoom> entry = DbContext.Entry<T_ClassRoom>(entity);
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
