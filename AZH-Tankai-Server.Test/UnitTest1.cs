using NUnit.Framework;

namespace AZH_Tankai_Server.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestFail()
        {
            Assert.False(true);
        }
    }
}