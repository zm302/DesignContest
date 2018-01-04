using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignContest.DAL
{
    public interface IDALBase<T>
    {
        string Insert(T entity);

        string Delete(T entity);

        string Update(T entity);

        T Select(T entity);

        IEnumerable<T> SelectAll();
    }
}
