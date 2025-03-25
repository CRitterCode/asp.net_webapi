using Infrastructure.Context;
using Infrastructure.Interfaces;


namespace Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T :  class, new()
    {
        private ReservationDbContext _context { get; set; }

        public RepositoryBase(ReservationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteMany(ICollection<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
            return await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id) ?? new T();
        }

        public async Task<int> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
