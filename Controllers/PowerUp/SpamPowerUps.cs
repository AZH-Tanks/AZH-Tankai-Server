using System;
using AZH_Tankai_Shared;
using AZH_Tankai_Server.Models;
using System.ComponentModel.DataAnnotations;

namespace AZH_Tankai_Server.Controllers.PowerUp
{
    public class SpamPowerUps : IGenerationAlgorithm
    {
        public Models.PowerUp GeneratePowerUp(Point point)
        {
            // TODO: randomize power up
            Models.PowerUp powerUp = new Models.PowerUp(PowerUpType.Camo, point);
            return powerUp;
        }
    }
}