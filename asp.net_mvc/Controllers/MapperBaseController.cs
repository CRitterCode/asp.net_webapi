using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_mvc.Controllers
{
    public abstract class MapperBaseController(IMapper mapper) : ControllerBase
    {
        protected readonly IMapper _mapper = mapper;
    }
}
