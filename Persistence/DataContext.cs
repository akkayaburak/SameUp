using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MachineCategory> MachineCategories { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineBrand> MachineBrands { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MachineType>()
                .HasOne(x => x.MachineCategory)
                .WithMany(x => x.MachineTypes)
                .HasForeignKey(x => x.MachineCategoryId);

            builder.Entity<MachineBrand>()
                .HasOne(x => x.MachineCategory)
                .WithMany(x => x.MachineBrands)
                .HasForeignKey(x => x.MachineCategoryId);

            builder.Entity<Attachment>()
                .HasOne(x => x.MachineType)
                .WithMany(x => x.Attachments)
                .HasForeignKey(x => x.MachineTypeId);

            builder.Entity<Machine>()
                .HasOne(x => x.MachineBrand)
                .WithMany(x => x.Machines)
                .HasForeignKey(x => x.MachineBrandId);

            builder.Entity<Machine>()
                .HasOne(x => x.MachineType)
                .WithMany(x => x.Machines)
                .HasForeignKey(x => x.MachineTypeId);
        }
    }
}