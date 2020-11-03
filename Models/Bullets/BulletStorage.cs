using AZH_Tankai_Server.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace AZH_Tankai_Server.Models.Bullets
{
    class BulletStorage
    {
        private IHubContext<ControlHub> hubContext;
        static object thisLock = new object();
      
        private BulletStorage()
        {
            bullets = new List<Bullet>();
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
            hubContext.Clients.All.SendAsync("testing", "thing").GetAwaiter().GetResult();
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

        readonly List<Bullet> bullets;

        public void Add(Bullet bullet)
        {
            bullets.Add(bullet);
        }
    }
}
