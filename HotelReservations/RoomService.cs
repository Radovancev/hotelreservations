using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations
{
    public class RoomService
    {
        List<Room> rooms = new List<Room>();

        private void CreateRooms(int size)
        {
            for (int i = 1; i <= size ; i++)
            {
                rooms.Add(new Room(i));
            }
        }

        public bool InitializeRooms(int size)
        {
            if (size > 1000 || size < 0) return false;

            CreateRooms(size);
            return true;
        }

        public bool AddReservation(int startDay, int endDay)
        {
            Dictionary<int, int> roomShortestPeriod = new Dictionary<int, int>();
            foreach (var room in rooms)
            {
                var shortestPeriod = room.Check(startDay, endDay);
                roomShortestPeriod.Add(room.id, shortestPeriod);

            }

            try
            {
                HashSet<int> values = new HashSet<int>();
                Dictionary<int, int> distinctedRoomShortestPeriods = new Dictionary<int, int>();
                foreach (var item in roomShortestPeriod)
                {
                    if (values.Add(item.Value))
                    {
                        distinctedRoomShortestPeriods.Add(item.Key, item.Value);
                    }
                }
                var roomPeriod = distinctedRoomShortestPeriods.Where(x => x.Value > 0).OrderBy(x=> x.Value).FirstOrDefault();

                var roomWithShortestPeriod = rooms.Where(x => x.id == roomPeriod.Key).FirstOrDefault();

                roomWithShortestPeriod.AddReservation(startDay, endDay);


                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
