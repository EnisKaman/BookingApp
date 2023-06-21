namespace BookingSystem.Infrastructure.Data.Configurations
{
    using BookingSystem.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoomEntityConfiguration : IEntityTypeConfiguration<Room>
    {
        private readonly ICollection<RoomType> roomTypes;
        public  RoomEntityConfiguration(ICollection<RoomType> roomTypes)
        {
           this.roomTypes = roomTypes;
        }
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .OnDelete(DeleteBehavior.NoAction);
            ICollection<Room> rooms = CreateRooms();
            builder.HasData(rooms);
        }

        private ICollection<Room> CreateRooms()
        {
            List<Room> rooms = new List<Room>()
            {
               new Room()
               {
                   Id = 1,
                   RoomTypeId = 5,
                   PricePerNight = 190,
                   HotelId = 1,
                   Capacity = 2,
                   Pictures = new List<Picture>()
                   {
                       new Picture()
                       {
                           Id = 5
                       },
                       new Picture()
                       {
                           Id = 5
                       }
                   },
               },
               new Room()
               {
                   Id = 2,
                   RoomTypeId = 3,
                   PricePerNight = 190 + (190 * roomTypes.FirstOrDefault(r => r.Id == 2)?.IncreasePercentage ?? 0)/100,
                   HotelId = 1,
                   Capacity = 4,
                   Pictures = new List<Picture>()
                   {
                       new Picture()
                       {
                           Id = 7
                       },
                       new Picture()
                       {
                           Id = 8,
                       }
                   }
               },
               new Room()
               {
                   Id = 3,
                   RoomTypeId = 1,
                   PricePerNight = 190 + (190 * roomTypes.FirstOrDefault(r => r.Id == 1)?.IncreasePercentage ?? 0)/100,
                   Capacity = 5,
                   HotelId = 1,
                   Pictures = new List<Picture>()
                   {
                       new Picture()
                       {
                           Id = 9
                       },
                       new Picture()
                       {
                           Id = 10
                       }
                   }
               }
            };
            return rooms;
        }
    }
}
