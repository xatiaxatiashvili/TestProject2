using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject2.Core.Domain.Basics;

namespace TestProject2.Core.Application.Interfaces.Repositories
{
    public interface IRepository<TKey, TEntity> where TEntity : BaseEntity
    {
        Task<int> CreateAsync(TEntity entity); 
        Task<TEntity> ReadAsync(TKey id);
        Task<int> UpdateAsync(TKey id, TEntity entity);
        Task<int> DeleteAsync(TKey id);
    }
}
