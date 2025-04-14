
using HalfChessServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace HalfChessServer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HalfChessServerContext context)
        {
            //context.Database.Migrate();
            context.Database.EnsureCreated();

            // Look for any countries.
            if (context.Countries.Any())
            {
                return;   // DB has been seeded
            }

            var countries = new Country[]
            {
                new Country{Name="Canada",IsPlayer=false},
                new Country{Name="United States",IsPlayer=false},
                new Country{Name="India",IsPlayer=false},
                new Country{Name="Portugal",IsPlayer=false},
                new Country{Name="Indonesia",IsPlayer=false},
                new Country{Name="China",IsPlayer=false},
                new Country{Name="Russian",IsPlayer=false}
            };
            foreach (Country s in countries)
            {
                context.Countries.Add(s);
            }
            context.SaveChanges();

        }
    }
}
