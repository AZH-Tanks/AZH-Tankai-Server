using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AZH_Tankai_Server.Models;
using System.Threading;

namespace AZH_Tankai_Server.Hubs
{
    public class PlayerHub : Hub
    {
        readonly PlayerStorage playerStorage = PlayerStorage.Get();
        public Task SendCoordinate(string user, int x, int y)
        {
            return Clients.All.SendAsync("ReceiveCoordinate", user, x, y);
        }

        public Task SendPlayer(string user, string connectionId)
        {

            if (playerStorage.GetByUsername(user) == null)
            {
                playerStorage.Add(new Player(user, connectionId));
                return Clients.All.SendAsync("ReceiveUser", user);

            }
            else
            {
                return Clients.Caller.SendAsync("PlayerExists", user);
            }
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Player player = playerStorage.GetByConnectionId(base.Context.ConnectionId);
            playerStorage.Remove(base.Context.ConnectionId);
            if (player != null)
            {
                Clients.All.SendAsync("TerminatePlayer", player.Name);
            }
            return base.OnDisconnectedAsync(exception);
        }

    }
}
