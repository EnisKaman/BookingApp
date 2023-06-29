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
        public async Task<IActionResult> All(int pg = 1, string sort = null)
        {
            if(pg <= 0)
            {
                pg = 1;
            }
            if (ViewBag.Options == null)
            {
               ViewBag.Options = CreateSelectOptions();
            }
            string selectedOption = "default";
            if (!string.IsNullOrWhiteSpace(sort) && IsExist(sort))
            {
                selectedOption = sort;
            }
            ViewData["SelectedOption"] = selectedOption;

           IEnumerable <CarViewModel> cars = await carService.GetAllAsync(selectedOption);

            Pager pager = new Pager(cars.Count(), pg);
            int recordsToSkip = (pg - 1) * pager.PageSize;
            cars = cars.Skip(recordsToSkip).Take(pager.PageSize);
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
            string newOption = string.IsNullOrWhiteSpace(selectedOption) ? "default" : selectedOption;
            return RedirectToAction(nameof(All), new { pg = 1, sort = newOption });
        }
        private static SelectViewModel CreateSelectOptions()
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
        private bool IsExist(string sortOption)
        {
            var model = CreateSelectOptions();
            return model.Options.Any(opt => opt.Value == sortOption);
        }
    }
}
