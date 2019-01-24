using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using BookingApp.Web.Models;

namespace BookingApp.Web.Controllers
{
    public class BookingController : Controller
    {
        private const string BookingKey = nameof(BookingKey);

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateBookingRequest request)
        {
            var booking = new Booking(request.BookingDate.DateTime, request.BookingCount);

            if (Session[BookingKey] == null)
            {
                Session[BookingKey] = new List<Booking>();
            }

            var bookings = Session[BookingKey] as List<Booking>;
            bookings.Add(booking);

            return RedirectToAction("Index", "Home");
        }
    }
}