using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;


namespace UnitTest.Rooms
{
	[TestClass]
	public class getRooms_String_tag_
	{
		[TestMethod]
		public void succsess()
		{
			Room room = new Room();
			room.tag = "tag";
			Room[] rooms = Room.getRooms(room.tag);
			Assert.IsNotNull(rooms);
		}
	}
}
