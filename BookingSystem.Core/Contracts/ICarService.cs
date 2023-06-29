namespace BookingSystem.Core.Contracts
{
    using Core.Models.Car;
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAllAsync(string sortOption);
    }
}
