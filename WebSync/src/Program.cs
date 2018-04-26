using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Addon365.WebSync.DAL;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Addon365.Models.Leads;
using Addon365.Models;

namespace Addon365.WebSync
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SyncAppContext>();
                    Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }
        private static void Initialize(SyncAppContext context)
        {
            if (context.Database.EnsureCreated())
            {

                User[] userEntries = new User[]
                {
                new User{UserId=Guid.NewGuid(),LoginId="tamil",UserName="Tamil Selvan",Password="pass123"},
                new User
                {
                    UserId=Guid.NewGuid(),
                    LoginId="udayan",
                    UserName="udhayan",
                    Password="pass123"
                }
                };
                context.Users.AddRange(userEntries);
                context.HistoryMasters.AddRange(LeadStatusHistoryMaster.GetMasterData());
                context.Users.AddRange(userEntries);
                context.LeadSources.AddRange(LeadSource.GetMasterData());

                context.SaveChanges();
            }
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
