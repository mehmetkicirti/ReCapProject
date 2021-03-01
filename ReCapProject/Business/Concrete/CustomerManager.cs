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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _iCustomerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _iCustomerDal = customerDal;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _iCustomerDal.Add(customer);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IDataResult<Customer> GetCustomerById(int id)
        {
            return new SuccessDataResult<Customer>(_iCustomerDal.Get(c => c.Id == id), Messages.SuccessfullyGotObject);
        }

        public IDataResult<List<Customer>> GetCustomers()
        {
            return new SuccessDataResult<List<Customer>>(_iCustomerDal.GetAll(), Messages.SuccessfullyListedObjects);
        }

        public IResult Remove(Customer customer)
        {
            _iCustomerDal.Remove(customer);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _iCustomerDal.Update(customer);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    }
}
