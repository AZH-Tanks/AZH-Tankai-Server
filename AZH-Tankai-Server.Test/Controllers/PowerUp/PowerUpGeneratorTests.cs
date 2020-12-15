using NUnit.Framework;
using AZH_Tankai_Server.Controllers.PowerUp;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace AZH_Tankai_Server.Controllers.PowerUp.Tests
{
    [TestFixture()]
    public class PowerUpGeneratorTests
    {

        [Test()]
        public void PowerUpGenerationTest()
        {
            var generator = new PowerUpGenerator();
            var algorithm = new Mock<PowerUp.IGenerationAlgorithm>();
            // mock algorithm
            algorithm.Setup(a => a.GeneratePowerUp(It.IsAny<Models.Point>())).Returns(new Mock<Models.PowerUp>().Object);
            generator.SetAlgorithm(algorithm.Object);

            var powerUp = generator.PowerUpGeneration(100, 100);
            algorithm.Verify(a => a.GeneratePowerUp(It.IsAny<Models.Point>()));
        }
    }
}