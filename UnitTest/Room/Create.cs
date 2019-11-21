using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Rooms
{
    [TestClass]
    public class RoomCreate
    {
        [TestMethod]
        public void TestCreate()
        {
            Room room = new Room();
            room.teacherId = 1;
            room.roomName = "楽しい英語";
            room.tag = "English,Japan";
            room.description = "Description";
            room.worstTime = 40;
            room.extensionTime = 60;
            room.point = 2000;
            room.
            bool test = room.create();
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void TestCreateFailed()
        {
            Student student = new Student();
            student.name = "Test";
            student.mailaddress = "OARO@jec.ac.jp";
            student.is2FA = false;
            student.point = 0;
            student.profileImage = "Gafeokfwaoefa.pix";
            bool test = student.create();
            Assert.IsFalse(test);
        }
    }
}
