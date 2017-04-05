using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Exceptions
{
    public class NoCreditCardProvidedException:Exception
    {
        public NoCreditCardProvidedException():base("No credit card has been provided to charge in case of cancellation.")
        {

        }
    }
}
