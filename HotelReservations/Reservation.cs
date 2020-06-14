using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations
{
    public class Reservation
    {
        public int startDate { get; set; }
        public int endDate { get; set; }

        public Reservation(int startDate, int endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

    }
}
