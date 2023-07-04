namespace BookingSystem.Controllers
{
    using BookingSystem.Core.Models.Reservation;
    using BookingSystem.Extensions;
    using Core.Contracts;
    using Core.Models.Car;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ReservationController : Controller
    {
        private readonly ICarService carService;
        private readonly IUserService userService;
        public ReservationController(ICarService carService, IUserService userService)
        {
            this.carService = carService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> RentCar(int id)
        {
            if(!await carService.IsCarExistAsync(id))
            {
                return NotFound();
            }
            RentCarReservationViewModel rentCarReservation = new RentCarReservationViewModel();
            rentCarReservation.CarlViewModel = await carService.GetOrderCarAsync(id);
            rentCarReservation.User = await userService.GetUserByIdAsync(this.User.GetId());
            return View(rentCarReservation);
        }
    }
}
