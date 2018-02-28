using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Addon365.WebSync.DAL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace Addon365.WebSync
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SyncAppContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddMvc();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "Google";
            })
               .AddCookie()
           .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration["Google:ClientId"];
                googleOptions.ClientSecret = Configuration["Google:ClientSecret"];
                googleOptions.CallbackPath = new PathString("/signin-github");
                googleOptions.AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/auth";
                googleOptions.TokenEndpoint = "https://accounts.google.com/o/oauth2/token";

            })
    .AddJwtBearer(jwtBearerOptions =>
    {
        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateActor = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["Issuer"],
            ValidAudience = Configuration["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SigningKey"]))
        };
    });
            services.AddTransient<IUrls, Urls>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse =
         r =>
         {
             string path = r.File.PhysicalPath;
             if (path.EndsWith(".css") || path.EndsWith(".js") || path.EndsWith(".gif") || path.EndsWith(".jpg") || path.EndsWith(".png") || path.EndsWith(".svg"))
             {
                 TimeSpan maxAge = new TimeSpan(7, 0, 0, 0);
                 r.Context.Response.Headers.Append("Cache-Control", "max-age=" + maxAge.TotalSeconds.ToString("0"));
             }
         }
            });

            app.UseAuthentication();

            app.UseMvc(

             routes =>
             {
                 routes.MapRoute(
                  "SeoRoute",
                  "{*permalink}",
                 defaults: new { controller = "Software", action = "Index" },
                 constraints: new { permalink = new CmsUrlConstraint(new Urls()) });

                 routes.MapRoute(
                     name: "default",
                     template: "{controller=Home}/{action=Index}/{id?}");
             }

             );
        }
    }

    public class CmsUrlConstraint : IRouteConstraint
    {
        private readonly IUrls _urls;
        public CmsUrlConstraint(IUrls urls)
        {
            _urls = urls;
        }
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var db = _urls.getUrls;
            if (values[routeKey] != null)
            {
                var permalink = values[routeKey].ToString().ToLower();
                var page = db.Where(p => p.Url == permalink).FirstOrDefault();
                if (page != null)
                {
                    httpContext.Items["cmspage"] = page;
                    return true;
                }
                return false;


            }
            return false;
        }


    }
}