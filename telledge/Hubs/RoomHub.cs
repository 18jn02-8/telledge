using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace telledge.Hubs
{
	public class RoomHub : Hub
	{
		// 指定されたグループへ参加する
		public void Join(string groupName)
		{
			Groups.Add(Context.ConnectionId, groupName);
		}

		// 指定されたグループから離脱する
		public void Leave(string groupName)
		{
			Groups.Remove(Context.ConnectionId, groupName);
		}
		public void joined(int roomId)
		{
			Clients.Group("room_" + roomId).joined();
		}
		public void Hello()
		{
			Clients.All.hello();
		}
	}
}