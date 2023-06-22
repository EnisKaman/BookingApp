namespace BookingSystem.Infrastructure.Data.Configurations
{
    using BookingSystem.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HotelEntityConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .OnDelete(DeleteBehavior.NoAction);

            ICollection<Hotel> hotelCollection = CreateHotels();
            builder.HasData(hotelCollection);
        }

        private ICollection<Hotel> CreateHotels()
        {
            List<Hotel> hotels = new List<Hotel>()
            {
                new Hotel()
                {
                    Id = 1,
                    Name = "Spa Hotel Dvoretsa",
                    Country = "Bulgaria",
                    City = "Velingrad",
                    Description = "СПА хотел „Двореца” се намира във Велинград, в прегръдката на Родопите.Той е един от малкото 5-звездни спа хотели във Велинград. Поради благотворните свойства на минералните си извори и прекрасния климат градът не само се е доказал, но е и официално обявен за СПА столица на Балканите. Велинград предлага спокойствие и бягство от стреса на делника, живописни маршрути за разходка сред природата и разнообразие от възможности за забавление. СПА хотел „Двореца” е в съседство с красив боров парк и разкрива очарователна гледка към околните планини. Тук въздухът е чист, а басейните са с топла минерална вода през цялата година. Хотелът е предпочитано място за романтични почивки, тиймбилдинги и бизнес събития. „Двореца” е особено любимо място на семейства с деца, тъй като „Двореца” предлага разнообразие от забавления за най-малките си гости – детски басейн, водна пързалка, люлки и кът с аниматор, много играчки и игри. На Ваше разположение са сауна, парна баня и сауна.",
                    StarRating = 5,
                    Latitude =  42.032235406916385m,
                    Longitude = 23.987805838924398m,
                    HotelBenefits = AddBenefitsToHotel(1, new int[]{2,4,6,7,5,8})
                },
                new Hotel()
                {
                    Id = 2,
                    City = "Velingrad",
                    Country = "Bulgaria",
                    Name = "Spa hotel Infinity",
                    Description = "Добре дошли  в СПА ХОТЕЛ ИНФИНИТИ ПАРК ВЕЛИНГРАД  – място, където ще намерите комфорт и планинско спокойствие.\r\n\r\nНашият пет звезден хотел предлага 95 луксозни стаи и апартаменти, отлични конферентни съоръжения, изискана кухня и уникален спа център.\r\nЗакрити термални басейни /полуолимпийски плувен, акватоничен, детски, бебешки, ледено шоков и контрастен/,\r\nджакузи 3 бр., парна баня, билкова парна баня, приключенски душ, кнайп пътека, горска пътека, финландска сауна,\r\nбилкова сауна, инфрачервена сауна , солна баня, турска баня, японска баня, релакс зона, външни бани, фитнес,\r\nсезонен панорамен инфинити басейн, джакузи, сауна и открити басейни.",
                    Latitude = 42.030206649356195m,
                    Longitude = 23.979628495721478m,
                    HotelBenefits = AddBenefitsToHotel(2, new int[]{2,4,6,7,5,8})
                },

            };
            return hotels;
        }
        private ICollection<HotelBenefits> AddBenefitsToHotel(int hotelId, int[] beneftIds)
        {
            ICollection<HotelBenefits> hotelBenefits = new List<HotelBenefits>();
            for (int i = 0; i < beneftIds.Length; i++)
            {
                hotelBenefits.Add(new HotelBenefits() { HotelId = hotelId, BenefitId = beneftIds[i] });
            }
            return hotelBenefits;
        }
    }
}
