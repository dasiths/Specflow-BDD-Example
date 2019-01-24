using System;
using System.Diagnostics;
using System.Web.Mvc;
using BookingApp.Web.Models;

namespace BookingApp.Web.Controllers
{
    public class BookingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateBookingRequest request)
        {
            Debug.WriteLine(string.Join(",", Request.Form.AllKeys));

            throw new NotImplementedException();
        }
    }
}