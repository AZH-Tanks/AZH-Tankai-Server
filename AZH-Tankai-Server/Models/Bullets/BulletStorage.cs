using AZH_Tankai_Server.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Timers;

namespace AZH_Tankai_Server.Models.Bullets
{
    class BulletStorage
    {
        private IHubContext<ControlHub> hubContext;
        static object thisLock = new object();
        readonly Dictionary<string, Bullet> bullets;

        private BulletStorage()
        {
            bullets = new Dictionary<string, Bullet>();
        }

        public void Start(IHubContext<ControlHub> context)
        {
            hubContext = context;
            Timer timer = new Timer(50);
            timer.Elapsed += OnTick;
            timer.Enabled = true;
        }
        private void OnTick(object source, ElapsedEventArgs e)
        {
            if (bullets.Count() == 0)
            {
                return;
            }
            hubContext.Clients.All.SendAsync("ReceiveBulletCoordinates", JsonSerializer.Serialize(bullets.Select(entry => entry.Value.GetBulletDTO()))).GetAwaiter().GetResult();
            foreach (KeyValuePair<string, Bullet> entry in bullets)
            {
                entry.Value.Location = new Point(entry.Value.Location.X + entry.Value.Velocity, entry.Value.Location.Y);
            }
        }

        private static BulletStorage singleton;
        public static BulletStorage Get()
        {
            lock (thisLock)
            {
                if (singleton == null)
                {
                    singleton = new BulletStorage();
                }
                return singleton;
            }
        }

        public void Add(string tankId, Bullet bullet)
        {
            bullets[tankId] = bullet;
        }
    }
}
