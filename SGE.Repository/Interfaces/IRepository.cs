using SGE.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Filter(Func<T, bool> predicate);
    }
}
