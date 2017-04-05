# Specflow-BDD-Example
Demonstrate BDD using specflow and .net

-- Feature File --

Feature: BookingApp
		 In order to cehck the booking functionality
		 We will create bookings

@mytag
Scenario: Make a booking for two people
	Given The the customer has created a booking for 2 people
	When they confirm with no credit card
	Then the customer should get a confirmation email
  
-- Code example --

        [Given(@"The the customer has created a booking for (.*) people")]
        public void GivenTheTheCustomerHasCreatedABookingFor(int numOfPeople)
        {
            try
            {
                tmpBooking = new Booking(DateTime.Now.Date.AddHours(10), numOfPeople);
            }
            catch (NotEnoughPeopleException ex)
            {
                NotEnoughPeopleException = ex;
            }

        }
        
        [When(@"they confirm with no credit card")]
        public void WhenTheyConfirmWithNoCreditCard()
        {
            try
            {
                tmpBooking.ConfirmBooking("");
            }
            catch (NoCreditCardProvidedException ex)
            {
                NoCreditCardException = ex;
            }

        }
        
        [Then(@"the customer should get a confirmation email")]
        public void ThenTheCustomerShouldGetAConfirmationEmail()
        {
            Assert.True(tmpBooking.IsConfirmationEmailSent);
        }
