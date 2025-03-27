using Domain.Entities.Reservation;
using Domain.Entities.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table(nameof(Business))]
    public class Business : EntityGuidBase
    {
        public uint UserId { get; set; }
        public string TimeZone { get; set; } = string.Empty;

        //relation
        public User User { get; set; }
        public ICollection<ServiceSetting> Services { get; set; } = [];
        public ICollection<TimeTable> TimeTables { get; set; } = [];
    }
}
