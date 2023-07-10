namespace BookingSystem.Controllers
{
    using BookingSystem.Core.Contracts;
    using BookingSystem.Core.Models.Hotel;
    using BookingSystem.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using static Common.NotificationKeys;
    using static Common.NotificationMessages;
    public class HotelController : Controller
    {
        private readonly IHotelService hotelService;
        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<HotelViewModel> allHotels = await hotelService.GetAllHotelsAsync();
            return View(allHotels);
        }
        public async Task<IActionResult> AddToFavorite(int id)
        {
            Guid userId = User.GetId();
            if(!await hotelService.IsExist(id))
            {
                TempData[ErrorMessage] = HotelDoesNotExist;
                return RedirectToAction(nameof(All));
            }
            return View();
            
        }
    }
}
