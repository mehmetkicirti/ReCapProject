using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _iCarDal;
        public CarManager(ICarDal carDal)
        {
            _iCarDal = carDal;
        }
        public void Add(Car car)
        {
            if(car.Description.Length < 2)
            {
                throw new Exception(Messages.CarNameAtLeastTwoCharacter);
            }
            if(car.DailyPrice < 0)
            {
                throw new Exception(Messages.DailyPriceGreaterThanZero);
            }
            //businessRules
            _iCarDal.Add(car);
        }

        public void Delete(Car car)
        {
            _iCarDal.Remove(car);
        }

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public Car GetCarById(int id)
        {
            return _iCarDal.Get(c => c.Id == id);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _iCarDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _iCarDal.GetAll(c => c.ColorId == colorId);
        }

        public List<CarDetailDto> GetCarsDetails()
        {
            return _iCarDal.GetCarsDetails();
        }

        public void Update(Car car)
        {
            _iCarDal.Update(car);
        }

        #region Rules
        #endregion
    }
}
