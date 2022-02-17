using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Infrastructure.Data;

[assembly: HostingStartup(typeof(RecruitmentSystem.UI.Areas.Identity.IdentityHostingStartup))]
namespace RecruitmentSystem.UI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}