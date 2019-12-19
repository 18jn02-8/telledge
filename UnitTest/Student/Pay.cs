using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Students
{
	[TestClass]
	class Pay
	{
		[TestMethod]
		public void TestPay()
		{
			Student student = new Student();
			bool test = student.Pay(50);
			Assert.IsTrue(test);
 		}
	}
}
