using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _iBrandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _iBrandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _iBrandDal.Add(brand);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(Brand brand)
        {
            _iBrandDal.Remove(brand);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_iBrandDal.GetAll(),Messages.SuccessfullyListedObjects);
        }

        public IDataResult<Brand> GetBrandById(int id)
        {
            return new SuccessDataResult<Brand>(_iBrandDal.Get(b => b.Id == id),Messages.SuccessfullyGotObject);
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _iBrandDal.Update(brand);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    }
}
