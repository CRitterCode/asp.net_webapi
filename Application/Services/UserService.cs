using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class UserService
    {
        private IRepositoryBase<User> _userRepository { get; set; }

        public UserService(IRepositoryBase<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IQueryable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
