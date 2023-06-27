namespace BookingSystem.Core.Contracts
{
    using BookingSystem.Core.Models.Picture;
    using Core.Models.Hotel;

    public interface IHotelService
    {
        Task<IEnumerable<HotelCardViewModel>> GetTopHotelsAsync();
    }
}
