using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        private static ICarDal inMemoryInstance = InMemoryCarDal.GetInMemoryInstance();
        private static ICarService _iCarService = new CarManager(new EFCarDal());
        private static IBrandService _iBrandService = new BrandManager(new EFBrandDal());
        private static IColorService _iColorService = new ColorManager(new EFColorDal());
        static void Main(string[] args)
        {
            #region InMemory
            //GetCarsOfDetails();
            //inMemoryInstance.Add(new Car
            //{
            //    Id = 3,
            //    BrandId = 3,
            //    ColorId = 2,
            //    DailyPrice = 125,
            //    ModelYear = 2014,
            //    Description = "Citroen C5"
            //});
            //GetCarDetailsById(3);
            //inMemoryInstance.Update(new Car
            //{
            //    Id = 1,
            //    BrandId = 10,
            //    ColorId = 21,
            //    DailyPrice = 230,
            //    ModelYear = 2018,
            //    Description = "Volkswagen Golf"
            //});
            //GetCarsOfDetails();
            //inMemoryInstance.Remove(new Car
            //{
            //    Id = 2,
            //});
            //GetCarsOfDetails(); 
            #endregion
            #region EF
            _iBrandService.Add(new Brand()
            {
                Name = "Volkswagen"
            });
            _iBrandService.Add(new Brand()
            {
                Name = "Seat"
            });
            _iColorService.Add(new Color()
            {
                Name = "White"
            });
            _iColorService.Add(new Color()
            {
                Name = "Red"
            });
            _iCarService.Add(new Car()
            {
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 125,
                Description = "Golf",
                ModelYear = 2017
            });
            _iCarService.Add(new Car()
            {
                BrandId = 2,
                ColorId = 2,
                DailyPrice = 180,
                Description = "Leon",
                ModelYear = 2020
            });
            ReadCarsDetails();
            #endregion
        }
        #region InMemoryMethods
        private static void GetCarsOfDetails()
        {
            foreach (var car in inMemoryInstance.GetAll())
            {
                CarDetails(car);
            }
        }

        private static void CarDetails(Car car)
        {
            if (car != null)
            {
                Console.WriteLine($"Car Id : {car.Id} \n " +
                               $"Car Brand Id : {car.BrandId} \n" +
                               $"Car Color Id : {car.ColorId} \n" +
                               $"Car Model Year : {car.ModelYear} \n" +
                               $"Car Daily Price : {car.DailyPrice} \n" +
                               $"Car Description : {car.Description} \n");
            }
            else Console.WriteLine("Araç Bulunamadı");
        }

        private static void GetCarDetailsById(int carId)
        {
            CarDetails(inMemoryInstance.Get(c => c.Id == carId));
        }
        #endregion
        #region EFMethods
        private static void ReadCarsDetails()
        {
            foreach (var carDetail in _iCarService.GetCarsDetails())
            {
                ReadCarsDetail(carDetail);
            }
        }

        private static void ReadCarsDetail(CarDetailDto carDetail)
        {
            if (carDetail != null)
            {
                Console.WriteLine($"Car Id : {carDetail.CarId} \n" +
                               $"Car Brand Name : {carDetail.BrandName} \n" +
                               $"Car Color Name : {carDetail.ColorName} \n" +
                               $"Car Name : {carDetail.CarName} \n" +
                               $"Car Daily Price : {carDetail.DailyPrice} \n");
            }
            else Console.WriteLine("Araç Bulunamadı");
        }
        #endregion

    }
}
