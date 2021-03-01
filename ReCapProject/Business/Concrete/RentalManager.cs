using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _iRentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _iRentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            IResult failedLogic = BusinessTool.GetFailedLogic(CheckRentedCarIsReturnedDateExist(rental.ReturnDate));
            if (failedLogic != null)
            {
                return failedLogic;
            }
            _iRentalDal.Add(rental);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            return new SuccessDataResult<Rental>(_iRentalDal.Get(r => r.Id == id), Messages.SuccessfullyGotObject);
        }

        public IDataResult<List<Rental>> GetRentals()
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(), Messages.SuccessfullyListedObjects);
        }

        public IResult Remove(Rental rental)
        {
            _iRentalDal.Remove(rental);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IResult Update(Rental rental)
        {
            _iRentalDal.Update(rental);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }

        #region Rules
        private IResult CheckRentedCarIsReturnedDateExist(Nullable<DateTime> returnDate)
        {
            if (returnDate.HasValue)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.RentedCarIsNotExistReturnedDate);
        }
        #endregion
    }
}
