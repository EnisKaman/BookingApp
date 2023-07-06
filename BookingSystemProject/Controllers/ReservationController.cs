namespace BookingSystem.Controllers
{
    using BookingSystem.Core.Models.Reservation;
    using BookingSystem.Extensions;
    using Core.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static BookingSystem.Common.NotificationKeys;
    using static BookingSystem.Common.NotificationMessages;

    [Authorize]
    public class ReservationController : Controller
    {
        private readonly ICarService carService;
        private readonly IUserService userService;
        private readonly IReservationService reservationService;
        public ReservationController(ICarService carService, IUserService userService, IReservationService reservationService)
        {
            this.carService = carService;
            this.userService = userService;
            this.reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> RentCar(int id)
        {
            if (!await carService.IsCarExistAsync(id))
            {
                TempData[ErrorMessage] = CarDoesNotExist;
                return RedirectToAction("All", "Car");
            }
            RentCarReservationViewModel rentCarReservation = new RentCarReservationViewModel();
            rentCarReservation.CarlViewModel = await carService.GetOrderCarAsync(id);
            rentCarReservation.User = await userService.GetUserByIdAsync(this.User.GetId());
            return View(rentCarReservation);
        }
        [HttpPost]
        public async Task<IActionResult> RentCar(int id, RentCarReservationViewModel model)
        {
            model.User.Id = User.GetId();
            model.CarlViewModel = await carService.GetOrderCarAsync(id);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(!await carService.IsCarExistAsync(id))
            {
                TempData[ErrorMessage] = CarDoesNotExist;
                return RedirectToAction("All", "Car");
            }
            if (await reservationService.CheckCarIsAlreadyReservedAsync(id, model.StartRentDate, model.EndRentDate))
            {
                TempData[ErrorMessage] = string.Format(CarIsAlreadyRentedInThisPeriodMsg,model.StartRentDate.ToString("dd/MM/yyyy"), model.EndRentDate.ToString("dd/MM/yyyy"));
                return View(model);
            }
            try
            {
                await reservationService.RentCarAsync(id, model);
                TempData[SuccessMessage] = string.Format(SuccessfullRentCarMsg, model.StartRentDate.ToString("dd/MM/yyyy"), model.EndRentDate.ToString("dd/MM/yyyy"));
                return RedirectToAction("All", "Car");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong, please try again later or contact us");
            }
            return View(model);
        }
    }
}
