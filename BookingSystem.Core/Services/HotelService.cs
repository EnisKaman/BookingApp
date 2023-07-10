namespace BookingSystem.Core.Services
{
    using Core.Models.Hotel;
    using Core.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookingSystemProject.Data;
    using Microsoft.EntityFrameworkCore;
    using Core.Models.Picture;

    public class HotelService : IHotelService
    {
        private readonly BookingContext bookingContext;
        public HotelService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<HotelCardViewModel>> GetTopHotelsAsync()
        {
            IEnumerable<HotelCardViewModel> hotels = await bookingContext.Hotels.
                Include(h => h.Reservations).
                OrderByDescending(h => h.Reservations.Count)
                .ThenByDescending(h => h.StarRating)
                 .Select(h => new HotelCardViewModel()
                 {
                     Id = h.Id,
                     Name = h.Name,
                     Country = h.Country,
                     City = h.City,
                     Stars = h.StarRating,
                     Pictures = h.Pictures.Select(p => new PictureViewModel()
                     {
                         Path = p.Path,
                     }).ToList()
                 })

                 .Take(4)
                 .ToListAsync();

            return hotels;
        }
        public async Task<IEnumerable<HotelViewModel>> GetAllHotelsAsync()
        {
            IEnumerable<HotelViewModel> hotels = await bookingContext.Hotels
                  .Where(h => !h.IsDeleted)
                  .Select(h => new HotelViewModel()
                  {
                      Id = h.Id,
                      Name = h.Name,
                      StarRating = h.StarRating,
                      City = h.City,
                      Country = h.Country,
                      PicturePath = h.Pictures.First().Path
                  }).ToArrayAsync();
            return hotels;
        }

        public async Task<bool> IsExist(int hotelId)
        {
            return await bookingContext.Hotels
                  .AnyAsync(rc => rc.Id == hotelId);
        }
    }
}
