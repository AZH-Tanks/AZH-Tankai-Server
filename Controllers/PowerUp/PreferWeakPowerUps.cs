using System;
using System.Collections.Generic;
using AZH_Tankai_Shared;
using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.PowerUp
{
    public class PreferWeakPowerUps : IGenerationAlgorithm
    {
        private readonly List<PowerUpType> weakPowerUps = new List<PowerUpType>()
        {
            PowerUpType.Camo,
            PowerUpType.RemoveWall,
            PowerUpType.SpeedUpgrade
        };

        public Models.PowerUp GeneratePowerUp(Point point)
        {
            Random rnd = new Random();
            int randomPowerUp = rnd.Next(weakPowerUps.Count);
            Models.PowerUp powerUp = new Models.PowerUp(weakPowerUps[randomPowerUp], point);
            return powerUp;
        }
    }
}