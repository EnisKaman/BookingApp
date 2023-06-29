
namespace BookingSystem.Core.Services
{
    using BookingSystemProject.Data;
    using Core.Contracts;
    using Core.Models.Car;
    using Microsoft.EntityFrameworkCore;

    public class CarService : ICarService
    {
        private readonly BookingContext bookingContext;
        public CarService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<IEnumerable<CarViewModel>> GetAllAsync(string sortOption)
        {
            IEnumerable<CarViewModel> cars;
            if (sortOption == "year")
            {
                cars = await bookingContext.RentCars
                    .OrderByDescending(rc => rc.Year)
                    .Select(rc => new CarViewModel()
                    {
                        Id = rc.Id,
                        Model = rc.ModelType,
                        MakeType = rc.MakeType,
                        PricePerDay = rc.PricePerDay,
                        CarImg = rc.CarImg,
                        Location = rc.Location,
                        Year = rc.Year
                    }).ToArrayAsync();
            }
            else if (sortOption == "price")
            {
                cars = await bookingContext.RentCars
                    .OrderBy(rc => rc.PricePerDay)
                    .Select(rc => new CarViewModel()
                    {
                        Id = rc.Id,
                        Model = rc.ModelType,
                        MakeType = rc.MakeType,
                        PricePerDay = rc.PricePerDay,
                        CarImg = rc.CarImg,
                        Location = rc.Location,
                        Year = rc.Year
                    }).ToArrayAsync();
            }
            else if(sortOption == "make type")
            {
                cars = await bookingContext.RentCars
                  .OrderBy(rc => rc.MakeType)
                  .Select(rc => new CarViewModel()
                  {
                      Id = rc.Id,
                      Model = rc.ModelType,
                      MakeType = rc.MakeType,
                      PricePerDay = rc.PricePerDay,
                      CarImg = rc.CarImg,
                      Location = rc.Location,
                      Year = rc.Year
                  }).ToArrayAsync();
            }
            else
            {
                cars = await bookingContext.RentCars
                   .Select(rc => new CarViewModel()
                   {
                       Id = rc.Id,
                       Model = rc.ModelType,
                       MakeType = rc.MakeType,
                       PricePerDay = rc.PricePerDay,
                       CarImg = rc.CarImg,
                       Location = rc.Location,
                       Year = rc.Year
                   }).ToArrayAsync();
            }
            return cars;
        }
    }
}
