namespace BookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidation.ReservationEntity;
    public class Reservation
    {
        public Reservation()
        {
            Cars = new List<RentCar>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public Hotel Hotel { get; set; } = null!;
        public int CountNights { get; set; }
        public int PeopleCount { get; set; }
        [Required]
        public ICollection<RentCar> Cars { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        [MaxLength(UserFirstNameMaxValue)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(UserLastNameMaxValue)]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        [MaxLength(UserEmailAddressMaxValue)]
        public string EmailAddress { get; set; } = null!;
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        [NotMapped]
        public decimal TotalPrice
        {
            get
            {
                if (Cars.Any())
                {
                    decimal carsSum = Cars.Sum(c => c.PricePerDay) * CountNights;
                    return carsSum + (CountNights * Room.PricePerNight) + Room.Package.Price * PeopleCount;
                }
                return (CountNights * Room.PricePerNight) + Room.Package.Price * PeopleCount;
            }
        }
    }
}

