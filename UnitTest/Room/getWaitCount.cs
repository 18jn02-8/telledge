using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using telledge.Models;

namespace UnitTest.Rooms
{
    [TestClass]
    public class RoomgetWaitCount
    {
        [TestMethod]
		public void success()
		{
			Room room = new Room();
			room.id = 1;
			Assert.AreNotEqual(0,room.getWaitCount());
		}
        [TestMethod]
		public void failed()
		{
			Room room = new Room();
			room.id = 3;
			Assert.AreEqual(0, room.getWaitCount());
		}
	}
}
