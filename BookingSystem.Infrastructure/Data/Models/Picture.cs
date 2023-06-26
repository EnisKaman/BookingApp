﻿namespace BookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Picture
    {
        public int Id { get; init; }

        [Required]
        public string Path { get; set; } = null!;
        [ForeignKey(nameof(Hotel))]
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        [ForeignKey(nameof(Room))]
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
    }
}