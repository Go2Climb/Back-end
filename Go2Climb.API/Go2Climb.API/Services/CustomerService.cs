using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Repositories;
using Go2Climb.API.Domain.Services;
using Go2Climb.API.Domain.Services.Communication;

namespace Go2Climb.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _customerRepository.ListAsync();
        }

        public async Task<CustomerResponse> SaveAsync(Customer customer)
        {
            try
            {
                await _customerRepository.AddAsync(customer);
                await _unitOfWork.CompleteAsync();
                
                return new CustomerResponse(customer);
            }
            catch (Exception e)
            {
                return new CustomerResponse($"An error occurred while save the customer: {e.Message}");
            }
        }

        public async Task<CustomerResponse> FindById(int id)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(id);

            if (existingCustomer == null)
                return new CustomerResponse("Customer not found.");

            return new CustomerResponse(existingCustomer);
        }

        public async Task<CustomerResponse> UpdateAsync(int id, Customer customer)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(id);

            if (existingCustomer == null)
                return new CustomerResponse("Customer not found.");

            existingCustomer.Name = customer.Name;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.Password = customer.Password;
            existingCustomer.PhoneNumber = customer.PhoneNumber;

            try
            {
                _customerRepository.Update(existingCustomer);
                await _unitOfWork.CompleteAsync();
                
                return new CustomerResponse(existingCustomer);
            }
            catch (Exception e)
            {
                return new CustomerResponse($"An error occurred while updating the customer: {e.Message}");
            }
        }

        public async Task<CustomerResponse> DeleteAsync(int id)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(id);

            if (existingCustomer == null)
                return new CustomerResponse("Customer not found.");

            try
            {
                _customerRepository.Remove(existingCustomer);
                await _unitOfWork.CompleteAsync();

                return new CustomerResponse(existingCustomer);
            }
            catch (Exception e)
            {
                return new CustomerResponse($"An error occurred while deleting the customer: {e.Message}");
            }
        }
    }
}