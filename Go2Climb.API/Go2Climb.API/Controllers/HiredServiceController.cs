using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services;
using Go2Climb.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Go2Climb.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class HiredServiceController : ControllerBase
    {
        private IHiredServiceService _hiredServiceService;
        private IMapper _mapper;

        public HiredServiceController(IHiredServiceService hiredServiceService, IMapper mapper)
        {
            _hiredServiceService = hiredServiceService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<HiredServiceResource>> GetAllAsync()
        {
            var services = await _hiredServiceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<HiredService>, IEnumerable<HiredServiceResource>>(services);
            return resources;
        }
        
        [HttpGet("{id}")]
        public async Task<HiredServiceResource> GetByIdAsync(int id)
        {
            var service = await _hiredServiceService.FindById(id);
            var resources = _mapper.Map<HiredService, HiredServiceResource>(service.Resource);
            return resources;
        }
    }
}