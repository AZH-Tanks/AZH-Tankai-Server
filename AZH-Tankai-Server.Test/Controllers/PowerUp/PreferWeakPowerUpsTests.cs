using NUnit.Framework;
using AZH_Tankai_Server.Controllers.PowerUp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZH_Tankai_Server.Controllers.PowerUp.Tests
{
    [TestFixture()]
    public class PreferWeakPowerUpsTests
    {
        [Test()]
        public void GeneratePowerUpTest()
        {
            var random = new Random();
            var generator = new PreferWeakPowerUps();
            var powerUps = new List<Models.PowerUp>(1000);
            for (int i = 0; i < 1000; i++)
            {
                var point = new Models.Point()
                {
                    X = random.Next(1000),
                    Y = random.Next(1000)
                };
                var powerUp = generator.GeneratePowerUp(point);
                powerUps.Add(powerUp);
                Assert.True(powerUp.Location.X >= 0);
                Assert.True(powerUp.Location.X < 1000);
                Assert.True(powerUp.Location.Y >= 0);
                Assert.True(powerUp.Location.Y < 1000);
                Assert.True(PowerUpGenerator.weakPowerUps.Contains(powerUp.Type));
            }
        }
    }
}