using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Reservation
{
    [Table(nameof(Reservation))]
    public class Reservation : EntityBase
    {
        public uint BuisnessId { get; set; }
        public DateTimeOffset ReservationStart { get; set; }
        public DateTimeOffset ReservationEnd { get; set; }
        public uint ReservationCount { get; set; }

        //relation
        public Business Buisness { get; set; }
    }
}
