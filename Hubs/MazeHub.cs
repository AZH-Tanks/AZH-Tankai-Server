using AZH_Tankai_Server.Controllers;
using AZH_Tankai_Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Hubs
{
    public partial class ControlHub : Hub
    {
        private readonly MazeGenerator mazeGenerator = new MazeGenerator();

        public Task CreateMaze()
        {
            List<List<TileType>> mazeTiles = mazeGenerator.GenerateMaze().GetTileTypes();
            return Clients.All.SendAsync("ReceiveMaze", JsonSerializer.Serialize(mazeTiles));
        }
    }
}
