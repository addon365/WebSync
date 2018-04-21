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
            context.Database.EnsureCreated();
            if (context.Users.Any())
                return;

            User[] userEntries = new User[]
            {
                new User
                {
                    Id=Guid.NewGuid(),
                    UserName="Tamil",
                    Password="pass123"
                },
                new User
                {
                    Id=Guid.NewGuid(),
                    UserName="udhayan",
                    Password="pass123"
                }
            };
            context.Users.AddRange(userEntries);
            
            #region Lead Data
            Lead[] leads = new Lead[]
            {
                new Lead
                {
                    Id=Guid.NewGuid(),
                    Profile=new Profile
                    {
                        Id = Guid.NewGuid(),
                        Name = "Rahul",
                        MobileNumer = "9999999999"
                    },
                    Source=new LeadSourceMaster
                    {
                        Id=Guid.NewGuid(),
                        Code="JD",
                        Name="Just Dial"
                    }
                },
                 new Lead
                {
                    Id=Guid.NewGuid(),
                    Profile=new Profile
                    {
                        Id = Guid.NewGuid(),
                        Name = "Ravi",
                        MobileNumer = "8888888888"
                    },
                    Source=new LeadSourceMaster
                    {
                        Id=Guid.NewGuid(),
                        Code="JD",
                        Name="Just Dial"
                    }
                }
            };

            #endregion


            context.SaveChanges();
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
