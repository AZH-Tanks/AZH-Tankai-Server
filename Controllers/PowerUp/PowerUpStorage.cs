using AZH_Tankai_Server.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Text.Json;
using System.Timers;

namespace AZH_Tankai_Server.Controllers.PowerUp
{
    public class PowerUpStorage
    {
        private static IHubContext<ControlHub> _hubContext;
        private static PowerUpGenerator _powerUpGenerator;
        private static int _generationInterval;
        private static Timer _generationTimer = null;

        public static void Start(IHubContext<ControlHub> hubContext)
        {
            _hubContext = hubContext;
            _powerUpGenerator = new PowerUpGenerator();
        }

        public static void StartGeneration()
        {
            Random rnd = new Random();
            switch (rnd.Next(4))
            {
                case 0:
                    _powerUpGenerator.SetAlgorithm(new PreferStrongPowerUps());
                    _generationInterval = 6000;
                    _hubContext.Clients.All.SendAsync("PowerUpStrategy", "PreferStrongPowerUps");
                    break;
                case 1:
                    _powerUpGenerator.SetAlgorithm(new PreferWeakPowerUps());
                    _generationInterval = 6000;
                    _hubContext.Clients.All.SendAsync("PowerUpStrategy", "PreferWeakPowerUps");
                    break;
                case 2:
                    _powerUpGenerator.SetAlgorithm(new ProgressiveGeneration());
                    _generationInterval = 6000;
                    _hubContext.Clients.All.SendAsync("PowerUpStrategy", "ProgressiveGeneration");
                    break;
                case 3:
                    _powerUpGenerator.SetAlgorithm(new SpamPowerUps());
                    _generationInterval = 2000;
                    _hubContext.Clients.All.SendAsync("PowerUpStrategy", "SpamPowerUps");
                    break;
                default:
                    _powerUpGenerator.SetAlgorithm(new PreferWeakPowerUps());
                    _generationInterval = 6000;
                    _hubContext.Clients.All.SendAsync("PowerUpStrategy", "PreferWeakPowerUps");
                    break;
            }

            _generationTimer = new Timer(_generationInterval);
            _generationTimer.Elapsed += PowerUpGeneration__Elapsed;
            _generationTimer.Enabled = true;
        }

        public static void PowerUpGeneration__Elapsed(object source, ElapsedEventArgs e)
        {
            _hubContext.Clients.All.SendAsync("ReceivePowerUp", JsonSerializer.Serialize(_powerUpGenerator.PowerUpGeneration(15, 15)));
        }

        public static void StopGeneration()
        {
            if (_generationTimer != null)
            {
                _generationTimer.Dispose();
            }
        }
    }
}
