namespace BookingSystem.Core.Contracts
{
    using Core.Models.Hotel;

    public interface IHotelService
    {
        Task<IEnumerable<HotelCardViewModel>> GetAllAsync();
    }
}
