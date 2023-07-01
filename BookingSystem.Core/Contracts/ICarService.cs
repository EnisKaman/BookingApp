namespace BookingSystem.Core.Contracts
{
    using Core.Models.Car;
    public interface ICarService
    {
        Task<IEnumerable<CarAllViewModel>> GetAllAsync(string sortOption);
        Task<bool> IsCarExistAsync(int carId);
        Task<CarDetailsViewModel> FindCarByIdAsync(int carId);
    }
}
