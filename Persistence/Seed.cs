using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if(context.MachineCategories.Any()) return;

            var machineCategories = new List<MachineCategory>()
            {
                new MachineCategory 
                {
                    Name = "Hafriyat Grubu"
                },
                new MachineCategory 
                {
                    Name = "Forklift ve İstifleyiciler"
                },
                new MachineCategory 
                {
                    Name = "Asfalt ve Yol Makinalari"
                },
            };

            await context.MachineCategories.AddRangeAsync(machineCategories);
            await context.SaveChangesAsync();
        }
    }
}