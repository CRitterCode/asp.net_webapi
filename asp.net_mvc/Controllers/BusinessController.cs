using Application.Exceptions;
using Application.Interfaces;
using asp.net_mvc.DTO;
using AutoMapper;
using Domain.Entities.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_mvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController(IBusinessService buisnessService, IMapper mapper) : MapperBaseController(mapper)
    {
        public IBusinessService BusinessService { get; set; } = buisnessService;

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTimeTable(ICollection<TimeTableDTO> timeTables)
        {
            try
            {
                var mappedTimeTables = _mapper.Map<ICollection<TimeTable>>(timeTables);
                await BusinessService.AddTimeTableAsync(mappedTimeTables);
                return Ok();
            }
            catch (BusinessServiceException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
