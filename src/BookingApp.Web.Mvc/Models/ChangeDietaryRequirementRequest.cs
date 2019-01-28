using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Web.Mvc.Models
{
    public class ChangeDietaryRequirementRequest
    {
        public string BookingId { get; set; }
        public string Requirement { get; set; }
    }
}
