using System.Runtime.CompilerServices;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Resources;

namespace Go2Climb.API.Domain.Services.Communication
{
    public class CustomerResponse : BaseResponse
    {
        public Customer Customer { get; private set; }
        
        public CustomerResponse(bool success, string message, Customer customer) : base(success, message)
        {
            Customer = customer;
        }
        
        public CustomerResponse(Customer customer) : this(true, string.Empty, customer) {}

        public CustomerResponse(string message) : this(false, message, null) {}
    }
}