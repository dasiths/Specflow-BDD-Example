using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp
{
    public class Booking
    {
        public DateTime BookingDate { get; set; }

        public int NumOfPeople { get; set; }

        public string DiateryRequirements { get; set; }

        public decimal CancellationFee { get; set; }

        public string CreditCardDetails { get; set; }
    }
}
