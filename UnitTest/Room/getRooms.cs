using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Rooms
{
    [TestClass]
    public class getRooms
    {
        [TestMethod]
        public void Success()
        {
            Assert.IsNotNull(Room.getRooms());
        }
        [TestMethod]
        public void Failed()
        {

        }
    }
}
