using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        private static ICarDal inMemoryInstance = InMemoryCarDal.GetInMemoryInstance();
        static void Main(string[] args)
        {
            GetCarsOfDetails();
            inMemoryInstance.Add(new Car
            {
                Id = 3,
                BrandId = 3,
                ColorId = 2,
                DailyPrice = 125,
                ModelYear = 2014,
                Description = "Citroen C5"
            });
            GetCarDetailsById(3);
            inMemoryInstance.Update(new Car
            {
                Id = 1,
                BrandId = 10,
                ColorId = 21,
                DailyPrice = 230,
                ModelYear = 2018,
                Description = "Volkswagen Golf"
            });
            GetCarsOfDetails();
            inMemoryInstance.Remove(new Car
            {
                Id = 2,
            });
            GetCarsOfDetails();
        }
        private static void GetCarsOfDetails()
        {
            foreach (var car in inMemoryInstance.GetAll())
            {
                CarDetails(car);
            }
        }

        private static void CarDetails(Car car)
        {
            if(car != null)
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
    }
}
