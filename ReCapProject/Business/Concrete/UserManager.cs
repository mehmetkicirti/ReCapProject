using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _iUserDal;
        public UserManager(IUserDal userDal)
        {
            _iUserDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _iUserDal.Add(user);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IDataResult<User> GetUserById(int id)
        {
            return new SuccessDataResult<User>(_iUserDal.Get(u=>u.Id == id), Messages.SuccessfullyListedObjects);
        }

        public IDataResult<List<User>> GetUsers()
        {
            return new SuccessDataResult<List<User>>(_iUserDal.GetAll(), Messages.SuccessfullyListedObjects);
        }

        public IResult Remove(User user)
        {
            _iUserDal.Remove(user);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IResult Update(User user)
        {
            _iUserDal.Update(user);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    }
}
