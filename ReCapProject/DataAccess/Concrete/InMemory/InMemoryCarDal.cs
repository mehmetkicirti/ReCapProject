using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private static InMemoryCarDal _instance;
        private IEnumerable<Car> Cars = null;
        private InMemoryCarDal()
        {
            Cars = new List<Car>()
            {
               new Car
               {
                   Id=1,
                   BrandId = 1,
                   ColorId = 1,
                   DailyPrice = 150,
                   ModelYear = 2017,
                   Description = "Renault Megane"
               },
               new Car
               {
                   Id=2,
                   BrandId = 2,
                   ColorId = 4,
                   DailyPrice = 270,
                   ModelYear = 2020,
                   Description = "Seat Leon"
               }
            };
        }

        public static InMemoryCarDal GetInMemoryInstance()
        {
                if(_instance == null)
                {
                    _instance = new InMemoryCarDal();
                }
                return _instance;
        }

        public void Add(Car entity)
        {
            var cars = Cars.ToList();
            cars.Add(entity);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return Cars.AsQueryable().Where(filter).SingleOrDefault();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return filter == null ?
                Cars.ToList() :
                Cars.AsQueryable().Where(filter).ToList();
        }

        public void Remove(Car entity)
        {
            var cars = Cars.ToList();
            cars.Remove(entity);
        }

        public void Update(Car entity)
        {
            Cars.ToList().Insert(entity.Id, entity);
        }
    }
}
