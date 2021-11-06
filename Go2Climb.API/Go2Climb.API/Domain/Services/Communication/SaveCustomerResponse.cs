using System.Runtime.CompilerServices;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Resources;

namespace Go2Climb.API.Domain.Services.Communication
{
    public class SaveCustomerResponse : BaseResponse
    {
        public Customer Customer { get; private set; }
        
        public SaveCustomerResponse(bool success, string message, Customer customer) : base(success, message)
        {
            Customer = customer;
        }
        
        public SaveCustomerResponse(Customer customer) : this(true, string.Empty, customer) {}

        public SaveCustomerResponse(string message) : this(false, message, null) {}
    }
}