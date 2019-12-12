using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Students
{
    [TestClass]
    public class StudentchengePassword
    {
        [TestMethod]
        public void TestchengePassword()
        {
            Student student = new Student();
			student.id = 2;
			student.setPassword("password");
			bool test = student.chengePassword("password", "newpass");
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void TestchengePasswordFailed()
        {
			Student student = new Student();
			student.id = 2;
			student.setPassword("password");
			bool test = student.chengePassword("pappappa", "newpass");
			Assert.IsFalse(test);
        }
    }
}
