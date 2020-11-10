using System;
using AZH_Tankai_Shared;
using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.PowerUp
{
    public class ProgressiveGeneration : IGenerationAlgorithm
    {
        public Models.PowerUp GeneratePowerUp(Point point)
        {
            double secondsElapsed = PowerUpGenerator.GetAlgorithmElapsedTime();
            PowerUpType powerUpType;

            Random rnd = new Random();
            double strongPowerUpChance = secondsElapsed / 100;
            if (strongPowerUpChance > 1.0 || strongPowerUpChance > rnd.NextDouble())
            {
                powerUpType = PowerUpGenerator.strongPowerUps[rnd.Next(PowerUpGenerator.strongPowerUps.Count)];
            }
            else
            {
                powerUpType = PowerUpGenerator.weakPowerUps[rnd.Next(PowerUpGenerator.weakPowerUps.Count)];
            }

            PowerUpStorage.ReduceTimerInterval(100);
            
            return new Models.PowerUp(powerUpType, point);   
        }
    }
}