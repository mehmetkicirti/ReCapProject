using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetRentals();
        IDataResult<Rental> GetRentalById(int id);
        IResult Add(Rental Rental);
        IResult Remove(Rental Rental);
        IResult Update(Rental Rental);
    }
}
