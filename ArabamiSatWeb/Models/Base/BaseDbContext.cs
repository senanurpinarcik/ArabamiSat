using Microsoft.EntityFrameworkCore;

namespace ArabamiSatWeb.Models.Base
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        { }
        public DbSet<Araba> Araba { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<MarkaModel> MarkaModel { get; set; }
        public DbSet<ArabaYorum> ArabaYorum { get; set; }
        public DbSet<UploadImageViewModel> UploadImageViewModel { get; set; }
    }
}
