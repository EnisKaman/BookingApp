namespace BookingSystem.Controllers
{
    using BookingSystem.Core.Contracts;
    using Microsoft.AspNetCore.Mvc;
    public class HotelController : Controller
    {
        private readonly IHotelService hotelService;
        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        public IActionResult All()
        {
            return View();
        }
    }
}
