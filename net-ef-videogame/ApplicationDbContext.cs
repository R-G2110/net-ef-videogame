using Microsoft.EntityFrameworkCore;

namespace net_ef_videogame
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Videogame> Videogames { get; set; }
        public DbSet<SoftwareHouse> SoftwareHouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Videogame>()
                .HasOne(v => v.SoftwareHouse)  
                .WithMany(s => s.Videogames)   
                .HasForeignKey(v => v.SoftwareHouseId);  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db_net_ef_videogame2;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
