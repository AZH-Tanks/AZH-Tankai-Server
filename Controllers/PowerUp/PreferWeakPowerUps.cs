using System;
using System.Collections.Generic;
using AZH_Tankai_Shared;
using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.PowerUp
{
    public class PreferWeakPowerUps : IGenerationAlgorithm
    {
        public Models.PowerUp GeneratePowerUp(Point point)
        {
            Random rnd = new Random();
            int randomPowerUp = rnd.Next(PowerUpGenerator.weakPowerUps.Count);
            Models.PowerUp powerUp = new Models.PowerUp(PowerUpGenerator.weakPowerUps[randomPowerUp], point);
            return powerUp;
        }
    }
}