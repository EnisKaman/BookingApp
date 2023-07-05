namespace BookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class RentCarReservations
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;
        public int RentCarId { get; set; }
        public RentCar RentCar { get; set; } = null!;
    }
}
