namespace BookingSystem.Core.Models.Reservation
{
    using Core.Models.Car;
    using Core.Models.User;
    using System.ComponentModel.DataAnnotations;

    public class RentCarReservationViewModel: IValidatableObject
    {
        public UserViewModel User { get; set; } = null!;
        public CarViewModel? CarlViewModel { get; set; }
        public DateTime StartRentDate { get; set; }
        public DateTime EndRentDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartRentDate >= EndRentDate)
            {
                yield return new ValidationResult("Start Rent Date must be before End Rent Date",
                    new[] { nameof(StartRentDate), nameof(EndRentDate) });
            }
        }
    }
}
