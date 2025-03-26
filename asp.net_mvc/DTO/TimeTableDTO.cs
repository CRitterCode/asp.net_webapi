
using Domain.Enums;

namespace asp.net_mvc.DTO
{
    public class TimeTableDTO
    {
        public uint BusinessId { get; set; }
        public Weekdays DayOfWeek { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
    }
}
