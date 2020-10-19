using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AZH_Tankai_Server.Models;
using System.Threading;

namespace AZH_Tankai_Server.Hubs
{
    public class ControlHub : Hub
    {
        Storage lobby = Storage.Get();
        public Task SendCoordinate(string user, int x, int y)
        {
            return Clients.All.SendAsync("ReceiveCoordinate", user, x, y);
        }

        public Task SendPlayer(string user, string connectionId)
        {

            if (lobby.GetByUsername(user) == null)
            {
                lobby.Add(new Player(user, connectionId));
                return Clients.All.SendAsync("ReceiveUser", user);

            }
            else
            {
                return Clients.Caller.SendAsync("PlayerExists", user);
            }
        }
    

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Player player = lobby.GetByConnectionId(base.Context.ConnectionId);
            lobby.Remove(base.Context.ConnectionId);
            Clients.All.SendAsync("TerminatePlayer", player.Name);
            return base.OnDisconnectedAsync(exception);
        }

    }
}
