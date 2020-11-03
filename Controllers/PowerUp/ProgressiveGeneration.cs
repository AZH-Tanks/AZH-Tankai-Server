using System;
using AZH_Tankai_Shared;
using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.PowerUp
{
    public class ProgressiveGeneration : IGenerationAlgorithm
    {
        public Models.PowerUp GeneratePowerUp(Point point)
        {
            // TODO: randomize power up
            // TODO: add progressive power up generation logic
            Models.PowerUp powerUp = new Models.PowerUp(PowerUpType.Camo, point);
            return powerUp;
        }
    }
}