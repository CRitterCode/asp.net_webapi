using Domain.Entities.Reservation;
using Domain.Entities.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Buisness : EntityBase
    {
        public User UserId { get; set; }
        public ICollection<ServiceSetting> Services { get; set; }
        public ICollection<TimeTable> TimeTables { get; set; }
    }
}
