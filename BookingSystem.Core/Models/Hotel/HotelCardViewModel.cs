namespace BookingSystem.Core.Models.Hotel
{
    using BookingSystem.Core.Models.Picture;
    public class HotelCardViewModel
    {
        public HotelCardViewModel()
        {
            Pictures = new List<PictureViewModel>();
        }
        public string Name { get; set; } = null!;
        public string Country { get;set; } = null!;
        public string City { get; set; } = null!;
        public int Stars { get; set; }
        public IEnumerable<PictureViewModel> Pictures { get; set; }
    }
}
