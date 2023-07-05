using BookingSystem.Core.Models.Reservation;

namespace BookingSystem.Core.Contracts
{
    public interface IReservationService
    {
        public Task<bool> CheckCarIsAlreadyReservedAsync(int carId, DateTime startDate, DateTime endDate);
        public Task RentCarAsync(int carId, RentCarReservationViewModel model);
    }
}
