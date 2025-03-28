using Application.Exceptions;
using Application.Guard;
using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Reservation;
using Infrastructure.Interfaces;


namespace Application.Services
{
    public class BusinessService(IRepositoryGuidBase<Business> _businessRepository, IRepositoryBase<TimeTable> _timeTableRepository) : ServiceBase<Business>(_businessRepository), IBusinessService
    {
        public async Task AddTimeTableAsync(ICollection<TimeTable> timeTables)
        {
            var business = await GuardService.CheckIfGuidIsValid(_businessRepository, timeTables.First().Business.Guid);
   
            if (!timeTables.All(tt => tt.BusinessId == business.Id))
            {
                throw new ServiceException("Guid missmatch");
            }

            var timeTablesgroupedAndSorted = timeTables
                                    .GroupBy(g => g.DayOfWeek)
                                    .OrderBy(g => g.Key)
                                    .Select(group => new
                                    {
                                        DayOfWeek = group.Key,
                                        TimeTable = group.OrderBy(t => t.OpeningTime)
                                    });

            foreach (var tt in timeTablesgroupedAndSorted)
            {
                if (!tt.TimeTable.All(t => t.IsValidWeekday))
                {
                    throw new ServiceException("Wrong weekday provided.");
                }

                if (!tt.TimeTable.All(t => t.IsValidDayTimeCycle))
                {
                    throw new ServiceException($"Wrong daycycle provided for {tt.DayOfWeek}");
                }

                if (tt.TimeTable.Zip(tt.TimeTable.Skip(1), (current, next) => new { Current = current, Next = next })
                                    .Any(pair => pair.Current.ClosingTime > pair.Next.OpeningTime))
                {
                    throw new ServiceException($"Overlapping closing and opening times for {tt.DayOfWeek}");
                }
            }
            await _timeTableRepository.AddManyAsync(timeTables);

        }

 

    }
}
