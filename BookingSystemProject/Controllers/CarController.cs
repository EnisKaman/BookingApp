namespace BookingSystem.Controllers
{
    using Core.Models.Page;
    using Core.Contracts;
    using Core.Models.Car;
    using Microsoft.AspNetCore.Mvc;
    public class CarController : Controller
    {
        private readonly ICarService carService;
        public CarController(ICarService carService)
        {
            this.carService = carService;
        }
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]CarQuerViewModel carQuerViewModel)
        {
            if (carQuerViewModel.CurrentPage <= 0)
            {
                carQuerViewModel.CurrentPage = 1;
            }
            Pager pager = new Pager(await carService.GetCarsCountAsync(), carQuerViewModel.CurrentPage);

            carQuerViewModel.Pager = pager;
            AllCarsSortedAndFilteredDataModel allCarsSortedAndFilteredDataModel = await carService.AllCarsSortedAndFilteredDataModelAsync(carQuerViewModel);
            carQuerViewModel.Cars = allCarsSortedAndFilteredDataModel.Cars;

            return View(carQuerViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await carService.IsCarExistAsync(id))
            {
                return RedirectToAction(nameof(All));
            }
            CarDetailsViewModel carDetailsViewModel = await carService.FindCarByIdAsync(id);
            return View(carDetailsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CarsByBrand(string brand = "", int id = 0)
        {
            IEnumerable<CarBrandViewModel> carsByBrand = await carService.GetCarsByBrandAsync(brand, id);
            return PartialView("_CarsByBrand", carsByBrand);
        }

    }
}
