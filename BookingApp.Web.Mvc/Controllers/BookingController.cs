using System;
using System.Collections.Generic;
using System.Diagnostics;
using BookingApp.Core;
using BookingApp.Web.Mvc.Infrastructure;
using BookingApp.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Web.Mvc.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingStorageHelper _bookingStorageHelper;

        public BookingController(BookingStorageHelper bookingStorageHelper)
        {
            _bookingStorageHelper = bookingStorageHelper;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateBookingRequest request)
        {
            var booking = new Booking(request.BookingDate.DateTime, request.BookingCount);

            _bookingStorageHelper.AddBooking(booking);

            var count = _bookingStorageHelper.GetAllBookings().Count;
            Console.WriteLine(count);

            return RedirectToAction("Index", "Home");
        }
    }
}