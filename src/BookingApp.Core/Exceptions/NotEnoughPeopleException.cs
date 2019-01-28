using System;

namespace BookingApp.Core.Exceptions
{
    public class NotEnoughPeopleException:Exception
    {
        public NotEnoughPeopleException(int n):base($"Minimum {n} people required for a booking.")
        {

        }
    }
}
