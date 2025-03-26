using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Reservation
{
    [Table(nameof(TimeTable))]
    public class TimeTable : EntityBase
    {
        public uint BusinessId { get; set; }
        public Weekdays DayOfWeek { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }

        //relation
        public Business Business { get; set; }


        //domain specific logic
        public bool IsOpeningTimeValid => IsTimeSpanWithinDaycycle(OpeningTime);

        public bool IsClosingTimeValid => IsTimeSpanWithinDaycycle(ClosingTime) && OpeningTime < ClosingTime;

        public bool IsValidDayTimeCycle => IsOpeningTimeValid && IsClosingTimeValid;
        public bool IsValidWeekday => !DayOfWeek.HasFlag(Weekdays.NotDefined);

        private bool IsTimeSpanWithinDaycycle(TimeSpan time) => time >= TimeSpan.Zero && time <= TimeSpan.FromHours(24);
    }
}
