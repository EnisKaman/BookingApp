
namespace BookingSystem.Core.Models.Ordering
{
    public class SelectViewModel
    {
        public SelectViewModel()
        {
            Options = new List<SelectListItemOrderOption>();
        }
        public string SelectedOption { get; set; } = null!;
        public List<SelectListItemOrderOption> Options { get; set; }
    }
}
