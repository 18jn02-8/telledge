using telledge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Inquirys
{
	[TestClass]
	class find
	{
		[TestMethod]
		public void success()
		{
			Inquiry inquiry = Inquiry.find(1);
			Assert.IsNotNull(inquiry);
		}
	}
}
