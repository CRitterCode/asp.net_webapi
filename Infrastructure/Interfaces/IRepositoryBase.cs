using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {

        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(uint id);
        Task<int> AddAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> DeleteManyAsync(ICollection<T> entity);

        Task<int> UpdateAsync(T entity);
        Task<int> UpdateManyAsync(ICollection<T> entities);
        Task<int> AddManyAsync(ICollection<T> entities);
    }
}
