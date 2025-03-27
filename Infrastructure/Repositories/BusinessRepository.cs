using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BusinessRepository(ReservationDbContext context) : RepositoryGuidBase<Business>(context)
    {
    }
}
