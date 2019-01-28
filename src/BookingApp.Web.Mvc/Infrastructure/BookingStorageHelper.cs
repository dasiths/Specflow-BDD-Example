using System.Collections.Generic;
using System.Linq;
using BookingApp.Core;

namespace BookingApp.Web.Mvc.Infrastructure
{
    public class BookingStorageHelper
    {
        private readonly List<Booking> _bookings;

        public BookingStorageHelper()
        {
            _bookings = new List<Booking>();
        }

        public void AddBooking(Booking booking)
        {
            _bookings.Add(booking);
        }

        public Booking GetBooking(string id)
        {
            return _bookings.FirstOrDefault(b => b.Id == id);
        }

        public IReadOnlyCollection<Booking> GetAllBookings()
        {
            return _bookings;
        }
    }
}
