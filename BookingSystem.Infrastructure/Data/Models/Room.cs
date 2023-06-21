namespace BookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Room
    {
        public Room()
        {
            Pictures = new List<Picture>();
            IsAvalilable = true;
        }
        [Key]
        public int Id { get; init; }
        public int Capacity { get; init; }
        public bool IsAvalilable { get; set; }

        [ForeignKey(nameof(RoomType))]
        public int RoomTypeId { get; set; }
        [Required]
        public RoomType RoomType { get; set; } = null!;
        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;
        public decimal PricePerNight { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public DateTime? OccupyStartDate { get; set; }
        public DateTime? OccupyEndDate { get; set; }
    }
}