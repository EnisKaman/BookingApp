namespace BookingSystem.Core.Models.Car
{
    using Infrastructure.Data.enums;
    using System.ComponentModel.DataAnnotations;
    public class CarDetailsViewModel :  CarViewModel
    {
        [Display(Name = "Count Doors")]
        public int DoorsCount { get;set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public double FuelConsumption { get; set; }
        public double FuelCapacity { get; set; }
        public int PeopleCapacity { get; set; }
        public string TransmissionType { get; set; } = null!;
    }
}
