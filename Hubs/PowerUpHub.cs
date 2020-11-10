using AZH_Tankai_Server.Controllers.PowerUp;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;

namespace AZH_Tankai_Server.Hubs
{
    public partial class ControlHub : Hub
    {

        // TODO: add Timer to generate multiple power ups
        public Task GeneratePowerUps()
        {
            PowerUpStorage.StartGeneration();
            return Task.CompletedTask;
        }

        public Task StopPowerUpGeneration()
        {
            PowerUpStorage.StopGeneration();
            return Task.CompletedTask;
        }
    }
}
