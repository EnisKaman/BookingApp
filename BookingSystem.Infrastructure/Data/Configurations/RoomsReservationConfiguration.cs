namespace BookingSystem.Infrastructure.Data.Configurations
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoomsReservationConfiguration : IEntityTypeConfiguration<RoomReservations>
    {
        public void Configure(EntityTypeBuilder<RoomReservations> builder)
        {
            builder.HasKey(ck => new { ck.RoomId, ck.ReservationId });

            builder.HasOne(roomreserv => roomreserv.Reservation)
                  .WithMany(r => r.RoomReservations)
                  .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(roomreserv => roomreserv.Room)
                .WithMany(r => r.RoomReservations)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
