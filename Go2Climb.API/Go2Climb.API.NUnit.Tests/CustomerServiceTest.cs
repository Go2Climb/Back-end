using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using FluentAssertions;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Repositories;
using Go2Climb.API.Domain.Services.Communication;
using Go2Climb.API.Services;
using Moq;
using NUnit.Framework;

namespace Go2Climb.API.NUnitTests
{
    public class CustomerServiceTest
    {
        [Test]
        public async Task ListAsyncWhenNoCustomerReturnsEmptyCollection()
        {
            //Arrange
            var mockCustomerRepository = GetDefaultICustomerRepositoryInstance();
            mockCustomerRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<Customer>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var service = new CustomerService(mockCustomerRepository.Object, mockUnitOfWork.Object);
            
            //Act
            List<Customer> result = (List<Customer>) await service.ListAsync();
            var customerCount = result.Count;
            
            //Assert
            customerCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncInvalidIdReturnsCustomerNotFoundResponse()
        {
            //Arrange
            var mockCustomerRepository = GetDefaultICustomerRepositoryInstance();
            var customerId = 1;
            mockCustomerRepository.Setup(r => r.FindByIdAsync(customerId))
                .Returns(Task.FromResult<Customer>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new CustomerService(mockCustomerRepository.Object, mockUnitOfWork.Object);
            
            //Act
            CustomerResponse result = await service.FindById(customerId);
            var message = result.Message;
            
            //Assert
            message.Should().Be("Customer not found.");
        }

        [Test]
        public async Task SavingWhenErrorReturnException()
        {
            //Arrange
            Customer customer = new Customer() { };
            var mockCustomerRepository = GetDefaultICustomerRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            mockCustomerRepository.Setup(u => u.AddAsync(customer))
                .Throws(new Exception());
            var service = new CustomerService(mockCustomerRepository.Object, mockUnitOfWork.Object);
            
            //Act
            CustomerResponse response = await service.SaveAsync(customer);
            var message = response.Message;
            
            //Assert
            message.Should().Contain("An error occurred while saving the customer");
        }

        [Test]
        public async Task DeleteAsyncWhenErrorReturnMessage()
        {
            //Arrange
            Customer customer = new Customer
                {Id = 100, Name = "John", LastName = "Doe", Email = "johndoe@gmail.com", Password = "123456", PhoneNumber = "9937578780"};
            var mockCustomerRepository = GetDefaultICustomerRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            mockCustomerRepository.Setup(u => u.Remove(customer))
                .Throws(new Exception());
            var service = new CustomerService(mockCustomerRepository.Object, mockUnitOfWork.Object);
            
            //Act
            CustomerResponse response = await service.DeleteAsync(100);
            var message = response.Message;
            
            //Assert
            message.Should().Be("Customer not found.");
        }
        private Mock<ICustomerRepository> GetDefaultICustomerRepositoryInstance()
        {
            return new Mock<ICustomerRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}