
using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Controllers.PowerUp
{
    public interface IGenerationAlgorithm
    {
        public Models.PowerUp GeneratePowerUp(Point point);
    }
}