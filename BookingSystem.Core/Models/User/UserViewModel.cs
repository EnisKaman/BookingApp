namespace BookingSystem.Core.Models.User
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.UserEntity;
    public class UserViewModel
    {
        public Guid Id { get; init; }
        public string Email { get; init; } = null!;
        [Phone]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }
        [StringLength(FirstNameMaxValue, MinimumLength = FirstNameMinValue)]
        public string FirstName { get; set; }
        [StringLength(LastNameMaxValue, MinimumLength = LastNameMaxValue)]
        public string LastName { get; set; }
    }
}
