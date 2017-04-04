using System;
using TechTalk.SpecFlow;
using Xunit;

namespace BookingApp.Test
{
    [Binding]
    public class BookingAppSteps
    {
        [Given(@"The the customer has created a booking for two people")]
        public void GivenTheTheCustomerHasCreatedABookingForTwoPeople()
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"they confirm")]
        public void WhenTheyConfirm()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the customer should get a confirmation email")]
        public void ThenTheCustomerShouldGetAConfirmationEmail()
        {
            //ScenarioContext.Current.Pending();
            Assert.True(false, "Not implemented");
        }

        [AfterScenario()]
        public void DisposeUnmanaged()
        {
            
        }
    }
}
