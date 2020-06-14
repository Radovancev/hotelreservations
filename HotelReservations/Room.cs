using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations
{
    public class Room
    {
        public int id { get; set; }
        public List<Reservation> Reservations = new List<Reservation>();

        public Room() { }

        public  Room(int id)
        {
            this.id = id;
        }
        public bool AddReservation(int startDay, int endDay)
        {
            Reservation reservation = new Reservation(startDay,endDay);
            Reservations.Add(reservation);

            return true;
        }
        public int Check(int startDay, int endDay)
        {
            int shortestPeriod = 0;
            List<int> periods = new List<int>();

            if (!IsValidDate(startDay)) return 0;
            if (!IsValidDate(endDay)) return 0;
            if (Reservations.Count() == 0) return 366;
            foreach (var item in Reservations)
            {
                if (startDay >= item.startDate && startDay <= item.endDate) return 0;

                if (endDay >= item.startDate && endDay <= item.endDate) return 0;

                if (item.startDate >= startDay && item.startDate <= endDay) return 0;

                if (item.endDate >= startDay && item.endDate <= endDay) return 0;

                periods.Add(Math.Abs(startDay - item.endDate));
            }

            if (periods.Count() == 0) return 0;
            shortestPeriod = periods.Where(x=>x > 0).Min();

            return shortestPeriod;
        }
        public bool IsValidDate(int date)
        {
            if (date < 0 || date > 365) return false;
            return true;
        }
    }

}
