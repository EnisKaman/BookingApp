﻿namespace BookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidation.RoomEntity;
    public class Room
    {
        public Room()
        {
            Pictures = new List<Picture>();
            RoomBases = new List<RoomsBases>();
            Reservations = new List<Reservation>();
            PackageId = 1;
        }
        [Key]
        public int Id { get; init; }
        public int Capacity { get; init; }
        [Required]
        [MaxLength(MaxDescriptionValue)]
        public string Description { get; set; } = null!;
        [ForeignKey(nameof(RoomType))]
        public int RoomTypeId { get; set; }
        [Required]
        public RoomType RoomType { get; set; } = null!;
        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;
        [ForeignKey(nameof(Package))]
        public int PackageId { get; set; }
        public RoomPackage Package { get; set; } = null!;
        public decimal PricePerNight { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<RoomsBases> RoomBases { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public bool IsDeleted { get; set; }
    }
}