using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelReservations.UnitTests
{
    [TestClass]
    public class ReservationTests
    {


        [TestMethod]
        public void AddInvalidDate()
        {
            var roomService = new RoomService();

            roomService.InitializeRooms(1);

            Assert.IsFalse(roomService.AddReservation(-4, 2));
            Assert.IsFalse(roomService.AddReservation(200, 400));
        }

        [TestMethod]
        public void RequestAreAccepted()
        {
            var roomService = new RoomService();

            roomService.InitializeRooms(3);

            Assert.IsTrue(roomService.AddReservation(0, 5));
            Assert.IsTrue(roomService.AddReservation(7, 13));
            Assert.IsTrue(roomService.AddReservation(3, 9));
            Assert.IsTrue(roomService.AddReservation(5, 7));
            Assert.IsTrue(roomService.AddReservation(6, 6));
            Assert.IsTrue(roomService.AddReservation(0, 4));
        }

        [TestMethod]
        public void RequestAreDeclined()
        {
            var roomService = new RoomService();

            roomService.InitializeRooms(3);

            Assert.IsTrue(roomService.AddReservation(1, 3));
            Assert.IsTrue(roomService.AddReservation(2, 5));
            Assert.IsTrue(roomService.AddReservation(1, 9));
            Assert.IsFalse(roomService.AddReservation(0, 15));
        }

        [TestMethod]
        public void RequestsCanBeAcceptedAfterDecline()
        {
            var roomService = new RoomService();

            roomService.InitializeRooms(3);

            Assert.IsTrue(roomService.AddReservation(1, 3));
            Assert.IsTrue(roomService.AddReservation(0, 15));
            Assert.IsTrue(roomService.AddReservation(1, 9));
            Assert.IsFalse(roomService.AddReservation(2, 5));
            Assert.IsTrue(roomService.AddReservation(4, 9));
        }

        [TestMethod]
        public void Complex()
        {
            var roomService = new RoomService();

            roomService.InitializeRooms(2);

            Assert.IsTrue(roomService.AddReservation(1, 3));
            Assert.IsTrue(roomService.AddReservation(0, 4));
            Assert.IsFalse(roomService.AddReservation(2, 3));
            Assert.IsTrue(roomService.AddReservation(5, 5)); 
            Assert.IsTrue(roomService.AddReservation(4, 10));
            Assert.IsTrue(roomService.AddReservation(10, 10));
            Assert.IsTrue(roomService.AddReservation(6, 7));
            Assert.IsFalse(roomService.AddReservation(8, 10));
            Assert.IsTrue(roomService.AddReservation(8, 9));
        }
    }
}
