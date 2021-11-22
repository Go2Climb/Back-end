using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services;
using Go2Climb.API.Extensions;
using Go2Climb.API.Resources;
using Go2Climb.API.Security.Authorization.Attributes;
using Go2Climb.API.Security.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Go2Climb.API.Controllers
{
    
    [ApiController]
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

        [AllowAnonymous]
        [HttpPost("auth/sign-in")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = await _customerService.Authenticate(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("auth/sign-up")]
        public async Task<IActionResult> Register(RegisterCustomerRequest request)
        {
            await _customerService.RegisterAsync(request);
            return Ok(new {message = "Registration successful"});
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            var resources = _mapper.Map<Customer, CustomerResource>(customer);
            return Ok(resources);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerRequest request)
        {
            await _customerService.UpdateAsync(id, request);
            return Ok(new {message = "Customer updated successfully"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return Ok(new {message = "Customer deleted successfully"});
        }
        
        /*
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
        } */
    }
}