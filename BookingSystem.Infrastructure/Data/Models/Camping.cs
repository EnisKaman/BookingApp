namespace BookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.CampingEntity;
    public class Camping
    {
        public Camping()
        {
            Benefits = new List<Benefit>();
            Pictures = new List<Picture>();
        }
        [Key]
        public int Id { get; init; }
        public decimal Longitude { get;set; }
        public decimal Latitude { get;set; }
        [Required]
        [MaxLength(MaxCampingNameValue)]
        public string Name { get; set; } = null!;
        [MaxLength(MaxCityValue)]
        public string? City { get; set; }
        [Required]
        [MaxLength(MaxCountryValue)]
        public string Country { get; set; } = null!;
        [Required]
        [MaxLength(MaxDescriptionValue)]
        public string Description { get; set; } = null!;
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public ICollection<Benefit> Benefits { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public bool IsFavorite { get; set; }
       
    }
}
