using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Hubs
{
    public class ControlHub : Hub
    {
        public Task SendCoordinate(string user, int x, int y)
        {
            
            return Clients.All.SendAsync("ReceiveCoordinate", user, x, y);
        }

        public Task SendPlayer(string user)
        {
            return Clients.All.SendAsync("ReceiveUser", user);
        }
    }
}
