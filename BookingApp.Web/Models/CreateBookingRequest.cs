using System;

namespace BookingApp.Web.Models
{
    public class CreateBookingRequest
    {
        public DateTimeOffset BookingDate { get; set; }
        public int BookingCount { get; set; }
    }
}