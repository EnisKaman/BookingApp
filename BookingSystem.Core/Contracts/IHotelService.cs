namespace BookingSystem.Core.Contracts
{
    using Core.Models.Hotel;

    public interface IHotelService
    {
        Task<IEnumerable<HotelCardViewModel>> GetTopHotelsAsync();
        Task<IEnumerable<HotelViewModel>> GetAllHotelsAsync();
        Task<bool> IsExist(int hotelId);
    }
}
