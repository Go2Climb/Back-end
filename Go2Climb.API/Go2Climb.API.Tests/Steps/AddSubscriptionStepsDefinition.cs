using Go2Climb.API.Domain.Models;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Go2Climb.API.Tests.Steps
{
    [Binding]
    public class AddSubscriptionStepsDefinition
    {
        private static RestClient _restClient;
        private static RestRequest _restRequest;
        private static IRestResponse _restResponse;
        private static Subscription _subscription;
        
        [Given(@"the owner wants to add on subscription endpoint")]
        public void GivenTheOwnerWantsToAddOnSubscriptionEndpoint()
        {
            _restClient = new RestClient("https://localhost:5001/");
            _restRequest = new RestRequest("api/v1/subscriptions", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
        }

        [When(@"owner add a new subscription")]
        public void WhenOwnerAddANewSubscription(Table subscriptionData)
        {
            _subscription = subscriptionData.CreateInstance<Subscription>();
            _subscription = new Subscription()
            {
                Name = "Freemium",
                Price = 0,
                Description = "It's free",
            };
            _restRequest.AddJsonBody(_subscription);
            _restResponse = _restClient.Execute(_restRequest);
        }

        [Then(@"the subscription will be added successfully")]
        public void ThenTheSubscriptionWillBeAddedSuccessfully()
        {
            Assert.That("Freemium", Is.EqualTo(_subscription.Name));
        }
    }
}