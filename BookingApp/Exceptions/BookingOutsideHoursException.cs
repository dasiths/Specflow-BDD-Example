using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Exceptions
{
    public class BookingOutsideHoursException : Exception
    {
        public BookingOutsideHoursException(DateTime startTime, DateTime closeTime) : base(
            $"Booking has to be between {startTime.ToShortTimeString()} and {closeTime.ToShortTimeString()}")
        {

        }
    }
}
