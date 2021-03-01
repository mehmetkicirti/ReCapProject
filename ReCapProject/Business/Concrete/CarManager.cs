using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        public IResult Add(Car car)
        {
            // the following rules will be in ValidationAspect give as an attribute
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.CarNameAtLeastTwoCharacter);
            }
            if (car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.DailyPriceGreaterThanZero);
            }
            _iCarDal.Add(car);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(Car car)
        {
            _iCarDal.Remove(car);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(), Messages.SuccessfullyListedObjects);
        }

        public IDataResult<Car> GetCarById(int id)
        {
            return new SuccessDataResult<Car>(_iCarDal.Get(c => c.Id == id), Messages.SuccessfullyGotObject);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(c => c.BrandId == brandId), Messages.SuccessfullyListedObjects);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(c => c.ColorId == colorId), Messages.SuccessfullyListedObjects);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarsDetails(), Messages.SuccessfullyListedObjects);
        }

        public IResult Update(Car car)
        {
            _iCarDal.Update(car);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }

        #region Rules
        #endregion
    }
}
