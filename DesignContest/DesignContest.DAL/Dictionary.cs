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
    public class Dictionary : IDALBase<T_Dictionary>
    {
        private SmartLaboratoryContext DbContext = new SmartLaboratoryContext();
        public string Delete(T_Dictionary entity)
        {
            try
            {
                DbContext.T_Dictionary.Remove(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch (Exception exc)
            {
                //把错误信息写入日志
                return SystemVar.Failure;
            }
        }

        public string Insert(T_Dictionary entity)
        {
            try
            {
                DbContext.T_Dictionary.Add(entity);
                DbContext.SaveChanges();
                return SystemVar.Success;
            }
            catch
            {
                return SystemVar.Failure;
            }
        }

        public T_Dictionary Select(T_Dictionary entity)
        {
            T_Dictionary Retentity = null;
            try
            {
                if (entity.F_KEY != null)
                {
                    var temp = from dictionary in DbContext.T_Dictionary
                               where dictionary.F_KEY == entity.F_KEY
                               select dictionary;
                    Retentity = temp.FirstOrDefault();
                }
                else
                {
                    if (entity.F_VALUE != null)
                    {
                        var temp = from dictionary in DbContext.T_Dictionary
                                   where dictionary.F_VALUE == entity.F_VALUE
                                   select dictionary;
                        Retentity = temp.FirstOrDefault();
                    }
                }
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }

        }

        public IEnumerable<T_Dictionary> SelectAll()
        {
            IEnumerable<T_Dictionary> Retentity = null;
            try
            {
                var temp = from dictionary in DbContext.T_Dictionary
                           select dictionary;
                Retentity = temp.ToArray<T_Dictionary>();
                return Retentity;
            }
            catch (Exception exc)
            {
                return Retentity;
            }
        }

        public string Update(T_Dictionary entity)
        {
            try
            {
                DbEntityEntry<T_Dictionary> entry = DbContext.Entry<T_Dictionary>(entity);
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
