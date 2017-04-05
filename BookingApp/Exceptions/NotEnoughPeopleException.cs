using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Exceptions
{
    public class NotEnoughPeopleException:Exception
    {
        public NotEnoughPeopleException(int n):base($"Minimum {n} people required for a booking.")
        {

        }
    }
}
