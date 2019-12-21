using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using telledge.Models;

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
			Room room = Room.find(roomId);	//ルーム番号のルームインスタンスを取得する
			Student student = Student.
			Clients.Group("room_" + roomId).append();
		}
		public void Hello()
		{
			Clients.All.hello();
		}
	}
}