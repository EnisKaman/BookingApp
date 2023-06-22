namespace BookingSystem.Infrastructure.Data.Configurations
{
    using BookingSystem.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class PictureEntityConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasOne(p => p.Room)
                 .WithMany(r => r.Pictures)
                 .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Hotel)
                .WithMany(h => h.Pictures)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Camping)
                .WithMany(p => p.Pictures)
                .OnDelete(DeleteBehavior.NoAction);
            ICollection<Picture> pictures = CreatePictures();
        }

        private ICollection<Picture> CreatePictures()
        {
            List<Picture> pictures = new List<Picture>()
            {
                new Picture()
                {
                    Id = 1,
                    HotelId = 1,
                    Path = "/img/Hotels/Spa Hotel Dvoretsa.jpg"
                },
                new Picture()
                {
                    Id = 2,
                    HotelId = 1,
                    Path = "/img/Hotels/Spa Hotel Dvoretsa2.jpg"
                },
                new Picture()
                {
                    Id = 3,
                    HotelId = 1,
                    Path = "/img/Hotels/Spa Hotel Dvoretsa3.jpg"
                },
                new Picture()
                {
                    Id = 4,
                    HotelId = 1,
                    Path = "/img/Hotels/Spa Hotel Dvoretsa4.jpg"
                },
                new Picture()
                {
                    Id = 5,
                    RoomId = 1,
                    Path = "/img/Rooms/Spa Hotel Dvorestsa SingleRoom.jpg",
                },
                new Picture()
                {
                    Id = 6,
                    RoomId = 1,
                    Path = "/img/Rooms/Spa Hotel Dvorestsa SingleRoom2.jpg",
                },
                new Picture()
                {
                    Id = 7,
                    RoomId = 2,
                    Path = "/img/Rooms/Spa Hotel Dvoretsa Double Bed.jpg",
                },
                new Picture()
                {
                    Id = 8,
                    RoomId = 2,
                    Path = "/img/Rooms/Spa Hotel Dvoretsa Double Bed2.jpg",
                },
                new Picture()
                {
                    Id = 9,
                    RoomId = 3,
                    Path = "/img/Rooms/Spa Hotel Dvoretsa Apartment.jpg"
                },
                 new Picture()
                 {
                    Id = 9,
                    RoomId = 3,
                    Path = "/img/Rooms/Spa Hotel Dvoretsa Apartment2.jpg",
                 },
                 new Picture()
                 {
                     Id = 10,
                     HotelId = 2,
                     Path = "/img/Hotels/Spa Hotel Infinity.jpg"
                 },
                 new Picture()
                 {
                     Id = 11,
                     HotelId = 2,
                     Path = "/img/Hotels/Spa Hotel Infinity2.jpg"
                 },
                 new Picture()
                 {
                     Id = 12,
                     HotelId = 2,
                     Path = "/img/Hotels/Spa Hotel Infinity3.jpg"
                 },
                 new Picture()
                 {
                     Id = 13,
                     RoomId = 4,
                     Path = "/img/Rooms/Infinity single room1.webp"
                 },
                 new Picture()
                 {
                     Id = 14,
                     RoomId = 4,
                     Path = "/img/Rooms/Infinity single room2.webp"
                 },
                 new Picture()
                 {
                     Id = 15,
                     RoomId = 4,
                     Path = "/img/Rooms/Infinity single room3.webp"
                 },
                 new Picture()
                 {
                     Id = 16,
                     RoomId = 5,
                     Path = "/img/Rooms/Infinity single room3.webp"
                 }
            };
            return pictures;
        }
    }
}
