using Microsoft.EntityFrameworkCore;
using SGE.DataAccess.Entities;
using SGE.Repository.Context;
using SGE.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGE.Repository.Classes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SgeContext _context;
        private readonly DbSet<T> _entities;

        public Repository(SgeContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> Filter(Func<T, bool> predicate) => _entities.AsNoTracking().Where(predicate);

        public T Get(Guid id) => _entities.AsNoTracking().FirstOrDefault(prop => prop.Id.Equals(id));

        public IEnumerable<T> GetAll() => _entities.AsNoTracking();
    }
}
