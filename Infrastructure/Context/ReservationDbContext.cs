using Domain.Entities;
using Domain.Entities.Reservation;
using Domain.Entities.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Context
{
    public class ReservationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ReservationDbContext(IConfiguration configuration,
                DbContextOptions<ReservationDbContext> options) : base(options)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Buisness> Buisness { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceSetting> ServiceSettings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
