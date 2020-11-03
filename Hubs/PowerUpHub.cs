using AZH_Tankai_Server.Controllers.PowerUp;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Text.Json;
using System.Timers;

namespace AZH_Tankai_Server.Hubs
{
    public partial class ControlHub : Hub
    {

        // TODO: add Timer to generate multiple power ups
        public void GeneratePowerUps()
        {
            Random rnd = new Random();
            PowerUpGenerator powerUpGenerator = new PowerUpGenerator();
            switch (rnd.Next(4))
            {
                case 0:
                    powerUpGenerator.SetAlgorithm(new PreferStrongPowerUps());
                    break;
                case 1:
                    powerUpGenerator.SetAlgorithm(new PreferWeakPowerUps());
                    break;
                case 2:
                    powerUpGenerator.SetAlgorithm(new ProgressiveGeneration());
                    break;
                case 3:
                    powerUpGenerator.SetAlgorithm(new SpamPowerUps());
                    break;
            }
            Clients.All.SendAsync("ReceivePowerUp", JsonSerializer.Serialize(powerUpGenerator.PowerUpGeneration(15, 15)));
        }
    }
}
