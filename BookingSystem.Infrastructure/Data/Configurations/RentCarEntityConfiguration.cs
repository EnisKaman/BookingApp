﻿namespace BookingSystem.Infrastructure.Data.Configurations
{
    using BookingSystem.Infrastructure.Data.enums;
    using BookingSystem.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RentCarEntityConfiguration : IEntityTypeConfiguration<RentCar>
    {
        public void Configure(EntityTypeBuilder<RentCar> builder)
        {
            ICollection<RentCar> cars = CreateCars();
            builder.HasData(cars);
        }

        private ICollection<RentCar> CreateCars()
        {
            List<RentCar> rentCars = new List<RentCar>()
            {
                new RentCar()
                {
                    Id = 1,
                    MakeType = "Bmw",
                    ModelType = "X6",
                    Year = 2020,
                    DoorsCount = 4,
                    CarImg = "/img/Cars/BmwX6 Blue.jpeg",
                    PricePerDay = 180,
                    FuelCapacity = 85,
                    FuelConsumption = 13.4,
                    Location = "Velingrad",
                    Lattitude = 42.026543162263934m,
                    Longitude = 23.991291982406658m,
                    TransmissionType = TransmissionType.AutomaticTransmission,
                    PeopleCapacity = 4,
                },
                new RentCar()
                {
                    Id = 2,
                    MakeType = "Bmw",
                    ModelType = "X3",
                    Year = 2018,
                    DoorsCount = 4,
                    CarImg = "/img/Cars/Bmw X3 2018.jpg",
                    PricePerDay = 150,
                    FuelCapacity = 60,
                    FuelConsumption = 13.4,
                    Location = "Velingrad",
                    Lattitude = 42.026543162263934m,
                    Longitude = 23.991291982406658m,
                    TransmissionType = TransmissionType.AutomaticTransmission,
                    PeopleCapacity = 4,
                },
                 new RentCar()
                 {
                    Id = 3,
                    MakeType = "Bmw",
                    ModelType = "X1",
                    Year = 2015,
                    DoorsCount = 4,
                    CarImg = "/img/Cars/Bmw X1 2015.jpg",
                    PricePerDay = 70,
                    FuelCapacity = 50,
                    FuelConsumption = 6.8,
                    Location = "Velingrad",
                    Lattitude = 42.026543162263934m,
                    Longitude = 23.991291982406658m,
                    TransmissionType = TransmissionType.AutomaticTransmission,
                    PeopleCapacity = 4,
                 },
                  new RentCar()
                  {
                    Id = 4,
                    MakeType = "Bmw",
                    ModelType = "X1",
                    Year = 2015,
                    DoorsCount = 4,
                    CarImg = "/img/Cars/Bmw X1 2015.jpg",
                    PricePerDay = 70,
                    FuelCapacity = 50,
                    FuelConsumption = 6.8,
                    Location = "Velingrad",
                    Lattitude = 42.026543162263934m,
                    Longitude = 23.991291982406658m,
                    TransmissionType = TransmissionType.AutomaticTransmission,
                    PeopleCapacity = 4,
                  },
                   new RentCar()
                   {
                     Id = 5,
                     MakeType = "Peugeot",
                     ModelType = "3008",
                     Year = 2019,
                     DoorsCount = 4,
                     CarImg = "/img/Cars/Peugeot 3008.jpg",
                     PricePerDay = 110,
                     FuelCapacity = 53,
                     FuelConsumption = 4.2,
                     Location = "Velingrad",
                     Lattitude = 42.026543162263934m,
                     Longitude = 23.991291982406658m,
                     TransmissionType = TransmissionType.AutomaticTransmission,
                     PeopleCapacity = 4,
                   },
                   new RentCar()
                   {
                      Id = 6,
                      MakeType = "Peugeot",
                      ModelType = "2008",
                      Year = 2019,
                      DoorsCount = 4,
                      CarImg = "/img/Cars/Peugeot-2008.jpg",
                      PricePerDay = 110,
                      FuelCapacity = 50,
                      FuelConsumption = 4.8,
                      Location = "Velingrad",
                      Lattitude = 42.026543162263934m,
                      Longitude = 23.991291982406658m,
                      TransmissionType = TransmissionType.AutomaticTransmission,
                      PeopleCapacity = 4,
                   },
                    new RentCar()
                    {
                      Id = 7,
                      MakeType = "Peugeot",
                      ModelType = "408",
                      Year = 2015,
                      DoorsCount = 4,
                      CarImg = "/img/Cars/Peugeot-408-2015.jpg",
                      PricePerDay = 40,
                      FuelCapacity = 50,
                      FuelConsumption = 4.8,
                      Location = "Velingrad",
                      Lattitude = 42.026543162263934m,
                      Longitude = 23.991291982406658m,
                      TransmissionType = TransmissionType.AutomaticTransmission,
                      PeopleCapacity = 4,
                    },
                    new RentCar()
                    {
                      Id = 8,
                      MakeType = "Mercedes",
                      ModelType = "CLA",
                      Year = 2014,
                      DoorsCount = 4,
                      CarImg = "/img/Cars/Mercedes CLA 2014.jpg",
                      PricePerDay = 50,
                      FuelCapacity = 35,
                      FuelConsumption = 4.9,
                      Location = "Velingrad",
                      Lattitude = 42.026543162263934m,
                      Longitude = 23.991291982406658m,
                      TransmissionType = TransmissionType.AutomaticTransmission,
                      PeopleCapacity = 4,
                    },
                    new RentCar()
                    {
                       Id = 9,
                       MakeType = "Mercedes",
                       ModelType = "C63",
                       Year = 2012,
                       DoorsCount = 4,
                       CarImg = "/img/Cars/Mercedes C63 2012.jpg",
                       PricePerDay = 35,
                       FuelCapacity = 30,
                       FuelConsumption = 4.4,
                       Location = "Velingrad",
                       Lattitude = 42.026543162263934m,
                       Longitude = 23.991291982406658m,
                       TransmissionType = TransmissionType.AutomaticTransmission,
                       PeopleCapacity = 4,
                    },
                     new RentCar()
                     {
                       Id = 10,
                       MakeType = "Mercedes",
                       ModelType = "GLE 350 Coupe",
                       Year = 2016,
                       DoorsCount = 4,
                       CarImg = "/img/Cars/Mercedes GLE 2016.jpg",
                       PricePerDay = 120,
                       FuelCapacity = 93,
                       FuelConsumption = 7.2,
                       Location = "Velingrad",
                       Lattitude = 42.026543162263934m,
                       Longitude = 23.991291982406658m,
                       TransmissionType = TransmissionType.AutomaticTransmission,
                       PeopleCapacity = 4,
                     },
                     new RentCar()
                     {
                       Id = 11,
                       MakeType = "BMW",
                       ModelType = "530d",
                       Year = 2017,
                       DoorsCount = 4,
                       CarImg = "/img/Cars/BMW-530d 2017.jpg",
                       PricePerDay = 80,
                       FuelCapacity = 78,
                       FuelConsumption = 4.7,
                       Location = "Sofia",
                       Lattitude = 42.700866541296215m,
                       Longitude = 23.304447911974357m,
                       TransmissionType = TransmissionType.AutomaticTransmission,
                       PeopleCapacity = 4,
                     },
                     new RentCar()
                     {
                       Id = 12,
                       MakeType = "BMW",
                       ModelType = "X4",
                       Year = 2015,
                       DoorsCount = 4,
                       CarImg = "/img/Cars/Bmx X4 2015.jpg",
                       PricePerDay = 65,
                       FuelCapacity = 67,
                       FuelConsumption = 5.9,
                       Location = "Sofia",
                       Lattitude = 42.700866541296215m,
                       Longitude = 23.304447911974357m,
                       TransmissionType = TransmissionType.AutomaticTransmission,
                       PeopleCapacity = 4,
                     },
                     new RentCar()
                     {
                       Id = 13,
                       MakeType = "Audi",
                       ModelType = "A7",
                       Year = 2017,
                       DoorsCount = 4,
                       CarImg = "/img/Cars/Adui A7 2016.png",
                       PricePerDay = 75,
                       FuelCapacity = 75,
                       FuelConsumption = 5.2,
                       Location = "Sofia",
                       Lattitude = 42.700866541296215m,
                       Longitude = 23.304447911974357m,
                       TransmissionType = TransmissionType.AutomaticTransmission,
                       PeopleCapacity = 4,
                     },
                     new RentCar()
                     {
                       Id = 14,
                       MakeType = "Renault",
                       ModelType = "Megane",
                       Year = 2012,
                       DoorsCount = 4,
                       CarImg = "/img/Cars/Renault Megane.jpg",
                       PricePerDay = 30,
                       FuelCapacity = 60,
                       FuelConsumption = 4.7,
                       Location = "Sofia",
                       Lattitude = 42.700866541296215m,
                       Longitude = 23.304447911974357m,
                       TransmissionType = TransmissionType.AutomaticTransmission,
                       PeopleCapacity = 4,
                     },
                     new RentCar()
                     {
                       Id = 15,
                       MakeType = "Skoda",
                       ModelType = "Ocativa",
                       Year = 2013,
                       DoorsCount = 4,
                       CarImg = "/img/Cars/Skoda Ocativa 2013.jpg",
                       PricePerDay = 35,
                       FuelCapacity = 50,
                       FuelConsumption = 5.1,
                       Location = "Sofia",
                       Lattitude = 42.700866541296215m,
                       Longitude = 23.304447911974357m,
                       TransmissionType = TransmissionType.AutomaticTransmission,
                       PeopleCapacity = 4,
                     },
                     new RentCar()
                     {
                        Id = 16,
                        MakeType = "Bmw",
                        ModelType = "X3",
                        Year = 2018,
                        DoorsCount = 4,
                        CarImg = "/img/Cars/Bmw X3 2018.jpg",
                        PricePerDay = 150,
                        FuelCapacity = 60,
                        FuelConsumption = 13.4,
                        Location = "Sofia",
                        Lattitude = 42.700866541296215m,
                        Longitude = 23.304447911974357m,
                        TransmissionType = TransmissionType.AutomaticTransmission,
                        PeopleCapacity = 4,
                     },
                     new RentCar()
                     {
                        Id = 17,
                        MakeType = "Bmw",
                        ModelType = "X6",
                        Year = 2020,
                        DoorsCount = 4,
                        CarImg = "/img/Cars/BmwX6 Blue.jpeg",
                        PricePerDay = 180,
                        FuelCapacity = 85,
                        FuelConsumption = 13.4,
                        Location = "Sofia",
                        Lattitude = 42.700866541296215m,
                        Longitude = 23.304447911974357m,
                        TransmissionType = TransmissionType.AutomaticTransmission,
                        PeopleCapacity = 4,
                     },
                     new RentCar()
                     {
                        Id = 18,
                        MakeType = "Bmw",
                        ModelType = "X6",
                        Year = 2020,
                        DoorsCount = 4,
                        CarImg = "/img/Cars/BmwX6 Blue.jpeg",
                        PricePerDay = 180,
                        FuelCapacity = 85,
                        FuelConsumption = 13.4,
                        Location = "Milano",
                        Lattitude = 45.43995264548058m,
                        Longitude = 9.20198333778624m,
                        TransmissionType = TransmissionType.AutomaticTransmission,
                        PeopleCapacity = 4,
                     },
                   new RentCar()
                   {
                      Id = 19,
                      MakeType = "Peugeot",
                      ModelType = "2008",
                      Year = 2019,
                      DoorsCount = 4,
                      CarImg = "/img/Cars/Peugeot-2008.jpg",
                      PricePerDay = 110,
                      FuelCapacity = 50,
                      FuelConsumption = 4.8,
                      Location = "Milano",
                      Lattitude = 45.43995264548058m,
                      Longitude = 9.20198333778624m,
                      TransmissionType = TransmissionType.AutomaticTransmission,
                      PeopleCapacity = 4,
                   },
                    new RentCar()
                    {
                      Id = 20,
                      MakeType = "Peugeot",
                      ModelType = "408",
                      Year = 2015,
                      DoorsCount = 4,
                      CarImg = "/img/Cars/Peugeot-408-2015.jpg",
                      PricePerDay = 40,
                      FuelCapacity = 50,
                      FuelConsumption = 4.8,
                      Location = "Milano",
                      Lattitude = 45.43995264548058m,
                      Longitude = 9.20198333778624m,
                      TransmissionType = TransmissionType.AutomaticTransmission,
                      PeopleCapacity = 4,
                    },
                    new RentCar()
                    {
                      Id = 21,
                      MakeType = "Mercedes",
                      ModelType = "CLA",
                      Year = 2014,
                      DoorsCount = 4,
                      CarImg = "/img/Cars/Mercedes CLA 2014.jpg",
                      PricePerDay = 50,
                      FuelCapacity = 35,
                      FuelConsumption = 4.9,
                      Location = "Milano",
                      Lattitude = 45.43995264548058m,
                      Longitude = 9.20198333778624m,
                      TransmissionType = TransmissionType.AutomaticTransmission,
                      PeopleCapacity = 4,
                    },
                    new RentCar()
                    {
                       Id = 22,
                       MakeType = "Mercedes",
                       ModelType = "C63",
                       Year = 2012,
                       DoorsCount = 4,
                       CarImg = "/img/Cars/Mercedes C63 2012.jpg",
                       PricePerDay = 35,
                       FuelCapacity = 30,
                       FuelConsumption = 4.4,
                       Location = "Milano",
                       Lattitude = 45.43995264548058m,
                       Longitude = 9.20198333778624m,
                       TransmissionType = TransmissionType.AutomaticTransmission,
                       PeopleCapacity = 4,
                    },
                    new RentCar()
                    {
                       Id = 23,
                       MakeType = "Mercedes",
                       ModelType = "ML",
                       Year = 2015,
                       DoorsCount = 4,
                       CarImg = "/img/Cars/Mercedes ML.jpg",
                       PricePerDay = 100,
                       FuelCapacity = 93,
                       FuelConsumption = 7.3,
                       Location = "Velingrad",
                       Lattitude = 42.026543162263934m,
                       Longitude = 23.991291982406658m,
                       TransmissionType = TransmissionType.AutomaticTransmission,
                       PeopleCapacity = 4,
                    },

            };
            return rentCars;
        }
    }
}
