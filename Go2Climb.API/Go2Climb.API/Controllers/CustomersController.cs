using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services;
using Go2Climb.API.Extensions;
using Go2Climb.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Swashbuckle.AspNetCore.Annotations;

namespace Go2Climb.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All Customers",
            Description = "Get All The Customers From The Database.",
            Tags = new[] {"Customers"})]
        public async Task<IEnumerable<CustomerResource>> GetAllAsync()
        {
            var customers = await _customerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
            return resources;
        }
        
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get Customer By Id",
            Description = "Get A Customer From The Database Identified By Its Id.",
            Tags = new[] {"Customers"})]
        public async Task<CustomerResource> GetByIdAsync(int id)
        {
            var customer = await _customerService.FindById(id);
            var resources = _mapper.Map<Customer, CustomerResource>(customer.Resource);
            return resources;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Register A Customer",
            Description = "Add A Customer To The Database.",
            Tags = new[] {"Customers"})]
        public async Task<IActionResult> PostAsync([FromBody] SaveCustomerResourse resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var customer = _mapper.Map<SaveCustomerResourse, Customer>(resource);
            
            var result = await _customerService.SaveAsync(customer);

            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);

            return Ok(customerResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Edit A Customer",
            Description = "Edit The Information Of A Customer Identified By His Id.",
            Tags = new[] {"Customers"})]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCustomerResourse resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var customer = _mapper.Map<SaveCustomerResourse, Customer>(resource);

            var result = await _customerService.UpdateAsync(id, customer);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);

            return Ok(customerResource);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete A Customer",
            Description = "Delete The Information Of A Client Identified By His Id.",
            Tags = new[] {"Customers"})]
        public async Task<IActionResult> RemoteAsync(int id)
        {
            var result = await _customerService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);

            return Ok(customerResource);
        }
    }
}