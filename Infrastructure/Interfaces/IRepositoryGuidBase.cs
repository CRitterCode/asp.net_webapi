using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IRepositoryGuidBase<T> : IRepositoryBase<T> where T : class, IEntityGuidBase
    {
        Task<T> GetByGuidAsync(Guid guid, params Expression<Func<T, object>>[] includes);
    }
}
