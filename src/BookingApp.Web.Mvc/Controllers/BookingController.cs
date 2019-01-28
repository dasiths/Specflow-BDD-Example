using System;
using System.Collections.Generic;
using System.Diagnostics;
using BookingApp.Core;
using BookingApp.Core.Exceptions;
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
            return View("Index", _bookingStorageHelper.GetAllBookings());
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        public ActionResult ViewBooking(string id)
        {
            var booking = _bookingStorageHelper.GetBooking(id);
            return View("ViewBooking", booking);
        }

        [HttpPost]
        public ActionResult Create(CreateBookingRequest request)
        {
            try
            {
                var booking = new Booking(request.BookingDate.DateTime, request.BookingCount);
                _bookingStorageHelper.AddBooking(booking);
                ViewBag.Message = "Created";

                return ViewBooking(booking.Id);
            }
            catch (NotEnoughPeopleException e)
            {
                ViewBag.Error = e;
                return Create();
            }
            catch (BookingOutsideHoursException e)
            {
                ViewBag.Error = e;
                return Create();
            }
        }

        [HttpPost]
        public ActionResult DietaryRequirement(ChangeDietaryRequirementRequest request)
        {
            var booking = _bookingStorageHelper.GetBooking(request.BookingId);

            if (!booking.IsConfirmed && !booking.IsCancelled)
            {
                booking.SetDietaryRequirements(request.Requirement);
                ViewBag.Message = "Dietary requirement updated";
            }
            else
            {
                ViewBag.Warning = "Unable to set dietary requirement";
            }

            return ViewBooking(booking.Id);
        }

        public ActionResult Confirm(string id, string creditcard)
        {
            var booking = _bookingStorageHelper.GetBooking(id);

            try
            {
                if (!booking.IsConfirmed && !booking.IsCancelled)
                {
                    booking.ConfirmBooking(creditcard);
                    ViewBag.Message = "Confirmed";
                }
                else
                {
                    ViewBag.Warning = "Can't be confirmed";
                }
            }
            catch (NoCreditCardProvidedException ex)
            {
                ViewBag.Error = ex;
            }

            return ViewBooking(id);
        }

        public ActionResult Cancel(string id)
        {
            var booking = _bookingStorageHelper.GetBooking(id);

            if (!booking.IsCancelled)
            {
                booking.CancelBooking();

                if (booking.IsCancellationFeeCharged)
                {
                    ViewBag.Message = $"Cancelled - ${booking.CancellationFee:n2} charged";
                }
                else
                {
                    ViewBag.Message = "Cancelled - No fee charged";
                }
            }
            else
            {
                ViewBag.Warning = "Can't be cancelled";
            }

            return ViewBooking(id);
        }
    }
}