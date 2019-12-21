using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace telledge.Hubs
{
	[HubName("Room")]
	public class RoomHub : Hub
	{
		// 指定されたグループへ参加する
		public void Join(int roomId)
		{
			Groups.Add(Context.ConnectionId, "room_" + roomId);
		}

		// 指定されたグループから離脱する
		public void Leave(int roomId)
		{
			Groups.Remove(Context.ConnectionId, "room_" + roomId);
		}
		public void joinRoom(int roomId)
		{
			Clients.Group("room_" + roomId).joined();
		}
		public void Hello()
		{
			Clients.All.hello();
		}
	}
}