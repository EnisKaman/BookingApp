namespace BookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidation.ReservationEntity;
    public class Reservation
    {
        public Reservation()
        {
            RentCarReservations = new List<RentCarReservations>();
            RoomReservations = new List<RoomReservations>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Room))]
         public ICollection<RoomReservations> RoomReservations { get; set; }
        public int CountNights { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public int PeopleCount { get; set; }
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
        public ICollection<RentCarReservations> RentCarReservations { get; set; }
        [NotMapped]
        public decimal TotalPrice { get; set; }
    }
}

