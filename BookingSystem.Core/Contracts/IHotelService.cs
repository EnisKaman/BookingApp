namespace BookingSystem.Core.Contracts
{
    using Core.Models.Hotel;

    public interface IHotelService
    {
        Task<IEnumerable<HotelCardViewModel>> GetTopHotelsAsync();
        Task<IEnumerable<HotelViewModel>> GetAllHotelsAsync(Guid userId);
        Task<bool> IsExist(int hotelId);
        Task AddHotelToUserFavoriteHotels(int hotelId, Guid userId);
        Task RemoveHotelFromUserFavoriteHotels(int hotelId, Guid userId);
    }
}
