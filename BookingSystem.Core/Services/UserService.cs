namespace BookingSystem.Core.Services
{
    using BookingSystemProject.Data;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Models.User;

    public class UserService : IUserService
    {
        private readonly BookingContext bookingContext;
        public UserService(BookingContext bookingContext)
        {
            this.bookingContext = bookingContext;
        }

        public async Task<UserViewModel> GetUserByIdAsync(Guid id)
        {
            UserViewModel userViewModel = await bookingContext.Users
                 .Select(u => new UserViewModel()
                 {
                     Id = u.Id,
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     Email = u.Email,
                     PhoneNumber = u.PhoneNumber

                 }).FirstAsync(u => u.Id == id);
            return userViewModel;
        }
    }
}
