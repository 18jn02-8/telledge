using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace telledge.Tests.Models
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void LoginFailByBothStatus()
        {
            //存在しないメールアドレスとパスワードでnullが返ってくるかどうかテスト
            Student ret = Student.login("notexit", "example");
            Assert.IsNull(ret);
        }
        [TestMethod]
        public void LoginFailByMail()
        {
            //存在する名前と間違ったパスワードでnullが返ってくるかテスト
            Student ret = Student.login("name", "example");
            Assert.IsNull(ret);
        }

        [TestMethod]
        public void LoginFailByPassword()
        {
            //存在しない名前と正しいパスワードでnullが返ってくるかテスト
            Student ret = Student.login("wrongName", "password");
            Assert.IsNull(ret);
        }

        [TestMethod]
        public void LoginSuccess()
        {
            //var session = new Mock<HttpSessionStateBase>();
            //controllerContext.Setup(p => p.HttpContext.Session).Returns(session.Object); 
            Student ret = Student.login("name", "password");
            Assert.IsNotNull(ret);
            //Assert.AreEqual(ret,       
        }

        [TestMethod]
        public void SetPassWordTest()
        {
            Student student = new Student();
            student.setPassword("password");
        }
        [TestMethod]
        public void TestCreate()
        {
            Student student = new Student();
            student.name = "Test";
            student.mailaddress = "OARO@jec.ac.jp";
            student.setPassword("password");
            student.is2FA = false;
            student.point = 0;
            student.profileImage = "kfwaoefa.pix";
            student.skypeId = "Test@skypeid";
            student.inactiveDate = null;
            bool test = student.create();
            Assert.IsTrue(test);
        }
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
