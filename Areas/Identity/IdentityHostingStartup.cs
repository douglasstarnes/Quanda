using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quanda.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Quanda.Areas.Identity.IdentityHostingStartup))]
namespace Quanda.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<QuandaIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("QuandaIdentityDbContextConnection")));

                services.AddDefaultIdentity<Author>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<QuandaIdentityDbContext>();
            });
        }
    }
}