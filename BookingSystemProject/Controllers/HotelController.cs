namespace BookingSystem.Controllers
{
    using BookingSystem.Core.Contracts;
    using BookingSystem.Core.Models.Hotel;
    using Microsoft.AspNetCore.Mvc;
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
    }
}
