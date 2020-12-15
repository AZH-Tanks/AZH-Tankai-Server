using AZH_Tankai_Server.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Runtime.CompilerServices;
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

        public static void StartGeneration() {
            StartGeneration((timeout) => new Timer(timeout));
        }

        public  static void StartGeneration(Func<int, Timer> timerFactory)
        {
            _generationInterval = 5000;
            Random rnd = new Random();
            switch (rnd.Next(4))
            {
                case 0:
                    _powerUpGenerator.SetAlgorithm(new PreferStrongPowerUps());
                    _hubContext.Clients.All.SendAsync("PowerUpStrategy", "PreferStrongPowerUps");
                    break;
                case 1:
                    _powerUpGenerator.SetAlgorithm(new PreferWeakPowerUps());
                    _hubContext.Clients.All.SendAsync("PowerUpStrategy", "PreferWeakPowerUps");
                    break;
                case 2:
                    _powerUpGenerator.SetAlgorithm(new ProgressiveGeneration());
                    _hubContext.Clients.All.SendAsync("PowerUpStrategy", "ProgressiveGeneration");
                    break;
                case 3:
                    _powerUpGenerator.SetAlgorithm(new SpamPowerUps());
                    _generationInterval = 2000;
                    _hubContext.Clients.All.SendAsync("PowerUpStrategy", "SpamPowerUps");
                    break;
                default:
                    _powerUpGenerator.SetAlgorithm(new PreferWeakPowerUps());
                    _hubContext.Clients.All.SendAsync("PowerUpStrategy", "PreferWeakPowerUps");
                    break;
            }

            _generationTimer = timerFactory.Invoke(_generationInterval);
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
            _powerUpGenerator.StopAlgorithmStopwatch();
        }

        public static void ReduceTimerInterval(int milliseconds)
        {
            if (_generationTimer.Interval - milliseconds > 1)
            {
                _generationTimer.Interval -= milliseconds;
            }
        }
    }
}
