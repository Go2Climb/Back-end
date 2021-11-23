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
    
    public class AgencyServiceTest
    {
        [Test]
        public async Task ListAsyncWhenNoAgencyReturnsEmptyCollection()
        {
            //Arrange
            var mockAgencyRepository = GetDefaultIAgencyRepositoryInstance();
            mockAgencyRepository.Setup(u => u.ListAsync())
                .ReturnsAsync(new List<Agency>());

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var service = new AgencyService(mockAgencyRepository.Object, mockUnitOfWork.Object);
            
            //Act
            List<Agency> result = (List<Agency>) await service.ListAsync();
            var agencyCount = result.Count;
            
            //Assert
            agencyCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncInvalidIdReturnsAgencyNotFoundResponse()
        {
            //Arrange
            var mockAgencyRepository = GetDefaultIAgencyRepositoryInstance();
            var agencyId = 1;
            mockAgencyRepository.Setup(r => r.FindById(agencyId))
                .Returns(Task.FromResult<Agency>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new AgencyService(mockAgencyRepository.Object, mockUnitOfWork.Object);
            
            //Act
            AgencyResponse result = await service.GetById(agencyId);
            var message = result.Message;
            
            //Assert
            message.Should().Be("The agency does not exist.");
        }

        [Test]
        public async Task SavingWhenErrorReturnException()
        {
            //Arrange
            Agency agency = new Agency() { };
            var mockAgencyRepository = GetDefaultIAgencyRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            mockAgencyRepository.Setup(u => u.AddAsync(agency))
                .Throws(new Exception());
            var service = new AgencyService(mockAgencyRepository.Object, mockUnitOfWork.Object);
            
            //Act
            AgencyResponse response = await service.SaveAsync(agency);
            var message = response.Message;
            
            //Assert
            message.Should().Contain("An error occurred while saving the agency");
        }

        [Test]
        public async Task DeleteAsyncWhenErrorReturnMessage()
        {
            //Arrange
            Agency agency = new Agency
                {Id = 100, Name = "Go2Climb", Email = "go2climb@gmail.com", Description = "Best agency", PhoneNumber = "9937578780", Location = "Av. My House", Ruc = "7865432"};
            var mockAgencyRepository = GetDefaultIAgencyRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            mockAgencyRepository.Setup(u => u.Remove(agency))
                .Throws(new Exception());
            var service = new AgencyService(mockAgencyRepository.Object, mockUnitOfWork.Object);
            
            //Act
            AgencyResponse response = await service.DeleteAsync(100);
            var message = response.Message;
            
            //Assert
            message.Should().Be("Agency not found");
        }
        private Mock<IAgencyRepository> GetDefaultIAgencyRepositoryInstance()
        {
            return new Mock<IAgencyRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}