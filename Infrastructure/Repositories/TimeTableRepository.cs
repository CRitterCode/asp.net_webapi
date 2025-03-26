﻿using Domain.Entities.Reservation;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TimeTableRepository(ReservationDbContext context) : RepositoryBase<TimeTable>(context)
    {
    }
}
