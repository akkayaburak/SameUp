using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!context.MachineCategories.Any())
            {
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
                var machineBrands = new List<MachineBrand>()
                {
                    new MachineBrand
                    {
                        MachineCategory = machineCategories[0],
                        Name = "Hafriyat Brand",
                    },
                    new MachineBrand
                    {
                        MachineCategory = machineCategories[1],
                        Name = "Forklift Brand"
                    },
                    new MachineBrand
                    {
                        MachineCategory = machineCategories[2],
                        Name = "Asfalt Brand"
                    }
                };
                var machineTypes = new List<MachineType>()
                {
                    new MachineType
                    {
                        MachineCategory = machineCategories[0],
                        Name = "Hafriyat Machine Type",
                    },
                    new MachineType
                    {
                        MachineCategory = machineCategories[1],
                        Name = "Forklift MachineType"
                    },
                    new MachineType
                    {
                        MachineCategory = machineCategories[2],
                        Name = "Asfalt MachineCategory"
                    }
                };

                var attachments = new List<Attachment>()
                {
                    new Attachment
                    {
                        MachineType = machineTypes[0],
                        Name = "Hafriyat Attachment",
                    },
                    new Attachment
                    {
                        MachineType = machineTypes[1],
                        Name = "Forklift Attachment",
                    },
                    new Attachment
                    {
                        MachineType = machineTypes[2],
                        Name = "Asfalt Attachment"
                    }
                };

                var machines = new List<Machine>()
                {
                    new Machine
                    {
                        MachineBrand = machineBrands[0],
                        MachineType = machineTypes[0],
                        ModelName = "Hafriyat Machine",
                        YearOfProduction = DateTime.Now.Year
                    },
                    new Machine
                    {
                        MachineBrand = machineBrands[1],
                        MachineType = machineTypes[1],
                        ModelName = "Forklift Machine",
                        YearOfProduction = DateTime.Now.Year - 1
                    },
                    new Machine
                    {
                        MachineBrand = machineBrands[2],
                        MachineType = machineTypes[2],
                        ModelName = "Asfalt Machine",
                        YearOfProduction = DateTime.Now.Year - 2
                    }
                };
                machineCategories[0].MachineBrands = new List<MachineBrand>()
                {
                    machineBrands[0]
                };
                machineCategories[1].MachineBrands = new List<MachineBrand>()
                {
                    machineBrands[1]
                };
                machineCategories[2].MachineBrands = new List<MachineBrand>()
                {
                    machineBrands[2]
                };
                await context.MachineCategories.AddRangeAsync(machineCategories);
                await context.MachineBrands.AddRangeAsync(machineBrands);
                await context.MachineTypes.AddRangeAsync(machineTypes);
                await context.Attachments.AddRangeAsync(attachments);
                await context.Machines.AddRangeAsync(machines);

                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var user = new AppUser
                {
                    Email = "burak@test.com",
                    UserName  = "akkayaburak"
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await context.SaveChangesAsync();
            }
        }
    }
}