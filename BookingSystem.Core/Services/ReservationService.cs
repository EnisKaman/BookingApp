namespace BookingSystem.Core.Services
{
    using BookingSystem.Core.Contracts;
    using BookingSystem.Core.Models.Reservation;
    using BookingSystem.Infrastructure.Data.Models;
    using BookingSystemProject.Data;
    using Microsoft.EntityFrameworkCore;

    public class ReservationService : IReservationService
    {
        private readonly BookingContext bookingContext;
        public ReservationService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<bool> CheckCarIsAlreadyReservedAsync(int carId, DateTime startDate, DateTime endDate)
        {
            RentCar carToFind = await bookingContext.RentCars
                .Include(rc => rc.Reservations)
                .FirstAsync(rc => rc.Id == carId);
            return carToFind.Reservations.Any(r => r.StartDate <= startDate && r.EndDate >= endDate 
            || (r.StartDate >=startDate && r.EndDate <=endDate) ||r.EndDate == startDate);
        }

        public async Task RentCarAsync(int carId, RentCarReservationViewModel model)
        {
            RentCar carToRent = await bookingContext.RentCars.FirstAsync(rc => rc.Id == carId);
            TimeSpan interval = model.EndRentDate.Subtract(model.StartRentDate);
            int countDays = (int)interval.TotalDays;
            Reservation reservation = new Reservation()
            {
                UserId = model.User.Id,
                EmailAddress = model.User.Email,
                StartDate = model.StartRentDate,
                EndDate = model.EndRentDate,
                FirstName = model.User.FirstName,
                LastName = model.User.LastName,
                CountNights = countDays,
                RentCarId = carId,
                TotalPrice = model.CarlViewModel.PricePerDay * countDays,
                PeopleCount = 1,
            };
            await bookingContext.Reservations.AddAsync(reservation);
            await bookingContext.SaveChangesAsync();
        }
    }
}
