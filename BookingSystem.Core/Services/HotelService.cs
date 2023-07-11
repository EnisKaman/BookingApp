namespace BookingSystem.Core.Services
{
    using Core.Models.Hotel;
    using Core.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookingSystemProject.Data;
    using Microsoft.EntityFrameworkCore;
    using Core.Models.Picture;
    using System;
    using BookingSystem.Infrastructure.Data.Models;
    using BookingSystem.Core.Models.Beefit;
    using BookingSystem.Core.Models.Comment;

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
        public async Task<IEnumerable<HotelViewModel>> GetAllHotelsAsync(Guid userId)
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
                      PicturePath = h.Pictures.First().Path,
                      IsFavorite = h.FavoriteHotels.Any(fv => fv.HotelId == h.Id && fv.UserId == userId)
                  }).ToArrayAsync();
            return hotels;
        }

        public async Task<bool> IsExist(int hotelId)
        {
            return await bookingContext.Hotels
                  .AnyAsync(rc => rc.Id == hotelId);
        }

        public async Task AddHotelToUserFavoriteHotels(int hotelId, Guid userId)
        {
            FavoriteHotel favoriteHotel = new FavoriteHotel()
            {
                HotelId = hotelId,
                UserId = userId
            };
            await bookingContext.FavoriteHotels.AddAsync(favoriteHotel);
            await bookingContext.SaveChangesAsync();
        }

        public async Task RemoveHotelFromUserFavoriteHotels(int hotelId, Guid userId)
        {
            FavoriteHotel favoriteHotelToRemove = await bookingContext
                .FavoriteHotels.FirstAsync(fh => fh.UserId == userId && fh.HotelId == hotelId);
            bookingContext.FavoriteHotels.Remove(favoriteHotelToRemove);
            await bookingContext.SaveChangesAsync();
        }

        public async Task<HotelInfoViewModel> GetHotelByIdAsync(int hotelId)
        {
            HotelInfoViewModel hotel = await bookingContext
                 .Hotels
                 .Select(h => new HotelInfoViewModel()
                 {
                     Id = h.Id,
                     City = h.City,
                     Country = h.Country,
                     Name = h.Name,
                     Description = h.Description,
                     StarRating = h.StarRating,
                     Benefits = h.HotelBenefits.Where(b => b.HotelId == hotelId).Select(b => new BenefitViewModel()
                     {
                         Name = b.Benefit.Name,
                         BenefitIcon = b.Benefit.ClassIcon
                     }).ToArray(),
                     Pictures = h.Pictures.Select(p => new PictureViewModel() { Path = p.Path }).ToArray(),
                     Comments = h.Comments.Select(c => new CommentViewModel()
                     {
                         CreatedOn = c.CreatedDate,
                         Description = c.Description,
                         UserName = c.UserName
                         //UserPicturePath = c.User.PicturePath

                     })
                 }).FirstAsync(h => h.Id == hotelId);
            return hotel;

        }
    }
}
