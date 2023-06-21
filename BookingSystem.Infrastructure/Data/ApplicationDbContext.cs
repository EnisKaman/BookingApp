namespace BookingSystemProject.Data
{
    using BookingSystem.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class BookingContext : IdentityDbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomBasis> RoomBases { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Camping> Campings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RentCar> RentCars { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}