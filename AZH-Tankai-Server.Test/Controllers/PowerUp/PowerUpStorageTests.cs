using NUnit.Framework;
using AZH_Tankai_Server.Controllers.PowerUp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Moq;
using Microsoft.AspNetCore.SignalR;
using AZH_Tankai_Server.Hubs;
using System.Threading.Tasks;
using System.Threading;

namespace AZH_Tankai_Server.Controllers.PowerUp.Tests
{
    [TestFixture()]
    public class PowerUpStorageTests
    {

        private class ClientProxyStub : IClientProxy
        {
            public List<string> MethodsUsed = new List<string>();

            public Task SendCoreAsync(string method, object[] args, CancellationToken cancellationToken = default)
            {
                this.MethodsUsed.Add(method);
                return null;
            }
        }

        [Test(), Timeout(1000)]
        public void PowerUpStorageTest()
        {
            var proxyClientStub = new ClientProxyStub();

            var hubClientsMock = new Mock<IHubClients>();
            hubClientsMock.Setup(h => h.All).Returns(proxyClientStub);

            var hubMock = new Mock<IHubContext<ControlHub>>();
            hubMock.Setup(h => h.Clients).Returns(hubClientsMock.Object);

            PowerUpStorage.Start(hubMock.Object);
            PowerUpStorage.StartGeneration((timeout) => new System.Timers.Timer(1));
            while (proxyClientStub.MethodsUsed.Count < 2) {
                Thread.Sleep(10);
            }
            PowerUpStorage.StopGeneration();


            Assert.True(proxyClientStub.MethodsUsed.Count >= 2);
            Assert.That(proxyClientStub.MethodsUsed[0], Does.Match($".+Strategy"));
            Assert.That(proxyClientStub.MethodsUsed[1], Does.Match($"ReceivePowerUp"));
        }

    }
}