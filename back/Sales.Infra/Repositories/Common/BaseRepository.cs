using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities.Common;
using Sales.Domain.Specification.Common;
using Sales.Infra.Context;

namespace Sales.Infra.Repositories.Common
{
    public abstract class BaseRepository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly DbContext _context;        
        protected BaseRepository(IConnection connection)
        {
            _context = connection.Context();
        }

        public Task AddAsync(T entity) => _context.Set<T>().AddAsync(entity);

        public void Update(T entity)
        {
            if (_context.ChangeTracker.Entries<T>().All(i => i.Entity.Id != entity.Id))
                _context.Entry(entity).State = EntityState.Modified;
            else
            {
                var alreadyTracked = _context.ChangeTracker.Entries<T>().FirstOrDefault(i => i.Entity.Id == entity.Id)
                    ?.Entity;
                if (alreadyTracked != null)
                    _context.Entry((object) alreadyTracked).CurrentValues.SetValues(entity);
            }
        }

        public void Delete(int id) => _context.Set<T>().Remove(_context.Set<T>().FirstOrDefault(x => x.Id ==id));

        public Task<T> GetAsync(int id) => _context.Set<T>().FirstOrDefaultAsync(i => i.Id == id);

        public Task<T> GetAsync(Specification<T> specification) => 
            _context.Set<T>().FirstOrDefaultAsync(specification.ToExpression());
        
        public Task<List<T>> GetAllAsync() => _context.Set<T>().AsNoTracking().ToListAsync();
        
        public IReadOnlyList<T> Find(Specification<T> specification) =>
            _context.Set<T>().Where(specification.ToExpression().Compile()).ToList();

        protected IQueryable<T> Query()
            => _context.Set<T>();

        
    }
}
