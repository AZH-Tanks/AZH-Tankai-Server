using AZH_Tankai_Server.Controllers.PowerUp;
using AZH_Tankai_Server.Hubs;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;

namespace AZH_Tankai_Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            var hubContext = host.Services.GetService(typeof(IHubContext<ControlHub>));
            PowerUpStorage.Start((IHubContext<ControlHub>)hubContext);
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
