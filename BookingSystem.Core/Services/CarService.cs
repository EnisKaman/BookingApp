namespace BookingSystem.Core.Services
{
    using BookingSystem.Core.Models.Car.Enums;
    using BookingSystem.Core.Models.Page;
    using BookingSystem.Infrastructure.Data.enums;
    using BookingSystem.Infrastructure.Data.Models;
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
                      TransmissionType = rc.TransmissionType == TransmissionType.AutomaticTransmission ? "Automatic Transmission" : "Manual Transmission"
                  })
                .FirstAsync(c => c.Id == carId);
            return carToFind;
        }

        public async Task<IEnumerable<CarBrandViewModel>> GetCarsByBrandAsync(string brand, int carId)
        {
            brand = brand.ToLower();
            IEnumerable<CarBrandViewModel> cars = await bookingContext.RentCars
                .Where(rc => rc.MakeType.ToLower() == brand && rc.Id != carId && !rc.IsDeleted)
                .Select(rc => new CarBrandViewModel()
                {
                    Id = rc.Id,
                    MakeType = rc.MakeType,
                    Model = rc.ModelType,
                    CarImg = rc.CarImg
                }).ToArrayAsync();
            return cars;
        }

        public async Task<CarViewModel> GetOrderCarAsync(int carId)
        {
            CarViewModel carToGet = await bookingContext.RentCars
                 .Select(rc => new CarViewModel()
                 {
                     Id = rc.Id,
                     CarImg = rc.CarImg,
                     Location = rc.Location,
                     MakeType = rc.MakeType,
                     Model = rc.ModelType,
                     PricePerDay = rc.PricePerDay,
                     Year = rc.Year
                 }).FirstAsync(rc => rc.Id == carId);
            return carToGet;
        }

        public async Task<AllCarsSortedAndFilteredDataModel> AllCarsSortedAndFilteredDataModelAsync(CarQuerViewModel carQuerViewModel)
        {
            IQueryable<RentCar> cars = bookingContext.RentCars.AsQueryable();
            if (carQuerViewModel.CarSortOption == CarSortOption.YearAscending)
            {
                cars = cars.OrderBy(rc => rc.Year);
            }
            else if (carQuerViewModel.CarSortOption == CarSortOption.YearDescending)
            {
                cars = cars.OrderByDescending(rc => rc.Year);
            }
            else if (carQuerViewModel.CarSortOption == CarSortOption.PriceAscending)
            {
                cars = cars.OrderBy(rc => rc.PricePerDay);
            }
            else if (carQuerViewModel.CarSortOption == CarSortOption.PriceDescending)
            {
                cars = cars.OrderByDescending(rc => rc.PricePerDay);
            }
            else if (carQuerViewModel.CarSortOption == CarSortOption.MakeTypeAscending)
            {
                cars = cars.OrderBy(rc => rc.MakeType);
            }
            else if (carQuerViewModel.CarSortOption == CarSortOption.MakeTypeDescending)
            {
                cars = cars.OrderByDescending(rc => rc.MakeType);
            }
            else
            {
                cars = cars.OrderBy(rc => rc.Id);
            }
            int recordsToSkip = (carQuerViewModel.Pager.CurrentPage - 1) * carQuerViewModel.Pager.PageSize;
            IEnumerable<CarViewModel> carViewModels = await cars
                .Skip(recordsToSkip).Take(carQuerViewModel.Pager.PageSize)
                .Select(rc => new CarViewModel()
                {
                    Id = rc.Id,
                    CarImg = rc.CarImg,
                    Location = rc.Location,
                    MakeType = rc.MakeType,
                    Model = rc.ModelType,
                    PricePerDay = rc.PricePerDay,
                    Year = rc.Year

                }).ToArrayAsync();
            return new AllCarsSortedAndFilteredDataModel()
            {
                Cars = carViewModels
            };
        }

        public async Task<int> GetCarsCountAsync()
        {
           return await bookingContext.RentCars.CountAsync();
        }
    }
}
