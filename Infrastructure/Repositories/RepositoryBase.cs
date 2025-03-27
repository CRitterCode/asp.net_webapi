using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase<T>(ReservationDbContext context) : IRepositoryBase<T> where T : class, IEntityBase
    {
        protected ReservationDbContext _context { get; set; } = context;

        public async Task<int> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddManyAsync(ICollection<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteManyAsync(ICollection<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
            return await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable<T>();
        }

        public async Task<T> GetByIdAsync(uint id, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                var query = WithIncludes(includes);
                return await query.FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new DatabaseException("Navigation provided not valid.");
            }
        }


        public async Task<int> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateManyAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Set<T>().Update(entity);
            }
            return await _context.SaveChangesAsync();
        }

        protected IQueryable<T> WithIncludes(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable<T>();
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }
            return query;

        }
    }
}
