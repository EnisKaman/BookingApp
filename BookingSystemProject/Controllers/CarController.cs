namespace BookingSystem.Controllers
{
    using BookingSystem.Core.Contracts;
    using BookingSystem.Core.Models.Car;
    using BookingSystem.Core.Models.Ordering;
    using BookingSystem.Core.Models.Page;
    using Microsoft.AspNetCore.Mvc;
    public class CarController : Controller
    {
        private readonly ICarService carService;
        public CarController(ICarService carService)
        {
            this.carService = carService;
        }
        [HttpGet]
        public async Task<IActionResult> All(int pg = 1)
        {
            if(pg <= 0)
            {
                pg = 1;
            }
            if (ViewBag.Options == null)
            {
               ViewBag.Options = CreateSelectOptions();
            }
            if (ViewData["SelectedOption"] == null)
            {
              ViewData["SelectedOption"] = "default";
            }
            string sortOption = (string)ViewData["SelectedOption"];
            IEnumerable<CarViewModel> cars = await carService.GetAllAsync(sortOption);

            Pager pager = new Pager(cars.Count(), pg);
            int recordsToSkip = (pg - 1) * pager.PageZise;

            cars = cars.Skip(recordsToSkip).Take(pager.PageZise);
            ViewBag.Pager = pager;
            return View(cars);
        }
        [HttpPost]
        public async Task<IActionResult> All([FromForm]string selectedOption)
        {
            if (ViewBag.Options == null)
            {
                ViewBag.Options = CreateSelectOptions();
            }
            IEnumerable<CarViewModel> cars = await carService.GetAllAsync(selectedOption);
            string newOption = selectedOption == "default" ? "default" : selectedOption;
            ViewData["SelectedOption"] = newOption; 
            return View(cars);
        }
        private SelectViewModel CreateSelectOptions()
        {
            SelectViewModel selectViewModel = new SelectViewModel()
            {
                Options = new List<SelectListItemOrderOption>()
                {
                    new SelectListItemOrderOption()
                    {
                        Value = "price",
                        Text = "By Price"
                    },
                    new SelectListItemOrderOption()
                    {
                        Value = "year",
                        Text = "By Year"
                    },
                    new SelectListItemOrderOption()
                    {
                        Value = "make type",
                        Text = "By Make Type"
                    },
                    new SelectListItemOrderOption()
                    {
                        Value = "default",
                        Text = "Default"
                    }
                }
            };
            return selectViewModel;
        }
    }
}
