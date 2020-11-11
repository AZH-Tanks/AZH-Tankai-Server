using AZH_Tankai_Server.Models.Bullets;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Hub = Microsoft.AspNetCore.SignalR.Hub;

namespace AZH_Tankai_Server.Hubs
{
    public partial class ControlHub : Hub
    {
        public Task SendFireBullet(string user, string type, int x, int y)
        {
            Bullet bullet = new BulletFactory().createBullet(type, x, y);
            BulletStorage.Get().Add(bullet);
            return Task.CompletedTask;
        }
    }
}
