using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class UserService(IRepositoryBase<User> repo) : ServiceBase<User>(repo), IUserService
    {
        public IQueryable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
