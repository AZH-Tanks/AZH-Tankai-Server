using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Test.Models
{
    [TestFixture()]
    class PlayerStorageTests
    {
        private PlayerStorage singleton;

        [SetUp()]
        public void setup()
        {
            singleton = PlayerStorage.Get();
        }

        static List<Player> PlayerCases()
        {
            return new List<Player>() {
         new Player("",""),
         new Player("^&*(^&*(hfiu","fasfasffiofas45af"),
         new Player("test",""),
         new Player("","test"),
         new Player(null,null),
         new Player("test",null),
         new Player(null,"test"),
         new Player("test","test")};
        }

        [Test, TestCaseSource("PlayerCases")]
        public void AddPlayer(Player player)
        {
            Assert.That(() => singleton.Add(player), Throws.Nothing);
        }

        [Test, TestCaseSource("PlayerCases")]
        public void RemovePlayer(Player player)
        {
            Assert.That(() => singleton.Remove(player.ConnectionId), Throws.Nothing);
        }

        [Test, TestCaseSource("PlayerCases")]
        public void GetPlayerById(Player player)
        {
            Assert.That(() => singleton.GetByConnectionId(player.ConnectionId), Throws.Nothing);
        }

        [Test, TestCaseSource("PlayerCases")]
        public void GetPlayerByName(Player player)
        {
            Assert.That(() => singleton.GetByUsername(player.Name), Throws.Nothing);
        }


    }
}
