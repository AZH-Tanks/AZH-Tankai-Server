using System;
using System.Collections.Generic;
using AZH_Tankai_Shared;
using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.PowerUp
{
    public class PreferStrongPowerUps : IGenerationAlgorithm
    {
        public Models.PowerUp GeneratePowerUp(Point point)
        {
            Random rnd = new Random();
            int randomPowerUp = rnd.Next(PowerUpGenerator.strongPowerUps.Count);
            Models.PowerUp powerUp = new Models.PowerUp(PowerUpGenerator.strongPowerUps[randomPowerUp], point);
            return powerUp;
        }
    }
}