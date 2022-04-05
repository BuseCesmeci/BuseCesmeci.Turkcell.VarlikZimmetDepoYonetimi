using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.Core.Models;

namespace VarlikZimmetDepoYonetimi.Core.IRepositories
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SoftDelete(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<T> GetByIdAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> condition = null);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> condition = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        
    }
}
