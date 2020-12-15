using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using AZH_Tankai_Server.Models;
using System.Diagnostics;
using System.Collections.Generic;
using AZH_Tankai_Shared;

namespace AZH_Tankai_Server.Controllers.PowerUp
{
    public class PowerUpGenerator
    {
        public static readonly List<PowerUpType> strongPowerUps = new List<PowerUpType>()
        {
            PowerUpType.HomingMissile,
            PowerUpType.ExplodingBullet,
            PowerUpType.Laser,
            PowerUpType.Machinegun
        };

        public static readonly List<PowerUpType> weakPowerUps = new List<PowerUpType>()
        {
            PowerUpType.Camo,
            PowerUpType.RemoveWall,
            PowerUpType.SpeedUpgrade
        };

        private IGenerationAlgorithm _generationAlgorithm;
        private static Stopwatch _stopwatch;

        public PowerUpGenerator() { }

        public void SetAlgorithm(IGenerationAlgorithm algorithm)
        {
            _generationAlgorithm = algorithm;
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public Models.PowerUp PowerUpGeneration(int width, int height)
        {
            Random rnd = new Random();
            Point point = new Point(rnd.Next(width), rnd.Next(height));
            return _generationAlgorithm.GeneratePowerUp(point);
        }

        public void StopAlgorithmStopwatch()
        {
            if (_stopwatch != null)
            {
                _stopwatch.Stop();
            }
        }

        public static int GetAlgorithmElapsedTime()
        {
            return (int)_stopwatch.ElapsedMilliseconds / 1000;
        }
    }
}