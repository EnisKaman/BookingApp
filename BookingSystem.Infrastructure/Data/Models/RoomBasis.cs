namespace BookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class RoomBasis
    {
        [Key]
        public int Id { get; init; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string ClassIcon { get; set; } = null!;
    }
}
