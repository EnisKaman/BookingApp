namespace BookingSystem.Core.Contracts
{
    using Models.Car;
    public interface ICarService
    {
        Task<AllCarsSortedAndFilteredDataModel> AllCarsSortedAndFilteredDataModelAsync(CarQuerViewModel carQuerViewModel);
        Task<bool> IsCarExistAsync(int carId);
        Task<CarDetailsViewModel> FindCarByIdAsync(int carId);
        Task<IEnumerable<CarBrandViewModel>> GetCarsByBrandAsync(string brand, int carId);
        Task<CarViewModel> GetOrderCarAsync(int carId);
        Task<int> GetCarsCountAsync(CarQuerViewModel carQuerViewModel);
        Task<IEnumerable<string>> GetAllBrandsAsync();
    }
}
