using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_test.Data;
using System;
using System.Linq;
namespace MVC_test.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVC_testContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MVC_testContext>>()))
            {
                // Look for any movies.
                if (context.Mice.Any())
                {
                    return;   // DB has been seeded
                }

                context.Mice.AddRange(
                    new Mice
                    {
                        Name = "Superlight g pro wireless",
                        ReleaseDate = DateTime.Parse("2021-11-1"),
                        Price = 700,
                        Rating = 80,
                        Company = "Logitech"
                    },
                    new Mice
                    {
                        Name = "FinalMouse Starlight-12",
                        ReleaseDate = DateTime.Parse("2012-4-14"),
                        Price = 1432,
                        Rating = 70,
                        Company = "FinalMouse"

                    }

                );
                context.SaveChanges();
            }
        }
    }
}
