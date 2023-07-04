namespace BookingSystem.Core.Models.Reservation
{
    using Core.Models.Car;
    using Core.Models.User;

    public class RentCarReservationViewModel
    {
        public UserViewModel User { get; set; }
        public CarViewModel CarlViewModel { get; set; } = null!;
        public DateTime StartRentDate { get; set; }
        public DateTime EndRentDate { get; set; }
    }
}
