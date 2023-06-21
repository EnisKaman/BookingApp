namespace BookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.HotelEntity;
    public class Hotel
    {
        public Hotel()
        {
            Rooms = new List<Room>();
            Pictures = new List<Picture>();
            HotelBenefits = new List<HotelBenefits>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxCountryValue)]
        public string Country { get; set; } = null!;
        public int StarRating { get; set; }
        [Required]
        [MaxLength(MaxHotelNameValue)]
        public string Name { get; set; } = null!;

        [MaxLength(MaxDescriptionValue)]
        public string? Description { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [MaxLength(MaxCityValue)]
        public string City { get; set; } = null!;
        public bool IsFavorite { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<HotelBenefits> HotelBenefits { get; set; }
    }
}
