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
        Task<T> GetById(int id);
        Task<int> Add(T entity);
        Task<int> Delete(T entity);
        Task<int> DeleteMany(ICollection<T> entity);

        Task<int> Update(T entity);
    }
}
