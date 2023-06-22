namespace BookingSystem.Infrastructure.Data.Configurations
{
    using BookingSystem.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoomEntityConfiguration : IEntityTypeConfiguration<Room>
    {
        private readonly ICollection<RoomType> roomTypes;
        public RoomEntityConfiguration(ICollection<RoomType> roomTypes)
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
                   RoomBases = AddRoomBases(1, new int[]{1, 2, 3, 5})
               },
               new Room()
               {
                   Id = 2,
                   RoomTypeId = 3,
                   PricePerNight = 190 + (190 * roomTypes.FirstOrDefault(r => r.Id == 2)?.IncreasePercentage ?? 0)/100,
                   HotelId = 1,
                   Capacity = 4,
                   RoomBases = AddRoomBases(2, new int[]{1, 2, 3, 5})
               },
               new Room()
               {
                   Id = 3,
                   RoomTypeId = 1,
                   PricePerNight = 190 + (190 * roomTypes.FirstOrDefault(r => r.Id == 1)?.IncreasePercentage ?? 0)/100,
                   Capacity = 5,
                   HotelId = 1,
                   RoomBases = AddRoomBases(3, new int[]{1, 2, 3, 4, 5})
               },
               new Room()
               {
                   Id = 4,
                   HotelId = 2,
                   RoomTypeId = 5,
                   PricePerNight = 200 + (200 * roomTypes.FirstOrDefault(rt => rt.Id == 5)?.IncreasePercentage ?? 0)/ 100,
                   Capacity = 2,
                   RoomBases = AddRoomBases(4, new int[]{1, 2, 3, 4, 5, 7})
               },
               new Room()
               {
                   Id = 5,
                   HotelId = 2,
                   RoomTypeId = 3,
                   PricePerNight = 200 + (200 * roomTypes.FirstOrDefault(rt => rt.Id == 3)?.IncreasePercentage ?? 0)/ 100,
                   Capacity = 4,
                   RoomBases = AddRoomBases(5, new int[]{1, 2, 3, 4, 5, 7})
               },
               new Room()
               {
                   Id = 6,
                   HotelId = 2,
                   RoomTypeId = 1,
                   PricePerNight = 200 + (200 * roomTypes.FirstOrDefault(rt => rt.Id == 1)?.IncreasePercentage ?? 0)/ 100,
                   Capacity = 4,
                   RoomBases = AddRoomBases(6, new int[]{1, 2, 3, 4, 5, 6, 7})
               },
               new Room()
               {
                   Id = 7,
                   HotelId = 2,
                   RoomTypeId = 4,
                   PricePerNight = 200 + (200 * roomTypes.FirstOrDefault(rt => rt.Id == 4)?.IncreasePercentage ?? 0)/ 100,
                   Capacity = 6,
                   RoomBases = AddRoomBases(7, new int[]{1, 2, 3, 4, 5, 6, 7})
               }

            };
            return rooms;
        }
        private ICollection<RoomsBases> AddRoomBases(int roomId, int[] roombaseIds)
        {
            ICollection<RoomsBases> roomsBases = new List<RoomsBases>();
            for (int i = 0; i < roombaseIds.Length; i++)
            {
                roomsBases.Add(new RoomsBases() { RoomId = roomId, RoomBasisId = roombaseIds[i] });
            }
            return roomsBases;
        }
    }
}
