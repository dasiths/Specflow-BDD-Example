using System;
using TechTalk.SpecFlow;
using Xunit;
using BookingApp;
using BookingApp.Exceptions;

namespace BookingApp.Test
{
    [Binding]
    public class BookingAppSteps
    {
        Booking tmpBooking;
        BookingOutsideHoursException OutsideHoursException;
        NoCreditCardProvidedException NoCreditCardException;
        NotEnoughPeopleException NotEnoughPeopleException;

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

        [Given(@"The the customer has created a booking outside work hours")]
        public void GivenTheTheCustomerHasCreatedABookingForPeopleOutsideWorkHours()
        {
            try
            {
                tmpBooking = new Booking(DateTime.Now.Date.AddHours(7), 2);
            }
            catch (BookingOutsideHoursException ex)
            {
                OutsideHoursException = ex;
            }
        }

        [Given(@"The booking has dietary requirements")]
        public void GivenTheBookingHasDietaryRequirements()
        {
            tmpBooking.SetDietaryRequirements("Vegan");
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

        [When(@"they confirm with credit card of (.*)")]
        public void WhenTheyConfirmWithCreditCard(string creditcard)
        {
            tmpBooking.ConfirmBooking(creditcard);
        }

        [When(@"they cancel the booking")]
        public void WhenTheyCancelTheBooking()
        {
            tmpBooking.CancelBooking();
        }

        [Then(@"the customer should get a not enough people error")]
        public void ThenTheCustomerShouldGetANotEnoughPeopleError()
        {
            Assert.NotNull(NotEnoughPeopleException);
        }

        [Then(@"the customer should get an outside work hours error")]
        public void ThenTheCustomerShouldGetAnOutsideWorkHoursError()
        {
            Assert.NotNull(OutsideHoursException);
        }

        [Then(@"the customer should get a confirmation email")]
        public void ThenTheCustomerShouldGetAConfirmationEmail()
        {
            Assert.True(tmpBooking.IsConfirmationEmailSent);
        }

        [Then(@"the customer should get an no credit card error")]
        public void CustomerShouldGetNoCreditCardError()
        {
            Assert.NotNull(NoCreditCardException);
        }

        [Then(@"the customer should be charged (.*) dollars")]
        public void ThenTheCustomerShouldBeChargedDollars(int amount)
        {
            Assert.True(tmpBooking.IsCancellationFeeCharged && tmpBooking.CancellationFee == amount);
        }

        [AfterScenario()]
        public void DisposeUnmanaged()
        {
            tmpBooking = null;
            OutsideHoursException = null;
            NoCreditCardException = null;
            NotEnoughPeopleException = null;
        }


    }
}
