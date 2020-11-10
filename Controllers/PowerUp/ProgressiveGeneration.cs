using System;
using AZH_Tankai_Shared;
using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.PowerUp
{
    public class ProgressiveGeneration : IGenerationAlgorithm
    {
        // TODO: add progressive power up generation logic after GameHub is added to project
        public Models.PowerUp GeneratePowerUp(Point point)
        {
            Array powerUps = Enum.GetValues(typeof(PowerUpType));
            Random rnd = new Random();
            Models.PowerUp powerUp = new Models.PowerUp((PowerUpType)powerUps.GetValue(rnd.Next(powerUps.Length)), point);
            return powerUp;
        }
    }
}