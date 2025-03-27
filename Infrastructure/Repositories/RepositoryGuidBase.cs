using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Repositories
{
    public abstract class RepositoryGuidBase<T> : RepositoryBase<T>, IRepositoryGuidBase<T> where T : class, IEntityGuidBase
    {

        protected RepositoryGuidBase(ReservationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<T> GetByGuidAsync(Guid guid, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                var query = WithIncludes(includes);
                return await query.FirstOrDefaultAsync(e => e.Guid == guid);
            }
            catch (InvalidOperationException)
            {
                throw new DatabaseException("Navigation provided not valid.");
            }
        }
    }
}
