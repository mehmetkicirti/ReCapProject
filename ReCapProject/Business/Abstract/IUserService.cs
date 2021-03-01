using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetUsers();
        IDataResult<User> GetUserById(int id);
        IResult Add(User user);
        IResult Remove(User user);
        IResult Update(User user);
    }
}
