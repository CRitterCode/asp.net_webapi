using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Reservation;
using Domain.Enums;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BusinessService(IRepositoryBase<Business> repository, IRepositoryBase<TimeTable> _timeTableRepository) : ServiceBase<Business>(repository), IBusinessService
    {
        public async Task AddTimeTableAsync(ICollection<TimeTable> timeTables)
        {
                var businessId = timeTables.First().BusinessId;
                var business = await _currentRepo.GetByIdAsync(businessId) ?? throw new ServiceException("Error with referenced Business.");

                if (!timeTables.All(tt => tt.BusinessId == business.Id))
                {
                    throw new ServiceException("Id missmatch");
                }

                foreach (var timeTable in timeTables)
                {
                    if (!timeTable.IsValidWeekday)
                    {
                        throw new ServiceException("Wrong Weekday provided.");
                    }
                    if (!timeTable.IsValidDayTimeCycle)
                    {
                        throw new ServiceException("Opening time comes before closing time.");
                    }
                }
                await _timeTableRepository.AddManyAsync(timeTables);
            
        }


    }
}
