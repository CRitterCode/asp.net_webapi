using asp.net_mvc.DTO;
using AutoMapper;
using Domain.Entities.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_mvc
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
 
            CreateMap<TimeTableDTO, TimeTable>();
                                                 
        }
    }
}
