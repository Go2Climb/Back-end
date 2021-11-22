using Go2Climb.API.Domain.Models;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Go2Climb.API.Tests.Steps
{
    [Binding]
    public class AddAgencyStepsDefinition
    {
        private static RestClient _restClient;
        private static RestRequest _restRequest;
        private static IRestResponse _restResponse;
        private static Agency _agency;
        [Given(@"I want to create a new Agency")]
        public void GivenIWantToCreateANewAgency()
        {
            _restClient = new RestClient("https://localhost:5001/");
            _restRequest = new RestRequest("api/v1/agencies", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
        }

        [When(@"I create a new Agency")]
        public void WhenICreateANewAgency(Table agencyData)
        {
            _agency = agencyData.CreateInstance<Agency>();
            _agency = new Agency()
            {
                Name = "Go2Climb",
                Email = "Go2Climb@gmail.com",
                PhoneNumber = "987654321",
                Description = "New Agency",
                Location = "Av. JD House",
                Ruc = "98765432"
            };
            _restRequest.AddJsonBody(_agency);
            _restResponse = _restClient.Execute(_restRequest);
        }

        [Then(@"the agency will be created successfully")]
        public void ThenTheAgencyWillBeCreatedSuccessfully()
        {
            Assert.That("Go2Climb", Is.EqualTo(_agency.Name));
        }
    }
}