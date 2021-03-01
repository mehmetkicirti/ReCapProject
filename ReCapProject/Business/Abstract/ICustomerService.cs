using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetCustomers();
        IDataResult<Customer> GetCustomerById(int id);
        IResult Add(Customer Customer);
        IResult Remove(Customer Customer);
        IResult Update(Customer Customer);
    }
}
