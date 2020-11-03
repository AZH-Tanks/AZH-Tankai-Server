using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.PowerUp
{
    public class PowerUpGenerator
    {
        private IGenerationAlgorithm _generationAlgorithm;

        public PowerUpGenerator() { }

        public void SetAlgorithm(IGenerationAlgorithm algorithm)
        {
            _generationAlgorithm = algorithm;
        }

        public Models.PowerUp PowerUpGeneration(int width, int height)
        {
            Random rnd = new Random();
            Point point = new Point(rnd.Next(width), rnd.Next(height));
            return _generationAlgorithm.GeneratePowerUp(point);
        }
    }
}