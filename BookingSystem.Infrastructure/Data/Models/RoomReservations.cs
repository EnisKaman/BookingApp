namespace BookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class RoomReservations
    {
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;
    }
}
