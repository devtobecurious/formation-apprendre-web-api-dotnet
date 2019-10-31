using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0041_First_Application.Models.Data
{
    public static class SeedData
    {
        public static void Seed(this IHost host)
        {
            try
            {
                using var scope = host.Services.CreateScope();

                var context = scope.ServiceProvider.GetService<Models.Contexts.DefaultContext>();

                context.Wookies.Add(new Wookie("Chewie", WarriorType.Chief));
                context.Wookies.Add(new Wookie("Chewie 2", WarriorType.Gun));

                context.SaveChanges();
            }
            catch (Exception)
            {
            }
            
        }
    }
}
