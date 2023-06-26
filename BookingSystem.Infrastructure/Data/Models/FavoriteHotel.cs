namespace BookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class FavoriteHotel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;
        [ForeignKey(nameof(User))]
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
