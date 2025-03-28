using Application.Exceptions;
using Domain;
using Domain.Interfaces;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guard
{
    public static class GuardService
    {
        public static T NotNull<T>(T value, string message) where T : class
        {
            return value ?? throw new ServiceException(message);
        }

        public static async Task<T> NotNullAsync<T>(Task<T> task, string message) where T : class
        {
            var value = await task;
            return NotNull(value, message);
        }

        public static async Task<T> CheckIfGuidIsValid<T>(IRepositoryGuidBase<T> repo, Guid guid) where T : class, IEntityGuidBase
        {
            return await NotNullAsync(repo.GetByGuidAsync(guid), "Couldn't find guid");
        }

        public static async Task<T> CheckIfIdIsValid<T>(IRepositoryBase<T> repo, uint id) where T : class, IEntityBase
        {
            return await NotNullAsync(repo.GetByIdAsync(id), "Couldn't find id");
        }

    }
}
