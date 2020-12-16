using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using AZH_Tankai_Server.Models;

namespace AZH_Tankai_Server.Test.Models
{
    [TestFixture()]
    class GameStorageTests
    {
        private GameStorage singleton;

        [SetUp()]
        public void setup()
        {
            singleton = GameStorage.Get();
        }

        static List<GameRoom> GameRoomCases()
        {
            List<GameRoom> rooms = new List<GameRoom>();

            PrivateGameRoom privateRoom1 = new PrivateGameRoom();
            privateRoom1.JoinLink = "";
            privateRoom1.Mode = new DeathmatchMode();
            privateRoom1.Password = "";
            privateRoom1.SizeLimit = 5;

            PublicGameRoom publicRoom1 = new PublicGameRoom();
            publicRoom1.JoinLink = "fsafasf";
            publicRoom1.Mode = new SurvivalMode();
            publicRoom1.PlayerCap = 10;

            PublicGameRoom publicRoom2 = new PublicGameRoom();
            publicRoom2.JoinLink = "";
            publicRoom2.Mode = new DeathmatchMode();
            publicRoom2.PlayerCap = -10;

            PrivateGameRoom privateRoom2 = new PrivateGameRoom();
            privateRoom2.JoinLink = "jfgjfg";
            privateRoom2.Mode = new SurvivalMode();
            privateRoom2.Password = "jfgjfg";
            privateRoom2.SizeLimit = -1;

            rooms.Add(privateRoom1);
            rooms.Add(publicRoom1);
            rooms.Add(publicRoom2);
            rooms.Add(privateRoom2);
            return rooms;
        }

        [Test, TestCaseSource("GameRoomCases")]
        public void AddPlayer(GameRoom gameRoom)
        {
            Assert.That(() => singleton.Add(gameRoom), Throws.Nothing);
        }

        [Test, TestCaseSource("GameRoomCases")]
        public void RemoveGameRoom(GameRoom gameRoom)
        {
            Assert.That(() => singleton.Remove(gameRoom), Throws.Nothing);
        }

        [Test, TestCaseSource("GameRoomCases")]
        public void GetGameRoomsByLink(GameRoom gameRoom)
        {
            Assert.That(() => singleton.GetByConnectionCode(gameRoom.JoinLink), Throws.Nothing);
        }
    }
}
