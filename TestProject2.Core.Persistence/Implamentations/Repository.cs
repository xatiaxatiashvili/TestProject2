using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Core.Application.Interfaces.Repositories;
using TestProject2.Core.Domain.Basics;

namespace TestProject2.Infrastructure.Persistence.Implamentations
{
    internal abstract class Repository<TEntity> : IRepository<Guid, TEntity> where TEntity : BaseEntity
    {
        protected readonly DataContext _context;
        public DbSet<TEntity> entities { get; set; }
        public Repository(DataContext context)
        {
            _context = context;
            entities = _context.Set<TEntity>();
        }


        // create
        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return await _context.SaveChangesAsync();
        }
        public virtual async Task<TEntity> ReadAsync(Guid id)
        {
            return await  _context.Set<TEntity>().FindAsync(id);
        }       
   
    public virtual async Task<int> UpdateAsync(Guid id, TEntity entity)
        {         
            var existing = entities.Find(id);
        _context.Entry(existing).CurrentValues.SetValues(entity);
            return await _context.SaveChangesAsync();
         }
        public virtual async Task<int> DeleteAsync(Guid id)
        {
            var item = await this.ReadAsync(id);
            _context.Set<TEntity>().Remove(item);
            return await _context.SaveChangesAsync();
        }

    }
}
