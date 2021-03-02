using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _iCarImageDal;
        private readonly ICarService _iCarService;
        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _iCarImageDal = carImageDal;
            _iCarService = carService;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var errorResult = BusinessTool.GetFailedLogic(CheckImageLimitExceed(carImage.CarId));
            if (errorResult != null)
            {
                return errorResult;
            }
            var imageFullPath = FileHelper.AddImage(file);
            carImage.ImagePath = imageFullPath;
            carImage.CreatedDate = DateTime.Now;
            _iCarImageDal.Add(carImage);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = FileHelper.DeleteImage(carImage.ImagePath);
            if (result != null)
            {
                _iCarImageDal.Remove(carImage);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            return new ErrorResult(result.Message);
        }

        public IDataResult<CarImage> Get(int id)
        {
            var errorResult = BusinessTool.GetFailedLogic(CheckCarImageIdIsExist(id));
            if (errorResult != null)
            {
                return new ErrorDataResult<CarImage>(null, errorResult.Message);
            }
            return new SuccessDataResult<CarImage>(_iCarImageDal.Get(c => c.Id == id), Messages.SuccessfullyGotObject);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_iCarImageDal.GetAll(), Messages.SuccessfullyListedObjects);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var errorResult = BusinessTool.GetFailedLogic(CheckCarImageIdIsExist(carId));
            if (errorResult != null)
            {
                return new SuccessDataResult<List<CarImage>>(CheckCarImageIsNull(carId), Messages.SuccessfullyListedObjects);
            }
            return new ErrorDataResult<List<CarImage>>(null, errorResult.Message);
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var errorResult = BusinessTool.GetFailedLogic(CheckImageLimitExceed(carImage.CarId));
            if (errorResult != null)
            {
                return errorResult;
            }
            carImage.ImagePath = FileHelper.UpdateImage(carImage.ImagePath, file);
            carImage.CreatedDate = DateTime.Now;
            _iCarImageDal.Update(carImage);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }

        #region Rules
        private IResult CheckCarImageIdIsExist(int carImageId)
        {
            if (_iCarImageDal.Get(c => c.Id == carImageId) != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImageIdNotFoundError);
        }
        private IResult CheckCarIsExist(int carId)
        {
            if (_iCarService.GetCarById(carId) == null)
            {
                return new ErrorResult(Messages.CarIsNotExistError);
            }
            return new SuccessResult();
        }
        private IResult CheckImageLimitExceed(int carId)
        {
            if (_iCarImageDal.GetAll(c => c.CarId == carId).Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceed);
            }
            return new SuccessResult();
        }
        private List<CarImage> CheckCarImageIsNull(int carId)
        {
            string path = @"\Images\default.jpg";
            var carImages = _iCarImageDal.GetAll(c => c.CarId == carId);
            if (carImages.Any())
            {
                return new List<CarImage>
                {
                    new CarImage
                    {
                        CarId = carId,
                        CreatedDate = DateTime.Now,
                        ImagePath = path
                    }
                };
            }
            return carImages;
        }
        #endregion
    }
}
