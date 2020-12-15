using NUnit.Framework;
using AZH_Tankai_Server.Models.Bullets;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZH_Tankai_Server.Models.Bullets.Tests
{
    [TestFixture()]
    public class BulletFactoryTests
    {
        private BulletFactory factory;

        [SetUp()]
        public void setup() {
            factory = new BulletFactory();
        }

        public static IEnumerable<string> bulletTypeProvider() {
            return new List<string>() { "Basic", "Laser", "Shrapnel", "HomingMissile", "Exploding", "Machinegun", "RANDOM UNUSED" };
        }

        [Test(), TestCaseSource("bulletTypeProvider")]
        public void createBulletTest(string bulletType)
        {
            var bullet = factory.createBullet(bulletType, 0, 0);

            switch (bulletType)
            {
                case "Basic":
                    {
                        Assert.True(bullet is BasicBullet);
                        break;
                    }
                case "Laser":
                    {
                        Assert.True(bullet is Laser);
                        break;
                    };
                case "Shrapnel":
                    {
                        Assert.True(bullet is Shrapnel);
                        break;
                    };
                case "HomingMissile":
                    {
                        Assert.True(bullet is HomingMissile);
                        break;
                    };
                case "Exploding":
                    {
                        Assert.True(bullet is ExplodingBullet);
                        break;
                    };
                case "Machinegun":
                    {
                        Assert.True(bullet is MachinegunBullet);
                        break;
                    };
                default:
                    {
                        Assert.True(bullet is BasicBullet);
                        break;
                    };
            }
        }
    }
}