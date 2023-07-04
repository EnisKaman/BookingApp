namespace BookingSystem.Core.Contracts
{
    using Models.Car;
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAllAsync(string sortOption);
        Task<bool> IsCarExistAsync(int carId);
        Task<CarDetailsViewModel> FindCarByIdAsync(int carId);
        Task<IEnumerable<CarBrandViewModel>> GetCarsByBrandAsync(string brand, int carId);
        Task<CarViewModel> GetOrderCarAsync(int carId);
    }
}
