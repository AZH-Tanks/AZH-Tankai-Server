using AZH_Tankai_Server.DTO;
using AZH_Tankai_Server.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AZH_Tankai_Server.Hubs
{
    public partial class ControlHub : Hub
    {

        readonly GameStorage gameRooms = GameStorage.Get();
        readonly PlayerStorage players = PlayerStorage.Get();
        public Task SendRoom(string user, string id, string json)
        {
            RoomDTO roomDTO = JsonConvert.DeserializeObject<RoomDTO>(json);
            string connectionCode = Guid.NewGuid().ToString().Substring(0, 8);
            if (roomDTO.IsPublic)
            {
                PublicGameRoom gameRoom = new PublicGameRoom();
                gameRoom.Mode = new SurvivalMode();
                gameRoom.PlayerCap = roomDTO.SizeLimit;
                gameRoom.Players.Add(players.GetByUsername(user));
                gameRoom.JoinLink = connectionCode;
                gameRooms.Add(gameRoom);
                return Clients.Caller.SendAsync(gameRoom.Mode.InitiateMode(), gameRoom.JoinLink);
            }
            else
            {
                PrivateGameRoom gameRoom = new PrivateGameRoom();
                gameRoom.Mode = new DeathmatchMode();
                gameRoom.Password = roomDTO.Password;
                gameRoom.SizeLimit = roomDTO.SizeLimit;
                gameRoom.JoinLink = connectionCode;
                gameRoom.Players.Add(players.GetByUsername(user));
                gameRooms.Add(gameRoom);
                return Clients.Caller.SendAsync(gameRoom.Mode.InitiateMode(), gameRoom.JoinLink);
            }

        }

        public Task SendRoomCredentials(string user, string id, string password, string connectionCode)
        {
            return Clients.Caller.SendAsync(gameRooms.GetByCredentials(password, connectionCode)?.Mode.InitiateMode(), gameRooms.GetByCredentials(password, connectionCode)?.JoinLink);
        }
        static ImageOriginator originator = new ImageOriginator();
        static Caretaker caretaker = new Caretaker();
        public Task SendImage(string user, string roomId, string text)
        {
            GameRoom gameRoom = gameRooms.GetByConnectionCode(roomId);
            ImageProxy imgProxy = new ImageProxy(text);


            originator.Source = imgProxy.getImage();
            caretaker.Memento = originator.SaveMemento();     
            Clients.All.SendAsync("ReceiveImage", gameRoom.JoinLink, originator.Source);

            Thread.Sleep(3000);

            originator.Source = imgProxy.getImage();
            caretaker.Memento = originator.SaveMemento();
            Clients.All.SendAsync("ReceiveImage", gameRoom.JoinLink, originator.Source);

            return Task.CompletedTask;
        }

        public Task UndoImage(string user, string roomId)
        {
            GameRoom gameRoom = gameRooms.GetByConnectionCode(roomId);
            originator.RestoreMemento(caretaker.Memento);
            return Clients.All.SendAsync("ReceiveImage", gameRoom.JoinLink, originator.Source);
        }



        public Task SendTextMessage(string user, string roomId, string text)
        {
            Player player = players.GetByUsername(user);
            GameRoom gameRoom = gameRooms.GetByConnectionCode(roomId);
            ContentDTO content = new ContentDTO();
            content.IsImage = false;
            content.Message = text;
            content.Player = player;

            ISendContent sendTextCommand = new SendText(gameRoom.GetChat());
            player.Send(sendTextCommand, content);

            string chatStr = "";
            foreach (var contect in sendTextCommand.Chat.GetContents())
            {
                chatStr += contect.Player.Name + ": " + contect.Message + "\n";
            }

            return Clients.All.SendAsync("ReceiveMessage", gameRoom.JoinLink, chatStr);
        }

        public Task UndoTextMessage(string user, string roomId)
        {
            Player player = players.GetByUsername(user);
            GameRoom gameRoom = gameRooms.GetByConnectionCode(roomId);


            ISendContent sendTextCommand = new SendText(gameRoom.GetChat());
            player.Undo(sendTextCommand, user);

            string chatStr = "";
            foreach (var contect in sendTextCommand.Chat.GetContents())
            {
                chatStr += contect.Player.Name + ": " + contect.Message + "\n";
            }

            return Clients.All.SendAsync("ReceiveMessage", gameRoom.JoinLink, chatStr);
        }

    }

}
