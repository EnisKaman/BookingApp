namespace BookingSystem.Core.Services
{
    using BookingSystem.Infrastructure.Data.enums;
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

        public async Task<IEnumerable<CarAllViewModel>> GetAllAsync(string sortOption)
        {
            IEnumerable<CarAllViewModel> cars;
            if (sortOption == "year")
            {
                cars = await bookingContext.RentCars
                    .OrderByDescending(rc => rc.Year)
                    .Select(rc => new CarAllViewModel()
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
                    .Select(rc => new CarAllViewModel()
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
            else if (sortOption == "make type")
            {
                cars = await bookingContext.RentCars
                  .OrderBy(rc => rc.MakeType)
                  .Select(rc => new CarAllViewModel()
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
                   .Select(rc => new CarAllViewModel()
                   {
                       Id = rc.Id,
                       Model = rc.ModelType,
                       MakeType = rc.MakeType,
                       PricePerDay = rc.PricePerDay,
                       CarImg = rc.CarImg,
                       Location = rc.Location,
                       Year = rc.Year
                   })
                   .OrderBy(c => c.Id)
                   .ToArrayAsync();
            }
            return cars;
        }

        public async Task<bool> IsCarExistAsync(int carId)
        {
            return await bookingContext.RentCars.AnyAsync(c => !c.IsDeleted && c.Id == carId);
        }
        public async Task<CarDetailsViewModel> FindCarByIdAsync(int carId)
        {
            CarDetailsViewModel carToFind = await bookingContext.RentCars
                  .Select(rc => new CarDetailsViewModel()
                  {
                      Id = rc.Id,
                      MakeType = rc.MakeType,
                      Model = rc.ModelType,
                      PeopleCapacity = rc.PeopleCapacity,
                      Location = rc.Location,
                      Longitude = rc.Longitude,
                      Latitude = rc.Lattitude,
                      CarImg = rc.CarImg,
                      DoorsCount = rc.DoorsCount,
                      FuelCapacity = rc.FuelCapacity,
                      FuelConsumption = rc.FuelConsumption,
                      PricePerDay = rc.PricePerDay,
                      Year = rc.Year,
                      TransmissionType = rc.TransmissionType == TransmissionType.AutomaticTransmission ?"Automatic Transmission" : "Manual Transmission"
                  })
                .FirstAsync(c => c.Id == carId);
             return carToFind;
        }

        public async Task<IEnumerable<CarBrandViewModel>> GetCarsByBrandAsync(string brand, int carId)
        {
            brand = brand.ToLower();
            IEnumerable<CarBrandViewModel> cars = await bookingContext.RentCars
                .Where(rc => rc.MakeType.ToLower() == brand && rc.Id!=carId &&!rc.IsDeleted)
                .Select(rc => new CarBrandViewModel()
                {
                    Id = rc.Id,
                    MakeType = rc.MakeType,
                    Model = rc.ModelType,
                    CarImg = rc.CarImg
                }).ToArrayAsync();
            return cars;
        }
    }
}
