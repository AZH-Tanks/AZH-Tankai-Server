using AZH_Tankai_Server.Controllers.Maze;
using AZH_Tankai_Server.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Hubs
{
    public partial class ControlHub : Hub
    {
        readonly PlayerStorage playerStorage = PlayerStorage.Get();
        public Task SendCoordinate(string user, int x, int y, int oldX, int oldY)
        {
            Player player = playerStorage.GetByUsername(user);
            Maze maze = mazeStorage.GetMaze();
            if (!maze.CheckCollisions(new Controllers.Collision.CollisionObject { X = x, Y = y, Radius = 3 }))
            {
                return Task.CompletedTask;
            }
            player.Tank.X = x;
            player.Tank.Y = y;
            return Clients.All.SendAsync("ReceiveCoordinate", user, x, y);
        }

        public Task GetPlayer(string userName)
        {
            Player player = playerStorage.GetByConnectionId(userName);
            if (player != null)
            {
                return Clients.All.SendAsync("ReceiveUser", player.Name);
            }
            return Task.CompletedTask;
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
