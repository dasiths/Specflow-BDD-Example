using System;

namespace BookingApp.Core
{
    public class Booking
    {
        public string Id { get; private set; }
        public DateTime BookingDate { get; private set; }

        public int NumOfPeople { get; private set; }

        public string DietaryRequirements { get; private set; }

        public decimal CancellationFee { get; private set; }

        public string CreditCardDetails { get; private set; }

        public bool IsConfirmed { get; private set; }

        public bool IsCancelled { get; private set; }

        public bool IsConfirmationEmailSent { get; private set; }

        public bool IsCancellationFeeCharged { get; private set; }

        private const int minNumberOfPeople = 2;
        private const int cancellationFeeForMoreThanPeople = 5;
        public const decimal cancellationFeePerPerson = 20;
        public const decimal cancellationFeeSurcharge = 25;

        public Booking(DateTime bDate, int nPeople)
        {
            Id = Guid.NewGuid().ToString();
            BookingDate = bDate;
            NumOfPeople = nPeople;

            //throw exception if outside work hours of 9am to 9pm
            if (bDate.Hour < 9 || bDate.Hour > 21)
                throw new Exceptions.BookingOutsideHoursException(DateTime.Now.Date.AddHours(9), DateTime.Now.Date.AddHours(21));

            //throw exception if min number of people not met
            if (nPeople < minNumberOfPeople)
                throw new Exceptions.NotEnoughPeopleException(minNumberOfPeople);

            CalculateCancellationFee();
        }

        public void SetDietaryRequirements(string dRequirement)
        {
            this.DietaryRequirements = dRequirement;
            CalculateCancellationFee();
        }

        private void CalculateCancellationFee()
        {
            //calculate the cancellation fee
            if (NumOfPeople > cancellationFeeForMoreThanPeople)
            {
                CancellationFee = cancellationFeePerPerson * NumOfPeople;

                //add the surcharge if there is a dietary requirement
                if (string.IsNullOrEmpty(DietaryRequirements) == false)
                    CancellationFee += cancellationFeeSurcharge;
            }
            else
            {
                CancellationFee = 0;
            }
        }

        public void ConfirmBooking(string creditcard)
        {

            //check to see if credit card details have been provided if there is a cancellation fee associated
            if (CancellationFee > 0 && string.IsNullOrEmpty(creditcard))
            {
                throw new Exceptions.NoCreditCardProvidedException();
            }

            IsConfirmationEmailSent = true;
            IsConfirmed = true;
            IsCancelled = false;
        }

        public void CancelBooking()
        {
            //charge the credit card
            IsCancellationFeeCharged = true;

            IsConfirmed = false;
            IsCancelled = true;
        }
    }
}
