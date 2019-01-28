using System;

namespace BookingApp.Core.Exceptions
{
    public class BookingOutsideHoursException : Exception
    {
        public BookingOutsideHoursException(DateTime startTime, DateTime closeTime) : base(
            $"Booking has to be between {startTime.ToShortTimeString()} and {closeTime.ToShortTimeString()}")
        {

        }
    }
}
