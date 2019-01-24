using System;

namespace BookingApp.Core.Exceptions
{
    public class NoCreditCardProvidedException:Exception
    {
        public NoCreditCardProvidedException():base("No credit card has been provided to charge in case of cancellation.")
        {

        }
    }
}
