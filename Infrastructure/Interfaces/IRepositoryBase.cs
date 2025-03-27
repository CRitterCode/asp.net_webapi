using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IRepositoryBase<T> where T : class, IEntityBase
    {
        IQueryable<T> GetAll();
        Task<int> AddAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> DeleteManyAsync(ICollection<T> entity);

        Task<int> UpdateAsync(T entity);
        Task<int> UpdateManyAsync(ICollection<T> entities);
        Task<int> AddManyAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(uint id, params Expression<Func<T, object>>[] includes);
    }
}
