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
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        public Hotel? Hotel { get; set; }
        [ForeignKey(nameof(Camping))]
        public int? CampingId { get; set; }
        public Camping? Camping { get; set; }
        public int CountNights { get; set; }
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
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        [NotMapped]
        public decimal TotalPrice
        {
            get
            {
                if (Room != null)
                {
                    if (Cars.Any())
                    {
                        decimal carsSum = Cars.Sum(c => c.PricePerDay) * CountNights;
                        return carsSum + (CountNights * Room.PricePerNight);
                    }
                    return CountNights * Room.PricePerNight;
                }
                else
                {
                    if (Camping != null)
                    {
                        if (Cars.Any())
                        {
                            decimal carsSum = Cars.Sum(c => c.PricePerDay) * CountNights;
                            return carsSum + (CountNights * Camping.PricePerNight);
                        }
                        return CountNights * Camping.PricePerNight;
                    }
                    else
                    {
                        if (Cars.Any())
                        {
                            decimal carsSum = Cars.Sum(c => c.PricePerDay) * CountNights;
                            return carsSum;
                        }
                        return 0;
                    }
                }
            }
        }
    }
}

