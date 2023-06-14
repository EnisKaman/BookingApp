namespace BookingSystem.Common
{
    public class EntityValidation
    {
        public static class UserEntity
        {
            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 35;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 30;

            public const int EmailMinLength = 10;    
            public const int EmailMaxLength = 35;    
        }
    }
}