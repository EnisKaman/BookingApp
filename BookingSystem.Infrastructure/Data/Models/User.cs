namespace BookingSystem.Infrastructure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class User : IdentityUser
    {
        public User()
        {
            Reservations = new List<Reservation>();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
