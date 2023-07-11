namespace BookingSystem.Controllers
{
    using BookingSystem.Core.Contracts;
    using BookingSystem.Core.Models.Hotel;
    using BookingSystem.Extensions;
    using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            Guid userId = User.GetId();
            IEnumerable<HotelViewModel> allHotels = await hotelService.GetAllHotelsAsync(userId);
            return View(allHotels);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToFavorite(int id)
        {
            if (!await hotelService.IsExist(id))
            {
                TempData[ErrorMessage] = HotelDoesNotExist;
                return RedirectToAction(nameof(All));
            }
            try
            {
                await hotelService.AddHotelToUserFavoriteHotels(id, User.GetId());
                TempData[SuccessMessage] = SuccessfullyAddHotelToUserFavorites;
                return NoContent();
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction(nameof(All));
            }

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorite(int id)
        {
            if (!await hotelService.IsExist(id))
            {
                TempData[ErrorMessage] = HotelDoesNotExist;
                return RedirectToAction(nameof(All));
            }
            try
            {
                await hotelService.RemoveHotelFromUserFavoriteHotels(id, User.GetId());
                TempData[SuccessMessage] = SuccessfullyRemoveHotelFromUserFavoriteHotels;
                return NoContent();
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = DefaultErrorMessage;
                return RedirectToAction(nameof(All));
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            if(!await hotelService.IsExist(id))
            {
                TempData[ErrorMessage] = HotelDoesNotExist;
                return RedirectToAction(nameof(All));
            }
            HotelInfoViewModel hotel = await hotelService.GetHotelByIdAsync(id);
            return View(hotel);
        }
    }
}
