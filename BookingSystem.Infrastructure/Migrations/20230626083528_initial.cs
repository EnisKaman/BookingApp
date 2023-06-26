using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ClassIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: false),
                    StarRating = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(17,15)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(17,15)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    City = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomBasis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ClassIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBasis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IncreasePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteHotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteHotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteHotels_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteHotels_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelBenefits",
                columns: table => new
                {
                    BenefitId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBenefits", x => new { x.HotelId, x.BenefitId });
                    table.ForeignKey(
                        name: "FK_HotelBenefits_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HotelBenefits_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1900)", maxLength: 1900, nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_RoomPackages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "RoomPackages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pictures_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    CountNights = table.Column<int>(type: "int", nullable: false),
                    PeopleCount = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomsBases",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RoomBasisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsBases", x => new { x.RoomBasisId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_RoomsBases_RoomBasis_RoomBasisId",
                        column: x => x.RoomBasisId,
                        principalTable: "RoomBasis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomsBases_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RentCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    MakeType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ModelType = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    DoorsCount = table.Column<int>(type: "int", nullable: false),
                    CarImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelConsumption = table.Column<double>(type: "float", nullable: false),
                    FuelCapacity = table.Column<double>(type: "float", nullable: false),
                    PeopleCapacity = table.Column<int>(type: "int", nullable: false),
                    TransmissionType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(17,15)", nullable: false),
                    Lattitude = table.Column<decimal>(type: "decimal(17,15)", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentCars_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Benefits",
                columns: new[] { "Id", "ClassIcon", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "fa-solid fa-dog", false, "Allow pets" },
                    { 2, "fa-solid fa-hot-tub-person", false, "Spa" },
                    { 3, "fa-solid fa-bell-concierge", false, "Room service" },
                    { 4, "fa-solid fa-dumbbell", false, "Gym" },
                    { 5, "fa-solid fa-utensils", false, "Restaurant" },
                    { 6, "fa-solid fa-square-parking", false, "Parking" },
                    { 7, "fa-solid fa-water-ladder", false, "Pool" },
                    { 8, "fa-solid fa-wine-glass", false, "Bar" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Country", "Description", "IsDeleted", "IsFavorite", "Latitude", "Longitude", "Name", "StarRating" },
                values: new object[,]
                {
                    { 1, "Velingrad", "Bulgaria", "СПА хотел „Двореца” се намира във Велинград, в прегръдката на Родопите.Той е един от малкото 5-звездни спа хотели във Велинград. Поради благотворните свойства на минералните си извори и прекрасния климат градът не само се е доказал, но е и официално обявен за СПА столица на Балканите. Велинград предлага спокойствие и бягство от стреса на делника, живописни маршрути за разходка сред природата и разнообразие от възможности за забавление. СПА хотел „Двореца” е в съседство с красив боров парк и разкрива очарователна гледка към околните планини. Тук въздухът е чист, а басейните са с топла минерална вода през цялата година. Хотелът е предпочитано място за романтични почивки, тиймбилдинги и бизнес събития. „Двореца” е особено любимо място на семейства с деца, тъй като „Двореца” предлага разнообразие от забавления за най-малките си гости – детски басейн, водна пързалка, люлки и кът с аниматор, много играчки и игри. На Ваше разположение са сауна, парна баня и сауна.", false, false, 42.032235406916385m, 23.987805838924398m, "Spa Hotel Dvoretsa", 5 },
                    { 2, "Velingrad", "Bulgaria", "Добре дошли  в СПА ХОТЕЛ ИНФИНИТИ ПАРК ВЕЛИНГРАД  – място, където ще намерите комфорт и планинско спокойствие.\r\n\r\nНашият пет звезден хотел предлага 95 луксозни стаи и апартаменти, отлични конферентни съоръжения, изискана кухня и уникален спа център.\r\nЗакрити термални басейни /полуолимпийски плувен, акватоничен, детски, бебешки, ледено шоков и контрастен/,\r\nджакузи 3 бр., парна баня, билкова парна баня, приключенски душ, кнайп пътека, горска пътека, финландска сауна,\r\nбилкова сауна, инфрачервена сауна , солна баня, турска баня, японска баня, релакс зона, външни бани, фитнес,\r\nсезонен панорамен инфинити басейн, джакузи, сауна и открити басейни.", false, false, 42.030206649356195m, 23.979628495721478m, "Spa hotel Infinity", 5 },
                    { 3, "Sofia", "Bulgaria", "Петзвездният хотел Маринела София е проектиран от известния японски архитект Кишо Курокава - автор на редица световни забележителности.\r\nХотелът е разположен на площ от 30 000 кв.м. Нашите 442 стаи и апартаменти, включително най-големият президентски апартамент в България, предлагат лукс & комфорт с прекрасен изглед към града и планината.\r\nС общо 10 мултифукнционални зали, сред които една от най-големите бални и конферентни зали в града и забележително зала на последния етаж.\r\nХотел Маринела е сред емблематичните сгради в София и уникално място за Балканския полуостров. Това е точното място за бягство от натоварения градски живот, като същевременно се намира в самия център на града.", false, false, 42.67252787183476m, 23.318956866924907m, "Hotel Marinela", 5 },
                    { 4, "Milan", "Italy", "The NH Collection Milano Porta Nuova, formerly NH Milano Grand Hotel Verdi, stands in an extraordinary position near Porta Nuova, the new business district of the city, also renowned for its lively nightlife and cultural activities. The center of Milan is a short distance away and can be easily reached by taxi, underground and train connections in the vicinity of the hotel.", false, false, 45.48175408930197m, 9.1916942539707m, "Hotel NH Collection Milano Porta Nuova", 4 },
                    { 5, "Albena", "Bulgaria", "Maritim Hotel Paradise Blue Albena 5* в Албена е отличен и заслужава напълно 5 звезди за всичко, което предлага: интериориорен и екстериорен дизайн, просторни стаи, тихо място точно пред морето, красив плаж. Винаги разполагаме с шезлонги на плажа и басейна и с много на брой малки изненади, които дори не очаквахме: минерална вода в целия хотел, истинско кафе (еспресо, капучино и айс кафе), 100% ябълков сок и пресен хляб на закуска.", false, false, 43.36873068763438m, 28.082414473014655m, "Paradise blue", 5 },
                    { 6, "Albena", "Bulgaria", "Амелия Хотел Албена е най-новото 5-звездно бижу, на което просто не можете да устоите. Първият тематичен хотел в Албена, посветен на първата жена-летец, прекосила Атлантика, Амелия Еърхарт, ще ви посрещне през лято 2022 с невероятни гледки и пълно усещане за релакс. Насладете се на изгревите и залезите от панорамния басейн на покрива, на висококачествените специалитети на топ готвачите на Албена и на многобройните възможности за спортни активности, които комплексът предоставя.\r\n\r\nСамо на метри от морето, в сърцето на комплекса, Амелия хотел Албена ви очаква, за да се превърне в любимото ви място за ваканция, където със сигурност ще пожелаете да се върнет", false, false, 43.368523054572734m, 28.081230353970707m, "Amelia", 5 }
                });

            migrationBuilder.InsertData(
                table: "RentCars",
                columns: new[] { "Id", "CarImg", "DoorsCount", "FuelCapacity", "FuelConsumption", "IsAvailable", "IsDeleted", "Lattitude", "Location", "Longitude", "MakeType", "ModelType", "PeopleCapacity", "PricePerDay", "ReservationId", "TransmissionType", "Year" },
                values: new object[,]
                {
                    { 1, "/img/Cars/BmwX6 Blue.jpeg", 4, 85.0, 13.4, true, false, 42.026543162263934m, "Velingrad", 23.991291982406658m, "Bmw", "X6", 4, 180m, null, 0, 2020 },
                    { 2, "/img/Cars/Bmw X3 2018.jpg", 4, 60.0, 13.4, true, false, 42.026543162263934m, "Velingrad", 23.991291982406658m, "Bmw", "X3", 4, 150m, null, 0, 2018 },
                    { 3, "/img/Cars/Bmw X3 2018.jpg", 4, 50.0, 6.7999999999999998, true, false, 42.026543162263934m, "Velingrad", 23.991291982406658m, "Bmw", "X1", 4, 70m, null, 0, 2015 },
                    { 4, "/img/Cars/Bmw X1 2015.jpg", 4, 50.0, 6.7999999999999998, true, false, 42.026543162263934m, "Velingrad", 23.991291982406658m, "Bmw", "X1", 4, 70m, null, 0, 2015 },
                    { 5, "/img/Cars/Peugeot 3008.jpg", 4, 53.0, 4.2000000000000002, true, false, 42.026543162263934m, "Velingrad", 23.991291982406658m, "Peugeot", "3008", 4, 110m, null, 0, 2019 },
                    { 6, "/img/Cars/Peugeot-2008.jpg", 4, 50.0, 4.7999999999999998, true, false, 42.026543162263934m, "Velingrad", 23.991291982406658m, "Peugeot", "2008", 4, 110m, null, 0, 2019 },
                    { 7, "/img/Cars/Peugeot-408-2015.jpg", 4, 50.0, 4.7999999999999998, true, false, 42.026543162263934m, "Velingrad", 23.991291982406658m, "Peugeot", "408", 4, 40m, null, 0, 2015 },
                    { 8, "/img/Cars/Mercedes CLA 2014.jpg", 4, 35.0, 4.9000000000000004, true, false, 42.026543162263934m, "Velingrad", 23.991291982406658m, "Mercedes", "CLA", 4, 50m, null, 0, 2014 },
                    { 9, "/img/Cars/Mercedes C63 2012.jpg", 4, 30.0, 4.4000000000000004, true, false, 42.026543162263934m, "Velingrad", 23.991291982406658m, "Mercedes", "C63", 4, 35m, null, 0, 2012 },
                    { 10, "/img/Cars/Mercedes C63 2012.jpg", 4, 93.0, 7.2000000000000002, true, false, 42.026543162263934m, "Velingrad", 23.991291982406658m, "Mercedes", "GLE 350 Coupe", 4, 120m, null, 0, 2016 },
                    { 11, "/img/Cars/BMW-530d 2017.jpg", 4, 78.0, 4.7000000000000002, true, false, 42.700866541296215m, "Sofia", 23.304447911974357m, "BMW", "530d", 4, 80m, null, 0, 2017 },
                    { 12, "/img/Cars/Bmx X4 2015.jpg", 4, 67.0, 5.9000000000000004, true, false, 42.700866541296215m, "Sofia", 23.304447911974357m, "BMW", "X4", 4, 65m, null, 0, 2015 },
                    { 13, "/img/Cars/Adui A7 2016.png", 4, 75.0, 5.2000000000000002, true, false, 42.700866541296215m, "Sofia", 23.304447911974357m, "Audi", "A7", 4, 75m, null, 0, 2017 },
                    { 14, "/img/Cars/Renault Megane.jpg", 4, 60.0, 4.7000000000000002, true, false, 42.700866541296215m, "Sofia", 23.304447911974357m, "Renault", "Megane", 4, 30m, null, 0, 2012 },
                    { 15, "/img/Cars/Skoda Ocativa 2013.jpg", 4, 50.0, 5.0999999999999996, true, false, 42.700866541296215m, "Sofia", 23.304447911974357m, "Skoda", "Ocativa", 4, 35m, null, 0, 2013 },
                    { 16, "/img/Cars/Bmw X3 2018.jpg", 4, 60.0, 13.4, true, false, 42.700866541296215m, "Sofia", 23.304447911974357m, "Bmw", "X3", 4, 150m, null, 0, 2018 },
                    { 17, "/img/Cars/BmwX6 Blue.jpeg", 4, 85.0, 13.4, true, false, 42.700866541296215m, "Sofia", 23.304447911974357m, "Bmw", "X6", 4, 180m, null, 0, 2020 },
                    { 18, "/img/Cars/BmwX6 Blue.jpeg", 4, 85.0, 13.4, true, false, 45.43995264548058m, "Milano", 9.20198333778624m, "Bmw", "X6", 4, 180m, null, 0, 2020 },
                    { 19, "/img/Cars/Peugeot-2008.jpg", 4, 50.0, 4.7999999999999998, true, false, 45.43995264548058m, "Milano", 9.20198333778624m, "Peugeot", "2008", 4, 110m, null, 0, 2019 },
                    { 20, "/img/Cars/Peugeot-408-2015.jpg", 4, 50.0, 4.7999999999999998, true, false, 45.43995264548058m, "Milano", 9.20198333778624m, "Peugeot", "408", 4, 40m, null, 0, 2015 },
                    { 21, "/img/Cars/Mercedes CLA 2014.jpg", 4, 35.0, 4.9000000000000004, true, false, 45.43995264548058m, "Milano", 9.20198333778624m, "Mercedes", "CLA", 4, 50m, null, 0, 2014 },
                    { 22, "/img/Cars/Mercedes C63 2012.jpg", 4, 30.0, 4.4000000000000004, true, false, 45.43995264548058m, "Milano", 9.20198333778624m, "Mercedes", "C63", 4, 35m, null, 0, 2012 },
                    { 23, "/img/Cars/Mercedes ML.jpg", 4, 93.0, 7.2999999999999998, true, false, 42.026543162263934m, "Velingrad", 23.991291982406658m, "Mercedes", "ML", 4, 100m, null, 0, 2015 }
                });

            migrationBuilder.InsertData(
                table: "RoomBasis",
                columns: new[] { "Id", "ClassIcon", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "fa-solid fa-tv", false, "Tv" },
                    { 2, "fa-solid fa-wifi", false, "Free WiFi" },
                    { 3, "fa-solid fa-vault", false, "Vault" },
                    { 4, "fa-solid fa-snowflake", false, "Air Conditioning" },
                    { 5, "fa-solid fa-phone", false, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "RoomBasis",
                columns: new[] { "Id", "ClassIcon", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 6, "fa-solid fa-hot-tub-person", false, "Jacuzzi" },
                    { 7, "fa-solid fa-mug-hot", false, "Coffee Jug" },
                    { 8, "fa-solid fa-shower", false, "Shower" }
                });

            migrationBuilder.InsertData(
                table: "RoomPackages",
                columns: new[] { "Id", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, false, "Breakfast", 0m },
                    { 2, false, "Breakfast and Dinner", 70m },
                    { 3, false, "All Inclusive", 100m }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "IncreasePercentage", "Name" },
                values: new object[,]
                {
                    { 1, 40m, "Apartment" },
                    { 2, 35m, "Studio" },
                    { 3, 30m, "Double bed" },
                    { 4, 45m, "Village" },
                    { 5, 0m, "Single bed" }
                });

            migrationBuilder.InsertData(
                table: "HotelBenefits",
                columns: new[] { "BenefitId", "HotelId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 2, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 1, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 6, 4 },
                    { 8, 4 },
                    { 3, 5 },
                    { 4, 5 },
                    { 5, 5 },
                    { 6, 5 },
                    { 7, 5 },
                    { 8, 5 },
                    { 2, 6 },
                    { 3, 6 },
                    { 4, 6 },
                    { 5, 6 },
                    { 6, 6 },
                    { 7, 6 },
                    { 8, 6 }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "HotelId", "Path", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, "/img/Hotels/Spa Hotel Dvoretsa/Spa Hotel Dvoretsa.jpg", null },
                    { 2, 1, "/img/Hotels/Spa Hotel Dvoretsa/Spa Hotel Dvoretsa2.jpg", null },
                    { 3, 1, "/img/Hotels/Spa Hotel Dvoretsa/Spa Hotel Dvoretsa3.jpg", null },
                    { 4, 1, "/img/Hotels/Spa Hotel Dvoretsa/Spa Hotel Dvoretsa4.jpg", null },
                    { 11, 2, "/img/Hotels/Spa Hotel Infinity/Spa Hotel Infinity.jpg", null },
                    { 12, 2, "/img/Hotels/Spa Hotel Infinity/Spa Hotel Infinity2.jpg", null },
                    { 13, 2, "/img/Hotels/Spa Hotel Infinity/Spa Hotel Infinity3.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "HotelId", "Path", "RoomId" },
                values: new object[,]
                {
                    { 27, 3, "/img/Hotels/Hotel Marinela/Hotel Marinela1.jpg", null },
                    { 28, 3, "/img/Hotels/Hotel Marinela/Hotel Marinela2.jpg", null },
                    { 29, 3, "/img/Hotels/Hotel Marinela/Hotel Marinela3.jpg", null },
                    { 37, 4, "/img/Hotels/NH Collection Milano Porta Nuova/Porta Nuova.jpg", null },
                    { 46, 5, "/img/Hotels//Paradise Blue/Paradaise Albena1.jpg", null },
                    { 47, 5, "/img/Hotels//Paradise Blue/Paradaise Albena2.jpg", null },
                    { 48, 5, "/img/Hotels//Paradise Blue/Paradaise Albena3.jpg", null },
                    { 57, 6, "/Hotels/Hotel Amelia/Hotel Amelia1.jpg", null },
                    { 58, 6, "/Hotels/Hotel Amelia/Hotel Amelia2.jpg", null },
                    { 59, 6, "/Hotels/Hotel Amelia/Hotel Amelia3.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Description", "HotelId", "IsDeleted", "PackageId", "PricePerNight", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 2, "Стаите в хотела разполагат с плоскоекранен телевизор със сателитна телевизия, Wi-Fi, сейф, саниратен възел с вана или душ.\r\nАпартаментите са подходящи за двойки, семейства или група приятели до 4 човека. Голямата спалня е обзаведена с удобно двойно легло, а в по-малката спалня се намират 2 комфортни единични легла. В банята на апартаментите ще откриете луксозна вана, сешоар и всички необходими принадлежности.", 1, false, 1, 190m, 5 },
                    { 2, 4, "Стаи в хотела разполагат с плоскоекранен телевизор със сателитна телевизия, Wi-Fi, сейф, саниратен възел с вана или душ.\r\nАпартаментите са подходящи за двойки, семейства или група приятели до 4 човека. Голямата спалня е обзаведена с удобно двойно легло, а в по-малката спалня се намират 2 комфортни единични легла. В банята на апартаментите ще откриете луксозна вана, сешоар и всички необходими принадлежности.", 1, false, 1, 247m, 3 },
                    { 3, 5, "Стаи в хотела разполагат с плоскоекранен телевизор със сателитна телевизия, Wi-Fi, сейф, саниратен възел с вана или душ.\r\nАпартаментите са подходящи за двойки, семейства или група приятели до 4 човека. Голямата спалня е обзаведена с удобно двойно легло, а в по-малката спалня се намират 2 комфортни единични легла. В банята на апартаментите ще откриете луксозна вана, сешоар и всички необходими принадлежности.", 1, false, 1, 266m, 1 },
                    { 4, 2, "Изживейте лукса и комфорта в стаята си в хотел Infinity. С просторен и стилно обзаведен интериор, стаята предлага уютна атмосфера и модерни удобства, които ще ви осигурят приятен престой.\r\n\r\nРазкройте се в просторната стая в хотел Infinity, където съчетанието от елегантен дизайн и изискани детайли ще ви оставят впечатлени. Отпуснете се и се насладете на комфорта на луксозното легло и удобствата, които предлага тази стилна стая.", 2, false, 1, 200m, 5 },
                    { 5, 4, "Изживейте лукса и комфорта в стаята си в хотел Infinity. С просторен и стилно обзаведен интериор, стаята предлага уютна атмосфера и модерни удобства, които ще ви осигурят приятен престой.\r\n\r\nРазкройте се в просторната стая в хотел Infinity, където съчетанието от елегантен дизайн и изискани детайли ще ви оставят впечатлени. Отпуснете се и се насладете на комфорта на луксозното легло и удобствата, които предлага тази стилна стая.", 2, false, 1, 286m, 3 },
                    { 6, 4, "Изживейте лукса и комфорта в стаята си в хотел Infinity. С просторен и стилно обзаведен интериор, стаята предлага уютна атмосфера и модерни удобства, които ще ви осигурят приятен престой.\r\n\r\nРазкройте се в просторната стая в хотел Infinity, където съчетанието от елегантен дизайн и изискани детайли ще ви оставят впечатлени. Отпуснете се и се насладете на комфорта на луксозното легло и удобствата, които предлага тази стилна стая.", 2, false, 1, 280m, 1 },
                    { 7, 6, "Изживейте лукса и комфорта в стаята си в хотел Infinity. С просторен и стилно обзаведен интериор, стаята предлага уютна атмосфера и модерни удобства, които ще ви осигурят приятен престой.\r\n\r\nРазкройте се в просторната стая в хотел Infinity, където съчетанието от елегантен дизайн и изискани детайли ще ви оставят впечатлени. Отпуснете се и се насладете на комфорта на луксозното легло и удобствата, които предлага тази стилна стая.", 2, false, 1, 290m, 4 },
                    { 8, 2, "Насладете се на превъзходството на стаята в хотел Маринела София. С елегантен и модерен дизайн, стаята предлага изисканост и комфорт, съчетани с невероятна гледка към града или планината, които ще ви впечатлят.\r\n\r\nОткрийте уют и релаксация в просторната стая в хотел Маринела София. Обзаведена с внимание към детайла и с модерни удобства, тази стая предлага комфортна обстановка, в която можете да се отпуснете и да се насладите на безпроблемен престой в столицата.", 3, false, 1, 180m, 5 },
                    { 9, 3, "Насладете се на превъзходството на стаята в хотел Маринела София. С елегантен и модерен дизайн, стаята предлага изисканост и комфорт, съчетани с невероятна гледка към града или планината, които ще ви впечатлят.\r\n\r\nОткрийте уют и релаксация в просторната стая в хотел Маринела София. Обзаведена с внимание към детайла и с модерни удобства, тази стая предлага комфортна обстановка, в която можете да се отпуснете и да се насладите на безпроблемен престой в столицата.", 3, false, 1, 243m, 3 },
                    { 10, 4, "Насладете се на превъзходството на стаята в хотел Маринела София. С елегантен и модерен дизайн, стаята предлага изисканост и комфорт, съчетани с невероятна гледка към града или планината, които ще ви впечатлят.\r\n\r\nОткрийте уют и релаксация в просторната стая в хотел Маринела София. Обзаведена с внимание към детайла и с модерни удобства, тази стая предлага комфортна обстановка, в която можете да се отпуснете и да се насладите на безпроблемен престой в столицата.", 3, false, 1, 252m, 1 },
                    { 11, 4, "Experience the charm and elegance of the rooms at Milano Porta Nuova Hotel. Immerse yourself in a sophisticated ambiance where modern design seamlessly blends with Italian style, creating a welcoming retreat for your stay in Milan.\r\n\r\nDiscover a haven of comfort and tranquility in the rooms of Milano Porta Nuova Hotel. With tasteful decor, contemporary furnishings, and thoughtful amenities, these rooms provide a relaxing atmosphere, allowing you to unwind and enjoy a seamless stay in the vibrant city of Milan.", 4, false, 1, 247m, 3 },
                    { 12, 2, "Experience the charm and elegance of the rooms at Milano Porta Nuova Hotel. Immerse yourself in a sophisticated ambiance where modern design seamlessly blends with Italian style, creating a welcoming retreat for your stay in Milan.\r\n\r\nDiscover a haven of comfort and tranquility in the rooms of Milano Porta Nuova Hotel. With tasteful decor, contemporary furnishings, and thoughtful amenities, these rooms provide a relaxing atmosphere, allowing you to unwind and enjoy a seamless stay in the vibrant city of Milan.", 4, false, 1, 190m, 5 },
                    { 13, 4, "Experience the charm and elegance of the rooms at Milano Porta Nuova Hotel. Immerse yourself in a sophisticated ambiance where modern design seamlessly blends with Italian style, creating a welcoming retreat for your stay in Milan.\r\n\r\nDiscover a haven of comfort and tranquility in the rooms of Milano Porta Nuova Hotel. With tasteful decor, contemporary furnishings, and thoughtful amenities, these rooms provide a relaxing atmosphere, allowing you to unwind and enjoy a seamless stay in the vibrant city of Milan.", 4, false, 1, 266m, 1 },
                    { 14, 3, "Потопете се в прегръдката на природата с резервация на стая Deluxe в Maritim Hotel Paradise Blue Albena 5* с гледка към морето или парка. За вашата комфортна почивка вие ще разполагате със стилно обзаведени помещения, включително невероятно удобна спалня от единични легла и мек разтегателен диван с 14 см матрак. Баните са оборудвани с душкабина и вана. Стаите са разположени от 1- ви до 7- ми етаж на хотела и ще ви предложат най-красивите и запомнящи се гледки.\r\n\r\nПодходящи за настаняване на 2 възрастни и 1 дете. Максимално допустимо настаняване 2 възрастни и 2 деца.", 5, false, 1, 364m, 3 },
                    { 15, 4, "Студиа Deluxe са обзаведени с разтегателен диван, маса и фотьойли, с две единични легла, работно бюро, стъклена стена и луксозен кухненски бокс. Оборудвани са с баня с вана или душ кабина, LCD дисплей и тоалетна, както и втора тоалетна в отделно помещение. Яркият декор и съчетанието от естествени дървени нюанси с пастелни сини тонове създават комфорт и уют. Студиата са разположени от 1-ви до 7-ми етаж на хотела.", 5, false, 1, 378m, 2 },
                    { 16, 4, "Потопете се в несравнимия петзвезден комфорт с резервация на апартамент Deluxe в Maritim Hotel Paradise Blue Albena 5*. Стилните двустайни делукс апартаменти, разполагат с невероятни тераси с изглед към морето или към парка. Състоят се от хол с разтегателен диван, спалня с две единични легла с изключително комфортни матраци за вашия здравословен сън и спално бельо от висококачествени материи, модерни и функционални мебели. Помещенията са подходящи за настаняване на 2 възрастни и 1 дете. Максимално допустимо настаняване 2 възрастни и 2 деца. Банята е с душкабина и вана - 8 кв.м и отделна тоалетна - 1,5 кв. м. Просторната тераса е идеалното място, от което можете да се насладите на лекия и прохладен бриз, докато се любувате на морската панорама. Разположението на апартаментите е от 1- ви до 7- ми етаж.", 5, false, 1, 392m, 1 },
                    { 17, 3, "Просторни и луксозно обзаведени, стаите Делукс с гледка парк ще ви изненадат със своята функционалност. Комфортните възглавници ще ви пренесат високо в облаците, а от широкия балкон ще можете да се насладите на незабравима гледка към централната алея, докато отпивате от сутрешното си кафе или чай от подбрани сортове, които ви очакват в стаята. Или можете просто да се отпуснете пред 49-инчовия телевизор. За Вашата сигурност във всяка стая има сейф. Стаите са оборудвани и със сет за гладене, телефон и мини бар.", 6, false, 1, 351m, 3 },
                    { 18, 4, "Просторните и луксозно обзаведени апартаменти Делукс с гледка парк са перфектни за семейства. Комфортните възглавници ще ви пренесат в облаците, а от широкия балкон ще можете да се насладите на гледка към оживената централна алея на комплекса, докато отпивате от сутрешното си кафе или чай от селектирани сортове, които ви очакват във всеки апартамент. Или просто можете да релаксирате във ваната или гледайки телевизия на един от двата 49-инчови телевизора. За Вашата сигурност всеки апартамент е оборудван със сейф. На Ваше разположение има и сет за гладене, телефон и мини бар.", 6, false, 1, 406m, 1 },
                    { 19, 4, "Резервирайте Стая Executive VIP в Хотел Амелия 5* и получете екслузивен достъп до уникалния басейн на покрива със страхотна панорама и бар с изкушаващи напитки. \r\n\r\nСтаята ще ви очарова с морската си гледка и неповторим дизайнерски лукс. Удобните матраци ще ви гарантират сън, сякаш сте в облаците, а просторът ще допринесе за вашият истински и дълго мечтан релакс.", 6, false, 1, 377m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "HotelId", "Path", "RoomId" },
                values: new object[,]
                {
                    { 5, null, "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvorestsa SingleRoom.jpg", 1 },
                    { 6, null, "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvorestsa SingleRoom2.jpg", 1 },
                    { 7, null, "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvoretsa Double Bed.jpg", 2 },
                    { 8, null, "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvoretsa Double Bed2.jpg", 2 },
                    { 9, null, "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvoretsa Apartment.jpg", 3 },
                    { 10, null, "/img/Rooms/Spa hotel Dvoretsa rooms/Spa Hotel Dvoretsa Apartment2.jpg", 3 },
                    { 14, null, "/img/Rooms/Spa hotel Infinity rooms/Infinity single room1.webp", 4 },
                    { 15, null, "/img/Rooms/Spa hotel Infinity rooms/Infinity single room2.webp", 4 },
                    { 16, null, "/img/Rooms/Spa hotel Infinity rooms/Infinity single room3.webp", 4 },
                    { 17, null, "/img/Rooms/Spa hotel Infinity rooms/Infinity single room3.webp", 5 },
                    { 18, null, "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity double bed1.jpg", 5 },
                    { 19, null, "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity double bed2.jpg", 5 },
                    { 20, null, "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity double bed3.jpg", 5 },
                    { 21, null, "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity apartment1.jpg", 6 },
                    { 22, null, "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity apartment2.jpg", 6 },
                    { 23, null, "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity apartment3.jpg", 6 },
                    { 24, null, "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity house1.jpg", 7 },
                    { 25, null, "/img/Rooms/Spa hotel Infinity rooms/Spa hotel Infinity rooms/Spa Hotel Infinity house2.jpg", 7 },
                    { 26, null, "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity house3.jpg", 7 },
                    { 30, null, "/img/Rooms/Hotel Marinela rooms/Hotel Marinela siglebed1.webp", 8 },
                    { 31, null, "/img/Rooms/Hotel Marinela rooms/Hotel Marinela siglebed2.webp", 8 },
                    { 32, null, "/img/Rooms/Hotel Marinela rooms/Hotel Marinela doublebed.webp", 9 },
                    { 33, null, "/img/Rooms/Hotel Marinela rooms/Hotel Marinela doublebed2.webp", 9 },
                    { 34, null, "/img/Rooms/Hotel Marinela rooms/Hotel Marinela apartment1.webp", 10 },
                    { 35, null, "/img/Rooms/Hotel Marinela rooms/Hotel Marinela apartment2.webp", 10 },
                    { 36, null, "/img/Rooms/Hotel Marinela rooms/Hotel Marinela apartment3.webp", 10 },
                    { 38, null, "/img/Rooms/Porta Nuova rooms/Porta Nuova doublebed1.jpg", 11 },
                    { 39, null, "/img/Rooms/Porta Nuova rooms/Porta Nuova doublebed2.jpg", 11 },
                    { 40, null, "/img/Rooms/Porta Nuova rooms/Porta Nuova doublebed3.jpg", 11 },
                    { 41, null, "/img/Rooms/Porta Nuova rooms/Porta Nuova singlebed1.jpg", 12 },
                    { 42, null, "/img/Rooms/Porta Nuova rooms/Porta Nuova singlebed2.jpg", 12 },
                    { 43, null, "/img/Rooms/Porta Nuova rooms/Porta Nuova aapartment1.jpg", 13 },
                    { 44, null, "/img/Rooms/Porta Nuova rooms/Porta Nuova aapartment2.jpg", 13 },
                    { 45, null, "/img/Rooms/Porta Nuova rooms/Porta Nuova aapartment3.jpg", 13 },
                    { 49, null, "/img/Rooms//Paradise rooms/Paradise doublebed1.jpg", 14 },
                    { 50, null, "/img/Rooms//Paradise rooms/Paradise doublebed2.jpg", 14 },
                    { 51, null, "/img/Rooms/Paradise rooms/Paradise stuido1.jpg", 15 },
                    { 52, null, "/img/Rooms/Paradise rooms/Paradise stuido2.jpg", 15 },
                    { 53, null, "/img/Rooms/Paradise rooms/Paradise stuido3.jpg", 15 },
                    { 54, null, "/img/Rooms/Paradise rooms/Paradise stuido4.jpg", 15 },
                    { 55, null, "/img/Rooms/Paradise rooms/Paradise apartment1.jpg", 16 },
                    { 56, null, "/img/Rooms/Paradise rooms/Paradise apartment2.jpg", 16 }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "HotelId", "Path", "RoomId" },
                values: new object[,]
                {
                    { 60, null, "/img/Rooms/Amelia rooms/Amelia double bed1.jpg", 17 },
                    { 61, null, "/img/Rooms/Amelia rooms/Amelia double bed2.jpg", 17 },
                    { 62, null, "/img/Rooms//Amelia rooms/Amelia apartment1.jpg", 18 },
                    { 63, null, "/img/Rooms//Amelia rooms/Amelia apartment2.jpg", 18 },
                    { 64, null, "/img/Rooms//Amelia rooms/Amelia apartment3.jpg", 18 },
                    { 65, null, "/img/Rooms//Amelia rooms/Amelia double bed delux1.jpg", 19 },
                    { 66, null, "/img/Rooms//Amelia rooms/Amelia double bed delux2.jpg", 19 },
                    { 67, null, "/img/Rooms//Amelia rooms/Amelia double bed delux3.jpg", 19 },
                    { 68, null, "/img/Rooms//Amelia rooms/Amelia double bed delux4.jpg", 19 }
                });

            migrationBuilder.InsertData(
                table: "RoomsBases",
                columns: new[] { "RoomBasisId", "RoomId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 16 },
                    { 1, 17 },
                    { 1, 18 },
                    { 1, 19 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 }
                });

            migrationBuilder.InsertData(
                table: "RoomsBases",
                columns: new[] { "RoomBasisId", "RoomId" },
                values: new object[,]
                {
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 17 },
                    { 2, 18 },
                    { 2, 19 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 14 },
                    { 3, 15 },
                    { 3, 16 },
                    { 3, 17 },
                    { 3, 18 },
                    { 3, 19 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 },
                    { 4, 13 },
                    { 4, 14 },
                    { 4, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 19 },
                    { 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomsBases",
                columns: new[] { "RoomBasisId", "RoomId" },
                values: new object[,]
                {
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 7 },
                    { 5, 8 },
                    { 5, 9 },
                    { 5, 10 },
                    { 5, 11 },
                    { 5, 12 },
                    { 5, 13 },
                    { 5, 14 },
                    { 5, 15 },
                    { 5, 16 },
                    { 5, 17 },
                    { 5, 18 },
                    { 5, 19 },
                    { 6, 6 },
                    { 6, 7 },
                    { 7, 4 },
                    { 7, 5 },
                    { 7, 6 },
                    { 7, 7 },
                    { 7, 10 },
                    { 7, 11 },
                    { 7, 12 },
                    { 7, 13 },
                    { 7, 14 },
                    { 7, 15 },
                    { 7, 16 },
                    { 7, 17 },
                    { 7, 18 },
                    { 7, 19 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 3 },
                    { 8, 4 },
                    { 8, 5 },
                    { 8, 6 },
                    { 8, 7 },
                    { 8, 8 }
                });

            migrationBuilder.InsertData(
                table: "RoomsBases",
                columns: new[] { "RoomBasisId", "RoomId" },
                values: new object[,]
                {
                    { 8, 9 },
                    { 8, 10 },
                    { 8, 11 },
                    { 8, 12 },
                    { 8, 13 },
                    { 8, 14 },
                    { 8, 15 },
                    { 8, 16 },
                    { 8, 17 },
                    { 8, 18 },
                    { 8, 19 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_HotelId",
                table: "Comments",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteHotels_HotelId",
                table: "FavoriteHotels",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteHotels_UserId",
                table: "FavoriteHotels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBenefits_BenefitId",
                table: "HotelBenefits",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_HotelId",
                table: "Pictures",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_RoomId",
                table: "Pictures",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RentCars_ReservationId",
                table: "RentCars",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HotelId",
                table: "Reservations",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PackageId",
                table: "Rooms",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsBases_RoomId",
                table: "RoomsBases",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FavoriteHotels");

            migrationBuilder.DropTable(
                name: "HotelBenefits");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "RentCars");

            migrationBuilder.DropTable(
                name: "RoomsBases");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "RoomBasis");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "RoomPackages");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
