using System;
using System.Collections.Generic;
using AZH_Tankai_Shared;
using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.PowerUp
{
    public class PreferStrongPowerUps : IGenerationAlgorithm
    {
        private readonly List<PowerUpType> strongPowerUps = new List<PowerUpType>()
        {
            PowerUpType.HomingMissile,
            PowerUpType.ExplodingBullet,
            PowerUpType.Laser,
            PowerUpType.Machinegun
        };

        public Models.PowerUp GeneratePowerUp(Point point)
        {
            Random rnd = new Random();
            int randomPowerUp = rnd.Next(strongPowerUps.Count);
            Models.PowerUp powerUp = new Models.PowerUp(strongPowerUps[randomPowerUp], point);
            return powerUp;
        }
    }
}