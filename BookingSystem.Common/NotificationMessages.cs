﻿namespace BookingSystem.Common
{
    public static class NotificationMessages
    {
        public const string CarIsAlreadyRentedInThisPeriodMsg = "Car is already rented for period {0} - {1}";
        public const string SuccessfullRentCarMsg = "You have successfully rented your car for period {0} - {1}";
        public const string CarDoesNotExist = "Car with this id does not exist";
        public const string HotelDoesNotExist = "Hotel with this id does not exist";
        public const string SuccessfullyAddHotelToUserFavorites = "You have successfully add hotel to your favorite hotels";
        public const string SuccessfullyRemoveHotelFromUserFavoriteHotels = "You have successfully remove hotel from your favorite hotels";
        public const string DefaultErrorMessage = "Something went wrong, please try again later or contact us";
    }
}
