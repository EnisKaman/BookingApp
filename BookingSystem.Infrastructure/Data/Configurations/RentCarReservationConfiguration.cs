namespace BookingSystem.Infrastructure.Data.Configurations
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class RentCarReservationConfiguration : IEntityTypeConfiguration<RentCarReservations>
    {
        public void Configure(EntityTypeBuilder<RentCarReservations> builder)
        {
            builder.HasKey(ck => new { ck.RentCarId, ck.ReservationId });

            builder.HasOne(cr => cr.RentCar)
                .WithMany(rc => rc.RentCarReservations)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(cr => cr.Reservation)
                .WithMany(r => r.RentCarReservations)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
