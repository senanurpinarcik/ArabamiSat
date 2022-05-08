using ArabamiSatWeb.Models.Araba;
using ArabamiSatWeb.Models.Parametre;
using Microsoft.EntityFrameworkCore;

namespace ArabamiSatWeb.Models.Base
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Araba.Araba> Araba { get; set; }
        public DbSet<Kullanici.Kullanici> Kullanici { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<MarkaModel> MarkaModel { get; set; }
        public DbSet<ArabaYorum> ArabaYorum { get; set; } 
    }
}
